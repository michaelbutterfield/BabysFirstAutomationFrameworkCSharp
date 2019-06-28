using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;

namespace training.automation.appium.Test.Runner
{
    using common.Tests;
    using common.Utilities;
    using common.Utilities.Data;

    [Binding]
    public class TestRunner
    {
        [BeforeTestRun]
        static void BeforeTestRun()
        {
            TrelloWebData.ReadUserPass();
            DriverType.driverType = DriverType.DRIVER_TYPE.APPIUM;
        }

        [BeforeScenario]
        static void BeforeScenario()
        {
            string feature = FeatureContext.Current.FeatureInfo.Title;
            if (!RuntimeTestData.ContainsKey("FeatureName"))
            {
                RuntimeTestData.Add("FeatureName", feature);
            }

            TestLogger.Initialise();
            TestLogger.LogScenarioStart();
            AppiumHelper.InitialiseAppiumOptions();

            if (feature.Equals("Calculator"))
            {
                AppiumHelper.InitialiseCalculatorApp();
            }
            else if (feature.Equals("Trello"))
            {
                AppiumHelper.InitialiseChromeApp();
            }

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
