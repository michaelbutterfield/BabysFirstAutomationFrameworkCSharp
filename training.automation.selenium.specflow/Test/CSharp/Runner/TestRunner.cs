using TechTalk.SpecFlow;
using training.automation.api.Data;
using training.automation.common.Tests;
using training.automation.common.utilities;
using training.automation.specflow.Application;
using training.automation.specflow.Data;

namespace training.automation.specflow.Test.CSharp.Runner
{
    [Binding]
    public class TestRunner
    {
        [BeforeTestRun]
        static void BeforeTestRun()
        {
            TestLogger.Initialise();
            TestLogger.LogSuiteSetupStart();
            TrelloWebData.ReadUserPass();
            //TrelloApiData.ReadApiKeyToken();
        }

        [BeforeScenario]
        static void BeforeScenario()
        {
            SeleniumHelper.Initialise("chrome");
        }

        [AfterScenario]
        static void AfterScenario()
        {
            DesktopWebsite.Header.BackToHome.JsClick();
            TestHelper.SleepInSeconds(2);
            DesktopWebsite.BoardsPage.UserBoard.Click();
            DesktopWebsite.SpecificBoardsPage.MoreSideMenu.Click();
            DesktopWebsite.SpecificBoardsPage.CloseBoard.Click();
            DesktopWebsite.SpecificBoardsPage.CloseBoardConfirmation.Click();
            DesktopWebsite.SpecificBoardsPage.PermDeleteBoard.Click();
            DesktopWebsite.SpecificBoardsPage.PermDeleteBoardConfirm.Click();
            //DesktopWebsite.SpecificBoardsPage.BoardNotFound.AssertElementTextContains("Board not found.");
            DesktopWebsite.Header.TrelloLogoHome.Click();

            SeleniumHelper.DestroyDriver();
        }
    }
}
