using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;
using training.automation.common.Tests;
using training.automation.common.Utilities;

namespace training.automation.winium.Test.CSharp.Runner
{
    using StepDefinitions;
    using Utilities;

    [Binding]
    static class TestRunner
    {
        [AfterFeature]
        static void AfterFeature()
        {
            RuntimeTestData.Destroy();
        }

        [AfterScenario]
        static void AfterScenario()
        {
            TestContext scenario = TestHelper.GetScenario();

            if (scenario.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                Common.FailureScreenshot.TakeScreenshot();
            }

            WiniumHelper.DestroyDriver();
            TestLogger.LogScenarioEnd();
            TestLogger.Close();
        }

        [BeforeScenario]
        static void BeforeScenario()
        {
            WiniumHelper.Initialise();
            string feature = FeatureContext.Current.FeatureInfo.Title;
            TestLogger.Initialise(feature);
            TestLogger.LogScenarioStart();
            CalculatorSteps.I_reset_the_calculator();
        }
    }
}
