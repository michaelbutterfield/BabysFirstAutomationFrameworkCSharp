using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using training.automation.api.Utilities;
using training.automation.common.utilities;
using training.automation.specflow.Application;

namespace training.automation.specflow.Test.CSharp.StepDefinitions
{
    [Binding]
    public sealed class BoardsPageSteps
    {
        [Given(@"I am on the boards page")]
        public void IAmOnTheBoardsPage()
        {
            DesktopWebsite.Header.Add.WaitForElementToBeClickable();
            Assert.AreEqual("Boards | Trello", SeleniumHelper.GetWebDriver().Title);
        }

        [Given(@"I click on the user created board")]
        public void IClickOnTheUserCreatedBoard()
        {
            DesktopWebsite.BoardsPage.UserBoard.Click();
        }

        [When(@"I click the favourite board star")]
        public void IClickTheFavouriteBoardStar()
        {
            SeleniumHelper.HoverOverElement("//div[contains(text(),'TestBoard')]");
            DesktopWebsite.BoardsPage.Unstarred.Click();
        }

        [When(@"I create the user board")]
        public void ICreateTheUserBoard()
        {
            DesktopWebsite.Header.Add.Click();
            DesktopWebsite.BoardsPage.CreateNewBoard.Click();
            DesktopWebsite.CreateBoardPage.NameInput.InputText("TestBoard");
            DesktopWebsite.CreateBoardPage.BackgroundSelection.Click();
            DesktopWebsite.CreateBoardPage.CreateBoard.Click();
        }

        [Then(@"The board will be favourited")]
        public void TheBoardWillBeFavourited()
        {
            try
            {
                if (!TrelloHelper.GetBoardStarredStatus(TrelloHelper.GetTrelloBoardId("TestBoard")))
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
            TestHelper.SleepInSeconds(3);
            DesktopWebsite.Header.BackToHome.JsClick();
            DesktopWebsite.BoardsPage.UserBoard.AssertElementIsDisplayed();
        }
    }
}
