using System;
using System.Threading;
using NHamcrest;
using NHamcrest.Core;
using NUnit.Framework;
using training.automation.common.Tests;

namespace training.automation.common.utilities
{
    public class TestHelper
    {
        private static TestContext scenario;

        public static void AssertThat<T>(T actual, IMatcher<T> matcher, String stepDescription)
        {
            AssertThat(actual, matcher, stepDescription, true);
        }

        public static void AssertThat<T>(T actual, IMatcher<T> matcher, String stepDescription, Boolean takeScreenshot)
        {
            TestLogger.CreateTestStep(stepDescription);

            if (!matcher.Matches(actual))
            {
                var description = new StringDescription();

                description .AppendText(stepDescription)
                            .AppendText("\nExpected: ")
                            .AppendDescriptionOf(matcher)
                            .AppendText("\n     but: ");

                matcher.DescribeMismatch(actual, description);

                throw new InvalidOperationException(description.ToString());
            }
        }

        public static TestContext GetScenario()
        {
            scenario = TestContext.CurrentContext;

            return scenario;
        }

        public static void HandleException(string ErrorMessage, Exception e, bool takeScreenshot)
        {
            String exception = String.Format("{0} : {1} : ", ErrorMessage, e);

            TestHelper.WriteToConsole(exception);

            TestLogger.LogActionFailure(exception, e);

            throw new System.ArgumentException(e.Message, e);
        }

        public static String GetTodaysDateTime(String format)
        {
            return DateTime.Now.ToString(format);
        }

        public static bool ScenarioHasTag(String tagName)
        {
            return GetScenario().Test.Name.Contains(tagName);
        }

        public static void SetScenario(TestContext givenScenario)
        {
            scenario = givenScenario;
        }

        public static void SleepInSeconds(int seconds)
        {
            try
            {
                Thread.Sleep(seconds * 1000);
            }
            catch (ThreadInterruptedException e)
            {
                String errorMessage = String.Format("Unable to perform the requested '{0}' second sleep", seconds);
                TestHelper.HandleException(errorMessage, e, false);
            }
        }

        public static void WriteToConsole(String message)
        {
            NUnit.Framework.TestContext.Progress.WriteLine(message);
        }
    }
}
