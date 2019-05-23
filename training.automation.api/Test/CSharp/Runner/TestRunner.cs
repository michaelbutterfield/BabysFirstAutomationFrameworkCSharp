using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;
using training.automation.api.Data;
using training.automation.common.Tests;
using training.automation.common.Utilities;

namespace training.automation.api.Test.CSharp.Runner
{
    [Binding]
    public class TestRunner
    {
        [BeforeTestRun]
        static void BeforeTestRun()
        {
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
        }

        [AfterScenario]
        static void AfterScenario()
        {
            TestContext scenario = TestHelper.GetScenario();

            if (scenario.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                FailureScreenshot.TakeScreenshot();
            }

            RuntimeTestData.Destroy();
            TestLogger.LogScenarioEnd();
            TestLogger.Close();
        }
    }
}
