using TechTalk.SpecFlow;
using training.automation.common.Tests;
using training.automation.common.Utilities;
using training.automation.common.Utilities.Data;

namespace training.automation.appium.Test.Runner
{
    [Binding]
    public class TestRunner
    {
        [BeforeTestRun]
        static void BeforeTestRun()
        {
            string feature = "Just Testing";
            TestLogger.Initialise(feature);
            TrelloWebData.ReadUserPass();
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
            //AppiumHelper.InitialiseCalculatorApp();
            AppiumHelper.InitialiseAndroid();

        }

        [AfterScenario]
        static void AfterScenario()
        {
            AppiumHelper.DestroyDriver();
            RuntimeTestData.Destroy();
            TestLogger.LogScenarioEnd();
        }
    }
}
