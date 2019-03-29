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
        }

        [AfterTestRun]
        static void AfterTestRun()
        {

        }

        [BeforeScenario]
        static void BeforeScenario()
        {
            TestLogger.Initialise();
            TestLogger.LogScenarioStart();
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
            TestLogger.LogScenarioEnd();
            TestLogger.Close();
        }
    }
}
