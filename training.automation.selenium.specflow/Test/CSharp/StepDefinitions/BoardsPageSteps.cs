using NHamcrest;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using training.automation.common.Utilities;


namespace training.automation.specflow.Test.CSharp.StepDefinitions
{
    using Application;

    [Binding]
    public sealed class BoardsPageSteps
    {
        [When]
        public static void go_through_all_the_delete_prompts()
        {
            DesktopWebsite.SpecificBoardsPage.Invite.WaitUntilExists();

            if (DesktopWebsite.SpecificBoardsPage.ShowMenu.Exists())
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

        [Given]
        public void I_am_on_the_boards_page()
        {
            DesktopWebsite.BoardsPage.PersonalBoards.WaitUntilExists();
            DesktopWebsite.BoardsPage.AssertPageTitleIs("Boards | Trello");
        }

        [When]
        public void I_click_create_board()
        {
            DesktopWebsite.BoardsPage.Header.Add.Click();
            DesktopWebsite.BoardsPage.CreateNewBoard.Click();
        }

        [Given][When]
        public void I_click_on_the_user_created_board()
        {
            DesktopWebsite.BoardsPage.ClickTheUserBoard();
        }

        [When]
        public void I_click_the_favourite_board_star()
        {
            DesktopWebsite.BoardsPage.ClickBoardStar();
        }

        [Given][When]
        public void I_create_the_user_board()
        {
            string BoardName = RandomGen.RandomAlphabetString(8);
            RuntimeTestData.Add("BoardName", BoardName);

            string BoardDesc = RandomGen.RandomSentence(40);
            RuntimeTestData.Add("BoardDesc", BoardDesc);

            TrelloAPIHelper.CreateBoard(BoardName, BoardDesc);
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
        public void The_board_will_be_favourited()
        {
            try
            {
                bool starStatus = TrelloAPIHelper.GetBoardStarredStatus(TrelloAPIHelper.GetTrelloBoardId(RuntimeTestData.GetAsString("BoardName")));

                if (starStatus == false)
                {
                    string stepDef = "UserBoard was not successfully starred";
                    throw new Exception(stepDef);
                }
            }
            catch (Exception e)
            {
                TestHelper.HandleException("Board wasn't starred", e);
            }
        }

        [Then]
        public void the_environment_will_be_set_up()
        {
            DesktopWebsite.BoardsPage.AssertTheUserBoardExists();
        }

        [Then]
        public void the_user_board_will_be_created()
        {
            DesktopWebsite.SpecificBoardsPage.EnterListTitle.WaitUntilExists();
            DesktopWebsite.SpecificBoardsPage.Header.TrelloLogoHome.JsClick();
            DesktopWebsite.BoardsPage.PersonalBoards.WaitUntilExists();
            DesktopWebsite.BoardsPage.AssertTheUserBoardExists();
        }

        [Then]
        public static void the_user_board_will_be_deleted()
        {
            DesktopWebsite.SpecificBoardsPage.Header.BackToHome.WaitUntilExists();
            DesktopWebsite.SpecificBoardsPage.Header.BackToHome.JsClick();
            DesktopWebsite.BoardsPage.AssertTheUserBoardDoesNotExist();
            RuntimeTestData.Remove("BoardName");
        }
    }
}
