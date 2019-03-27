using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using training.automation.api.Utilities;
using training.automation.common.Selenium.Elements;
using training.automation.common.utilities;
using training.automation.common.Utilities;
using training.automation.specflow.Application;
using Random = training.automation.common.Utilities.Random;

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
            DesktopWebsite.Header.Add.WaitForElementToBeClickable();
            Assert.AreEqual("Boards | Trello", SeleniumHelper.GetWebDriver().Title);
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
                DesktopWebsite.Header.BackToHome.JsClick();
            }

            DesktopWebsite.BoardsPage.UserBoard.WaitUntilExists();
            DesktopWebsite.BoardsPage.UserBoard.JsClick();
        }

        [When(@"I click the favourite board star")]
        public void IClickTheFavouriteBoardStar()
        {
            SeleniumHelper.HoverOverElement(string.Format("//div[contains(text(),'{0}')]", RuntimeTestData.GetAsString("BoardName")));
            DesktopWebsite.BoardsPage.Unstarred.Click();
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

            TrelloAPIHelper.CreateBoard(Random.RandomAlphanumericString(8), Random.RandomAlphanumericString(20));
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
                TestHelper.HandleException("Board wasn't starred", e, true);
            }
            
        }

        [Then(@"the environment will be set up")]
        public void TheEnvironmentWillBeSetUp()
        {
            DesktopWebsite.SpecificBoardsPage.AddList.WaitUntilExists();
            DesktopWebsite.Header.BackToHome.JsClick();
            DesktopWebsite.BoardsPage.AssignUserBoard(RuntimeTestData.GetAsString("BoardName"));
            DesktopWebsite.BoardsPage.UserBoard.WaitUntilExists();
            DesktopWebsite.BoardsPage.UserBoard.AssertExists();
        }

        [When]
        public void I_click_create_board()
        {
            DesktopWebsite.Header.Add.Click();
            DesktopWebsite.BoardsPage.CreateNewBoard.Click();
        }

        [When]
        public void I_fill_in_the_user_board_details()
        {
            string BoardName = Random.RandomAlphanumericString(10);
            RuntimeTestData.Add("BoardName", BoardName);

            DesktopWebsite.CreateBoardPage.NameInput.SendKeys(BoardName);
            DesktopWebsite.CreateBoardPage.BackgroundSelection.Click();
            DesktopWebsite.CreateBoardPage.CreateBoard.Click();
        }

        [Then]
        public void the_user_board_will_be_created()
        {
            //if (DesktopWebsite.BoardsPage.PersonalBoards.Exists())
            //{
            //    DesktopWebsite.BoardsPage.AssignUserBoard(RuntimeTestData.GetAsString("BoardName"));
            //    DesktopWebsite.BoardsPage.UserBoard.JsClick();
            //}
            TestHelper.SleepInSeconds(10);
            DesktopWebsite.SpecificBoardsPage.MoreSideMenu.WaitUntilExists();
            DesktopWebsite.Header.BackToHome.JsClick();
            DesktopWebsite.BoardsPage.PersonalBoards.WaitUntilExists();
            DesktopWebsite.BoardsPage.AssignUserBoard(RuntimeTestData.GetAsString("BoardName"));
            DesktopWebsite.BoardsPage.UserBoard.AssertExists();
        }

        [When]
        public static void go_through_all_the_delete_prompts()
        {
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
            DesktopWebsite.Header.BackToHome.WaitUntilExists();
            DesktopWebsite.Header.BackToHome.JsClick();
            DesktopWebsite.BoardsPage.UserBoard.AssertDoesNotExist();
        }


        [Given]
        public void I_delete_all_the_boards()
        {
            DesktopWebsite.BoardsPage.PersonalBoards.WaitUntilExists();

            IReadOnlyCollection<IWebElement> test = SeleniumHelper.GetElements(By.XPath("//ul[@class='boards-page-board-section-list']/li[@class='boards-page-board-section-list-item']"));

            int boardCount = test.Count;

            while (boardCount > 0)
            {
                SeleniumHelper.GetElement(By.XPath("//ul[@class='boards-page-board-section-list']/li[@class='boards-page-board-section-list-item']")).Click();

                BoardsPageSteps.go_through_all_the_delete_prompts();

                DesktopWebsite.SpecificBoardsPage.BoardNotFound.WaitUntilExists();

                DesktopWebsite.Header.BackToHome.JsClick();

                DesktopWebsite.BoardsPage.PersonalBoards.WaitUntilExists();

                boardCount--;
            }
        }

        [Then]
        public void no_boards_will_be_left()
        {
            
        }
    }
}
