using NUnit.Framework;
using NUnit.Framework.Interfaces;
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
            TrelloWebData.ReadUserPass();
            DriverType.driverType = DriverType.DRIVER_TYPE.APPIUM;
        }

        [AfterTestRun]
        static void AfterTestRun()
        {
            
        }

        [BeforeScenario]
        static void BeforeScenario()
        {
            string feature = FeatureContext.Current.FeatureInfo.Title;
            TestLogger.Initialise(feature);
            TestLogger.LogScenarioStart();
            //AppiumHelper.InitialiseCalculatorApp();
            AppiumHelper.InitialiseAndroid();

        }

        [AfterScenario]
        static void AfterScenario()
        {
            TestContext scenario = TestHelper.GetScenario();

            if (scenario.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                FailureScreenshot.TakeScreenshot();
            }

            AppiumHelper.DestroyDriver();
            RuntimeTestData.Destroy();
            TestLogger.LogScenarioEnd();
            TestLogger.Close();
        }
    }
}
