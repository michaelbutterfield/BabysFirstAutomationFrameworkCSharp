using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using training.automation.appium.Application;
using training.automation.common.Tests;
using training.automation.common.Utilities;

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
            AppiumHelper.InitialiseArgosApp();
            AppiumHelper.InitialiseAndroid();

            //AppiumHelper.InitialiseIOS("Calendar");
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
