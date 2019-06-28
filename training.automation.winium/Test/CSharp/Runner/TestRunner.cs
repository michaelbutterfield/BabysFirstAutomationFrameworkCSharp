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
            WiniumHelper.KillProcess("Calculator");
            RuntimeTestData.Destroy();
            TestLogger.LogScenarioEnd();
            TestLogger.Close();
        }

        [BeforeScenario]
        static void BeforeScenario()
        {
            WiniumHelper.Initialise();
            string feature = FeatureContext.Current.FeatureInfo.Title;
            if (!RuntimeTestData.ContainsKey("FeatureName"))
            {
                RuntimeTestData.Add("FeatureName", feature);
            }
            TestLogger.Initialise();
            TestLogger.LogScenarioStart();
            CalculatorSteps.I_reset_the_calculator();
        }
    }
}
