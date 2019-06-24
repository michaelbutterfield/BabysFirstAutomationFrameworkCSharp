using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;

namespace training.automation.specflow.Test.CSharp.Runner
{
    using common.Tests;
    using common.Utilities;
    using common.Utilities.Data;
    using common.Utilities.Data.Trello;

    [Binding]
    public class TestRunner
    {
        [BeforeTestRun]
        static void BeforeTestRun()
        {
            DriverType.driverType = DriverType.DRIVER_TYPE.SELENIUM;
            TrelloWebData.ReadUserPass();
            TrelloApiData.ReadApiKeyToken();
            TestRailUser.ReadUserPass();
            TestRail.CreateTestRun();
        }

        [BeforeScenario]
        static void BeforeScenario()
        {
            string feature = FeatureContext.Current.FeatureInfo.Title;
            TestLogger.Initialise(feature);
            TestLogger.LogScenarioStart();
            SeleniumHelper.Initialise("chrome");
            SeleniumHelper.GoToUrl("http://trello.com");
        }

        [AfterScenario]
        static void AfterScenario()
        {
            TestStatus runResult = TestHelper.GetScenario().Result.Outcome.Status;

            TestRail.PostTestResults(runResult);

            if (runResult.Equals(TestStatus.Failed))
            {
                FailureScreenshot.TakeScreenshot();
            }

            if (RuntimeTestData.ContainsKey("BoardName"))
            {
                TrelloAPIHelper.DeleteBoard(TrelloAPIHelper.GetTrelloBoardId(RuntimeTestData.GetAsString("BoardName")));
                RuntimeTestData.Remove("BoardName");
            }

            SeleniumHelper.DestroyDriver();
            RuntimeTestData.Destroy();
            TestLogger.LogScenarioEnd();
            TestLogger.Close();
        }
    }
}
