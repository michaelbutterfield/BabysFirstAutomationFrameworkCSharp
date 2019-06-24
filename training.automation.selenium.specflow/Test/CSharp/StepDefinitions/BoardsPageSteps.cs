using NHamcrest;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using training.automation.common.Utilities;
using RandomGen = training.automation.common.Utilities.RandomGen;

namespace training.automation.specflow.Test.CSharp.StepDefinitions
{
    using Application;
    using training.automation.common.Selenium.Elements;

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
            DesktopWebsite.BoardsPage.AssertPageTitleIs("Boards | Trello");
        }

        [Given, When(@"I click on the user created board")]
        public static void IClickOnTheUserCreatedBoard()
        {
            DesktopWebsite.BoardsPage.ClickTheUserBoard();
        }

        [When(@"I click the favourite board star")]
        public void IClickTheFavouriteBoardStar()
        {
            DesktopWebsite.BoardsPage.ClickBoardStar();
        }

        [Given, When(@"I create the user board")]
        public void ICreateTheUserBoard()
        {
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
                bool starStatus = TrelloAPIHelper.GetBoardStarredStatus(TrelloAPIHelper.GetTrelloBoardId(RuntimeTestData.GetAsString("BoardName")));

                if(starStatus == false)
                {
                    string stepDef = "UserBoard was not successfully starred";
                    throw new Exception(stepDef);
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
            DesktopWebsite.BoardsPage.AssertTheUserBoardExists();
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
            DesktopWebsite.SpecificBoardsPage.EnterListTitle.WaitUntilExists();
            DesktopWebsite.SpecificBoardsPage.Header.TrelloLogoHome.JsClick();
            DesktopWebsite.BoardsPage.PersonalBoards.WaitUntilExists();
            DesktopWebsite.BoardsPage.AssertTheUserBoardExists();
        }

        [When]
        public static void go_through_all_the_delete_prompts()
        {
            DesktopWebsite.SpecificBoardsPage.Invite.WaitUntilExists();

            if(DesktopWebsite.SpecificBoardsPage.ShowMenu.Exists())
            {
                DesktopWebsite.SpecificBoardsPage.ShowMenu.JsClick();
            }

            DesktopWebsite.SpecificBoardsPage.MoreSideMenu.WaitUntilExists();
            DesktopWebsite.SpecificBoardsPage.MoreSideMenu.Click();
            DesktopWebsite.SpecificBoardsPage.CloseBoard.Click();
            DesktopWebsite.SpecificBoardsPage.CloseBoardConfirmation.Click();
            DesktopWebsite.SpecificBoardsPage.PermDeleteBoard.Click();
            DesktopWebsite.SpecificBoardsPage.PermDeleteBoardConfirm.Click();
            DesktopWebsite.SpecificBoardsPage.BoardNotFound.WaitUntilExists();
            string boardNotFound = DesktopWebsite.SpecificBoardsPage.BoardNotFound.GetElementAttribute("innerText");
            TestHelper.AssertThat(boardNotFound, Is.EqualTo("Board not found."), "Assert board has been deleted successfully");
        }

        [Then]
        public static void the_user_board_will_be_deleted()
        {
            DesktopWebsite.SpecificBoardsPage.Header.BackToHome.WaitUntilExists();
            DesktopWebsite.SpecificBoardsPage.Header.BackToHome.JsClick();
            DesktopWebsite.BoardsPage.AssertTheUserBoardDoesNotExist();
            RuntimeTestData.Remove("BoardName");
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
