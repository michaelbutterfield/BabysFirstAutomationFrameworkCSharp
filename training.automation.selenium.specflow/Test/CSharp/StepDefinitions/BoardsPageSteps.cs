using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using training.automation.api.Utilities;
using training.automation.common.utilities;
using training.automation.common.Utilities;
using training.automation.specflow.Application;
using Random = training.automation.common.Utilities.Random;

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
            SeleniumHelper.GetElement(By.XPath(string.Format("//div[@title='{0}'", RuntimeTestData.GetAsString("BoardName")))).Click(); ;
        }

        [When(@"I click the favourite board star")]
        public void IClickTheFavouriteBoardStar()
        {
            SeleniumHelper.HoverOverElement(string.Format("//div[contains(text(),'{0}')]", RuntimeTestData.GetAsString("BoardName")));
            DesktopWebsite.BoardsPage.Unstarred.Click();
        }

        [When(@"I create the user board")]
        public void ICreateTheUserBoard()
        {
            DesktopWebsite.Header.Add.Click();
            DesktopWebsite.BoardsPage.CreateNewBoard.Click();

            string BoardName = Random.RandomAlphanumericString(10);
            RuntimeTestData.Add("BoardName", BoardName);

            DesktopWebsite.CreateBoardPage.NameInput.SendKeys(BoardName);
            DesktopWebsite.CreateBoardPage.BackgroundSelection.Click();
            DesktopWebsite.CreateBoardPage.CreateBoard.Click();
        }

        [Then(@"The board will be favourited")]
        public void TheBoardWillBeFavourited()
        {
            try
            {
                if (!TrelloHelper.GetBoardStarredStatus(TrelloHelper.GetTrelloBoardId(RuntimeTestData.GetAsString("BoardName"))))
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
            DesktopWebsite.Header.BackToHome.WaitUntilExists();
            DesktopWebsite.Header.BackToHome.JsClick();
        }
    }
}
