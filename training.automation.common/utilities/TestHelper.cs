using System;
using System.Text.RegularExpressions;
using System.Threading;
using NHamcrest;
using NHamcrest.Core;
using NUnit.Framework;

namespace training.automation.common.Utilities
{
    using Tests;

    public static class TestHelper
    {
        private static TestContext scenario;

        public static void AssertThat<T>(T actual, IMatcher<T> matcher, string stepDescription)
        {
            AssertThat(actual, matcher, stepDescription, true);
        }

        public static void AssertThat<T>(T actual, IMatcher<T> matcher, string stepDescription, bool takeScreenshot)
        {
            TestLogger.CreateTestStep(stepDescription);

            try
            {
                if (!matcher.Matches(actual))
                {
                    StringDescription description = new StringDescription();

                    description.AppendText(stepDescription)
                                .AppendText("\nExpected: ")
                                .AppendDescriptionOf(matcher)
                                .AppendText("\n     but: ");

                    matcher.DescribeMismatch(actual, description);

                    throw new Exception(string.Format("Failed to assert that actual: \"{0}\" - is equal to expected: \"{1}\"", actual, matcher));
                }
            }
            catch (Exception e)
            {
                string ErrorMessage = string.Format("{0} failed. {1} {2}", stepDescription, "\n", e.Message);
                HandleException(ErrorMessage, e);
            }

        }

        public static TestContext GetScenario()
        {
            scenario = TestContext.CurrentContext;

            return scenario;
        }

        public static string GetTodaysDateTime(string format)
        {
            return DateTime.Now.ToString(format);
        }


        public static void HandleException(string ErrorMessage, Exception e)
        {
            HandleException(ErrorMessage, e, false);
        }

        public static void HandleException(string ErrorMessage, Exception e, bool takeScreenshot)
        {
            string exception = string.Format("{0} : {1} : ", ErrorMessage, e);

            TestLogger.LogActionFailure(exception, e);

            //FailureScreenshot.TakeScreenshot();

            throw new ArgumentException(e.Message, e);
        }

        public static string RemoveBackslashAndQuotation(this string str)
        {
            str = Regex.Replace(str, "[\\ \"]", "");

            return str;
        }

        public static bool ScenarioHasTag(string tagName)
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
                TestHelper.HandleException(errorMessage, e);
            }
        }

        public static void WriteToConsole(String message)
        {
            NUnit.Framework.TestContext.Progress.WriteLine(message);
        }
    }
}
