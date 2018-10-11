using System;
using System.Text;
using System.Threading;
using NHamcrest;
using NHamcrest.Core;

namespace training.automation.common.utilities
{
    public class TestHelper
    {
        public static void AssertThat<T>(T actual, IMatcher<T> matcher, String stepDescription)
        {
            AssertThat(actual, matcher, stepDescription, true);
        }

        public static void AssertThat<T>(T actual, IMatcher<T> matcher, String stepDescription, Boolean takeScreenshot)
        {
            Console.WriteLine(stepDescription);

            TestHelper.WriteToConsole(stepDescription);

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

        public static void HandleException(String errorMessage, Exception e, Boolean takeScreenshot)
        {
            String exception = String.Format("{0} : {1} : ", errorMessage, e);

            Console.WriteLine(exception);

            TestHelper.WriteToConsole(exception);

            throw new System.ArgumentException(e.Message, e);
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
