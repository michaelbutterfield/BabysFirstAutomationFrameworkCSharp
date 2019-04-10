﻿using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;
using training.automation.common.Tests;
using training.automation.common.Utilities;
using training.automation.winium.Common;
using training.automation.winium.Utilities;
using FailureScreenshot = training.automation.winium.Common.FailureScreenshot;

namespace training.automation.specflow.Test.CSharp.Runner
{
    [Binding]
    public class TestRunner
    {
        [BeforeTestRun]
        static void BeforeTestRun()
        {
        }

        [AfterTestRun]
        static void AfterTestRun()
        {

        }

        [BeforeScenario]
        static void BeforeScenario()
        {
            WiniumHelper.Initialise();
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

            WiniumHelper.DestroyDriver();
            RuntimeTestData.Destroy();
            TestLogger.LogScenarioEnd();
            TestLogger.Close();
        }
    }
}