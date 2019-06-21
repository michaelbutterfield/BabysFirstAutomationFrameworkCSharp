using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;

namespace training.automation.specflow.Test.CSharp.Runner
{
    using common.Utilities;
    using training.automation.common.Tests;
    using winium.Test.CSharp.StepDefinitions;
    using winium.Utilities;

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
                winium.Common.FailureScreenshot.TakeScreenshot();
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
