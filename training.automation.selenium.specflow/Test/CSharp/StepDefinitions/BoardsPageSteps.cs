using NHamcrest;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using training.automation.api.Utilities;
using training.automation.common.utilities;
using training.automation.common.Utilities;
using training.automation.specflow.Application;
using RandomGen = training.automation.common.Utilities.RandomGen;

namespace training.automation.specflow.Test.CSharp.StepDefinitions
{
    [Binding]
    public sealed class BoardsPageSteps
    {
        [Given]
        public void I_click_on_a_board()
        {
            DesktopWebsite.BoardsPage.PersonalBoards.WaitUntilExists();
            SeleniumHelper.GetElement(By.XPath("//ul[@class='boards-page-board-section-list']/li[@class='boards-page-board-section-list-item']")).Click();
        }


        [Given(@"I am on the boards page")]
        public void IAmOnTheBoardsPage()
        {
            DesktopWebsite.BoardsPage.PersonalBoards.WaitUntilExists();
            string ExpectedSiteTitle = "Boards | Trello";
            string ActualSiteTitle = SeleniumHelper.GetWebDriver().Title;
            string StepDesc = string.Format("Assert that framework's on the Boards Page. Expected Site Title: {0} - Actual Site Title: {1}", ExpectedSiteTitle, ActualSiteTitle);
            TestHelper.AssertThat(ExpectedSiteTitle, Is.EqualTo(ActualSiteTitle), StepDesc);
        }

        [Given, When(@"I click on the user created board")]
        public static void IClickOnTheUserCreatedBoard()
        {
            if (DesktopWebsite.BoardsPage.UserBoard == null)
            {
                DesktopWebsite.BoardsPage.AssignUserBoard(RuntimeTestData.GetAsString("BoardName"));
            }

            if (!DesktopWebsite.BoardsPage.UserBoard.Exists())
            {
                DesktopWebsite.BoardsPage.Header.BackToHome.JsClick();
            }

            DesktopWebsite.BoardsPage.AssignUserBoard(RuntimeTestData.GetAsString("BoardName"));

            DesktopWebsite.BoardsPage.UserBoard.WaitUntilExists();
            DesktopWebsite.BoardsPage.UserBoard.Click();
        }

        [When(@"I click the favourite board star")]
        public void IClickTheFavouriteBoardStar()
        {
            string UserBoard = RuntimeTestData.GetAsString("BoardName");
            //DesktopWebsite.BoardsPage.AssignBoardToStar(UserBoard);
            //SeleniumHelper.HoverOverElement(string.Format("//div[text()='{0}']", UserBoard));

            DesktopWebsite.BoardsPage.AssignBoardToStar(UserBoard);
            try
            {
                SeleniumHelper.HoverOverElement(string.Format("//div[@title='{0}']", UserBoard));
                DesktopWebsite.BoardsPage.Unstarred.Click();
            }
            catch (Exception e)
            {
                string ErrorMessage = "Failed trying to hover over and click the UserBoard star";
                TestHelper.HandleException(ErrorMessage, e);
            }
        }

        [Given, When(@"I create the user board")]
        public void ICreateTheUserBoard()
        {
            //Old UI way of doing it
            //DesktopWebsite.Header.Add.Click();
            //DesktopWebsite.BoardsPage.CreateNewBoard.Click();

            //string BoardName = Random.RandomAlphanumericString(10);
            //RuntimeTestData.Add("BoardName", BoardName);

            //DesktopWebsite.CreateBoardPage.NameInput.SendKeys(BoardName);
            //DesktopWebsite.CreateBoardPage.BackgroundSelection.Click();
            //DesktopWebsite.CreateBoardPage.CreateBoard.Click();

            string BoardName = RandomGen.RandomAlphabetString(8);
            RuntimeTestData.Add("BoardName", BoardName);

            string BoardDesc = RandomGen.RandomSentence(40);
            RuntimeTestData.Add("BoardDesc", BoardDesc);

            TrelloAPIHelper.CreateBoard(BoardName, BoardDesc);
        }

        [Then(@"The board will be favourited")]
        public void TheBoardWillBeFavourited()
        {
            try
            {
                if (!TrelloAPIHelper.GetBoardStarredStatus(TrelloAPIHelper.GetTrelloBoardId(RuntimeTestData.GetAsString("BoardName"))))
                {
                    string ErrorMessage = "Board not successfully starred or got false get from API";
                    throw new Exception(ErrorMessage);
                }
            }
            catch(Exception e)
            {
                TestHelper.HandleException("Board wasn't starred", e);
            }
            
        }

        [Then(@"the environment will be set up")]
        public void TheEnvironmentWillBeSetUp()
        {
            DesktopWebsite.BoardsPage.AssignUserBoard(RuntimeTestData.GetAsString("BoardName"));
            DesktopWebsite.BoardsPage.UserBoard.WaitUntilExists();
            DesktopWebsite.BoardsPage.UserBoard.AssertExists();
        }

        [When]
        public void I_click_create_board()
        {
            DesktopWebsite.BoardsPage.Header.Add.Click();
            DesktopWebsite.BoardsPage.CreateNewBoard.Click();
        }

        [When]
        public void I_fill_in_the_user_board_details()
        {
            string BoardName = RandomGen.RandomAlphabetString(10);
            RuntimeTestData.Add("BoardName", BoardName);

            DesktopWebsite.CreateBoardPage.NameInput.SendKeys(BoardName);
            DesktopWebsite.CreateBoardPage.BackgroundSelection.Click();
            DesktopWebsite.CreateBoardPage.CreateBoard.Click();
        }

        [Then]
        public void the_user_board_will_be_created()
        {
            while (!DesktopWebsite.SpecificBoardsPage.MoreSideMenu.Exists())
            {
                DesktopWebsite.SpecificBoardsPage.MoreSideMenu.WaitUntilExists();
            }
            
            DesktopWebsite.SpecificBoardsPage.Header.TrelloLogoHome.JsClick();
            DesktopWebsite.BoardsPage.PersonalBoards.WaitUntilExists();
            DesktopWebsite.BoardsPage.AssignUserBoard(RuntimeTestData.GetAsString("BoardName"));
            DesktopWebsite.BoardsPage.UserBoard.AssertExists();
        }

        [When]
        public static void go_through_all_the_delete_prompts()
        {
            DesktopWebsite.SpecificBoardsPage.Invite.WaitUntilExists();

            if(DesktopWebsite.SpecificBoardsPage.ShowMenu.Exists())
            {
                DesktopWebsite.SpecificBoardsPage.ShowMenu.Click();
            }

            DesktopWebsite.SpecificBoardsPage.MoreSideMenu.WaitUntilExists();
            DesktopWebsite.SpecificBoardsPage.MoreSideMenu.Click();
            DesktopWebsite.SpecificBoardsPage.CloseBoard.Click();
            DesktopWebsite.SpecificBoardsPage.CloseBoardConfirmation.Click();
            DesktopWebsite.SpecificBoardsPage.PermDeleteBoard.Click();
            DesktopWebsite.SpecificBoardsPage.PermDeleteBoardConfirm.Click();
            DesktopWebsite.SpecificBoardsPage.BoardNotFound.WaitUntilExists();
            DesktopWebsite.SpecificBoardsPage.BoardNotFound.GetElementAttribute("innerText").ToString().Equals("Board not found.");
        }

        [Then]
        public static void the_user_board_will_be_deleted()
        {
            DesktopWebsite.SpecificBoardsPage.Header.BackToHome.WaitUntilExists();
            DesktopWebsite.SpecificBoardsPage.Header.BackToHome.JsClick();
            DesktopWebsite.BoardsPage.UserBoard.AssertDoesNotExist();
        }


        [Given]
        public void I_delete_all_the_boards()
        {
            DesktopWebsite.BoardsPage.PersonalBoards.WaitUntilExists();

            IReadOnlyCollection<IWebElement> test = SeleniumHelper.GetElements(By.XPath("//ul[@class='boards-page-board-section-list']/li[@class='boards-page-board-section-list-item']"));

            int boardCount = test.Count;

            while (boardCount > 1)
            {
                SeleniumHelper.GetElement(By.XPath("//ul[@class='boards-page-board-section-list']/li[@class='boards-page-board-section-list-item']")).Click();

                go_through_all_the_delete_prompts();

                DesktopWebsite.SpecificBoardsPage.BoardNotFound.WaitUntilExists();

                DesktopWebsite.SpecificBoardsPage.Header.BackToHome.JsClick();

                DesktopWebsite.BoardsPage.PersonalBoards.WaitUntilExists();

                boardCount--;
            }

            RuntimeTestData.Add("BoardCount", boardCount);
        }

        [Then]
        public void no_boards_will_be_left()
        {
            int BoardCount = (int)RuntimeTestData.Get("BoardCount");

            string stepDesc = string.Format("Assert no boards are left on the boards page");

            TestHelper.AssertThat(BoardCount, Is.EqualTo(1), stepDesc);
        }
    }
}
