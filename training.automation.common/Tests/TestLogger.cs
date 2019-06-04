using System;
using System.Diagnostics;
using System.IO;
using training.automation.common.Utilities;

namespace training.automation.common.Tests
{
    public class TestLogger
    {
        private static StreamWriter writer = null;
        private static string testRunDirectory = null;
        private static string logDateTimeFormat = "dd.MM.yy";// HH.mm.ss";
        private static Stopwatch scenarioRunStopwatch;

        public static void Close()
        {
            try
            {
                writer.Close();
            }
            catch (Exception e)
            {
                TestHelper.HandleException("Unable to close writer", e);
            }
        }

        private static void CreateTestRunDirectory(string FeatureName)
        {
            try
            {
                string ProjectPath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName);

                testRunDirectory = string.Concat(ProjectPath, "\\TestRuns\\TestRun_", TestHelper.GetTodaysDateTime(logDateTimeFormat), "\\", FeatureName, "\\");
                RuntimeTestData.Add("TestRunDirectory", testRunDirectory);

                if (!Directory.Exists(testRunDirectory))
                {
                    Directory.CreateDirectory(testRunDirectory);
                }
            }
            catch (Exception e)
            {
                string ErrorMessage = string.Format("Failed to create the test run directory with directory string: {0}", testRunDirectory);
                TestHelper.HandleException(ErrorMessage, e);
            }
        }

        public static void CreateTestStep(string description)
        {
            LogEntry(description);
        }

        public static void CreateTestStep(string action, string element, string page)
        {
            string stepDescription = string.Format("'{0}' '{1}' on page '{2}'", action, element, page);

            CreateTestStep(stepDescription);
        }

        private static string GetTestRunDirectory(string FeatureName)
        {
            if (testRunDirectory == null || !testRunDirectory.Contains(FeatureName))
            {
                CreateTestRunDirectory(FeatureName);
            }

            return testRunDirectory;
        }

        public static void Initialise(string FeatureName)
        {
            string scenarioName = TestHelper.GetScenario().Test.Name;

            scenarioName = scenarioName.RemoveBackslashAndQuotation();

            string fileLocation = string.Concat(GetTestRunDirectory(FeatureName), scenarioName, ".txt");

            try
            {
                writer = new StreamWriter(fileLocation);
            }
            catch (Exception e)
            {
                TestHelper.HandleException("Failed to start writer", e);
            }
        }

        public static void LogActionFailure(string failureMessage, Exception e)
        {
            LogEntry("\n");
            LogEntry("***********************");
            LogEntry("********FAILURE********");
            LogEntry("\n");
            LogEntry(failureMessage);
            LogEntry("\n");
            LogExceptionOrError(e);
            LogEntry("*****END OF FAILURE*****");
            LogEntry("************************");
            LogEntry("\n");
        }

        public static void LogExceptionOrError(Exception e)
        {
            LogEntry("***EXCEPTION/ERROR MESSAGE***: " + e.Message);
            LogEntry("\n");
            LogEntry("***STACK-TRACE***: " + e.StackTrace);
            LogEntry("\n");
        }

        public static void LogScenarioEnd()
        {
            scenarioRunStopwatch.Stop();
            string entryText = string.Concat(Environment.NewLine, "*** SCENARIO ENDED *** : ", TestHelper.GetScenario().Test.Name, Environment.NewLine);
            LogEntry(entryText);
            LogTestResult();

            TimeSpan ts = scenarioRunStopwatch.Elapsed;

            LogEntry("**    SCENARIO RAN IN --- Hours:  " + ts.Hours + "   Minutes: " + ts.Minutes + "	Seconds: " + ts.Seconds + " **");
        }

        public static void LogScenarioStart()
        {
            scenarioRunStopwatch = new Stopwatch();
            scenarioRunStopwatch.Start();
            string entryText = string.Concat("*** SCENARIO STARTED *** : ", TestHelper.GetScenario().Test.Name, Environment.NewLine);
            LogEntry(entryText);
        }

        //TODO: implement a timer to output at the end of test suite
        public static void LogSuiteDuration()
        {

            //LogEntry("*** RUN DURATION INFORMATION ***");
            //LogEntry("Hours: " + hours + "	Minutes: " + mins + "	Seconds: " + secs);
        }

        public static void LogSuiteSetupEnd()
        {
            LogEntry("*** SUITE SETUP ENDED ***" + Environment.NewLine);
        }

        public static void LogSuiteSetupStart()
        {
            //suiteRunStopwatch.Start();
            LogEntry("*** SUITE SETUP STARTED ***");
        }

        public static void LogSuiteTeardownEnd()
        {
            LogEntry("*** SUITE TEARDOWN ENDED ***" + Environment.NewLine);
            LogSuiteDuration();
        }

        public static void LogSuiteTeardownStart()
        {
            LogEntry("*** SUITE TEARDOWN STARTED ***");
        }

        public static void LogTestResult()
        {
            string result = "NULL";

            if (TestHelper.GetScenario().Result.Outcome.ToString().Equals("Failed:Error"))
            {
                result = "FAILED";
            }
            else
            {
                result = "PASSED";
            }

            LogEntry("*** RESULT *** - Scenario: " + TestHelper.GetScenario().Test.Name + " -- Finished with the Result: " + result);
        }

        private static void LogEntry(string entryText)
        {
            try
            {
                string textToLog = TestHelper.GetTodaysDateTime(logDateTimeFormat) + " " + entryText;
                writer.WriteLine(textToLog);
            }
            catch (Exception e)
            {
                TestHelper.HandleException("Unable to LogEntry", e);
            }
        }
    }
}
