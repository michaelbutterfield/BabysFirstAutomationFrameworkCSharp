using RestSharp;
using TechTalk.SpecFlow;
using training.automation.api.Data;
using training.automation.api.Utilities;
using training.automation.common.Tests;
using training.automation.common.utilities;
using training.automation.common.Utilities;
using training.automation.specflow.Application;
using training.automation.specflow.Data;
using training.automation.specflow.Test.CSharp.StepDefinitions;

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
            TrelloApiData.ReadApiKeyToken();
        }

        static void AfterTestRun()
        {
            TestLogger.Close();
        }

        [BeforeScenario]
        static void BeforeScenario()
        {
            SeleniumHelper.Initialise("chrome");
        }

        [AfterScenario]
        static void AfterScenario()
        {
            if (RuntimeTestData.ContainsKey("BoardName"))
            {
                DesktopWebsite.Header.BackToHome.JsClick();
                DesktopWebsite.BoardsPage.PersonalBoards.WaitUntilExists();

                if (DesktopWebsite.BoardsPage.UserBoard.Exists())
                {
                    TrelloAPIHelper.DeleteBoard(TrelloAPIHelper.GetTrelloBoardId(RuntimeTestData.GetAsString("BoardName")));
                }
            }

            SeleniumHelper.DestroyDriver();
            RuntimeTestData.Destroy();
        }
    }
}
