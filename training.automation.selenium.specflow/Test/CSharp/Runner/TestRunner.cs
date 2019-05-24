using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;
using training.automation.api.Data;
using training.automation.api.Utilities;
using training.automation.common.Tests;
using training.automation.common.utilities;
using training.automation.common.Utilities;
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
            TrelloWebData.ReadUserPass();
            TrelloApiData.ReadApiKeyToken();
            TestLogger.Initialise();
        }

        [AfterTestRun]
        static void AfterTestRun()
        {
            TestLogger.Close();
        }

        [BeforeScenario]
        static void BeforeScenario()
        {
            TestLogger.LogScenarioStart();
            SeleniumHelper.Initialise("chrome");
        }

        [AfterScenario]
        static void AfterScenario()
        {
            TestContext scenario = TestHelper.GetScenario();

            if (scenario.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                FailureScreenshot.TakeScreenshot();
            }

            if (RuntimeTestData.ContainsKey("BoardName"))
            {
                DesktopWebsite.SpecificBoardsPage.Header.BackToHome.JsClick();
                DesktopWebsite.BoardsPage.PersonalBoards.WaitUntilExists();

                if (DesktopWebsite.BoardsPage.UserBoard.Exists())
                {
                    TrelloAPIHelper.DeleteBoard(TrelloAPIHelper.GetTrelloBoardId(RuntimeTestData.GetAsString("BoardName")));
                }
            }

            SeleniumHelper.DestroyDriver();
            RuntimeTestData.Destroy();
            TestLogger.LogScenarioEnd();
        }
    }
}
