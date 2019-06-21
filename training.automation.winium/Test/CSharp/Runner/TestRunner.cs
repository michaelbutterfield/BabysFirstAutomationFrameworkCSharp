using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;

namespace training.automation.specflow.Test.CSharp.Runner
{
    using common.Tests;
    using common.Utilities;
    using winium.Test.CSharp.StepDefinitions;
    using winium.Utilities;

    [Binding]
    static class TestRunner
    {
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
