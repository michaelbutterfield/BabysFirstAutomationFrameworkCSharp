using System;
using System.IO;
using training.automation.common.utilities;

namespace training.automation.common.Tests
{
    public class TestLogger
    {
        private static StreamWriter writer = null;
        private static string testRunDirectory = null;
        private static string logDateTimeFormat = "dd/MM/yy HH.mm";
        private static DateTime suiteRunStart;

        public static void Close()
        {
            try
            {
                writer.Close();
            }
            catch (Exception e)
            {
                TestHelper.HandleException("Unable to close writer", e, false);
            }
        }

        private static void CreateTestRunDirectory()
        {
            try
            {
                testRunDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\TestRuns\\TestRun_" + TestHelper.GetTodaysDateTime(logDateTimeFormat);
                //testRunDirectory = "C:\\Users\\michael.butterfield\\Desktop\\TestRuns\\TestRun_" + TestHelper.GetTodaysDateTime("dd-MM-yy HH.mm");

                if (!Directory.Exists(testRunDirectory))
                {
                    Directory.CreateDirectory(testRunDirectory);
                }
            }
            catch (Exception e)
            {
                string ErrorMessage = string.Format("Failed to create the test run directory with directory string: {0}", testRunDirectory);
                TestHelper.HandleException(ErrorMessage, e, false);
            }
            
        }

        public static void CreateTestStep(string description)
        {
            LogEntry(description);
        }

        public static void CreateTestStep(string action, string element, string page)
        {
            String stepDescription = string.Format("'{0}' '{1}' on page '{2}'", action, element, page);

            CreateTestStep(stepDescription);
        }

        private static String GetTestRunDirectory()
        {
            if (testRunDirectory == null)
            {
                CreateTestRunDirectory();
            }

            return testRunDirectory;
        }

        public static void Initialise()
        {
            String fileLocation = String.Format("{0}\\Log.txt", GetTestRunDirectory());

            try
            {
                writer = new StreamWriter(fileLocation);
            }
            catch (Exception e)
            {
                TestHelper.HandleException("Failed to start writer", e, false);
            }
        }

        public static void LogActionFailure(string failureMessage, Exception e)
        {
            LogEntry(failureMessage);
            LogExceptionOrError(e);
        }

        public static void LogExceptionOrError(Exception e)
        {
            LogEntry("EXCEPTION/ERROR MESSAGE: " + e.Message);
            LogEntry("STACK-TRACE: " + e.StackTrace);
        }

        public static void LogScenarioEnd()
        {
            String entryText = "*** SCENARIO ENDED *** : " + TestHelper.GetScenario().Test.Name + Environment.NewLine;
            LogEntry(entryText);
        }

        public static void LogScenarioStart()
        {
            String entryText = "*** SCENARIO STARTED *** : " + TestHelper.GetScenario().Test.Name;
            LogEntry(entryText);
        }

        //TODO: implement a timer to output at the end of test suite
        public static void LogSuiteDuration()
        {
            //Duration suiteDuration = 

            //long hours = suiteDuration.getStandardHours();
            //long minutes = suiteDuration.getStandardMinutes();
            //long seconds = suiteDuration.getStandardSeconds();

            //minutes = minutes - (hours * 60);

            //LogEntry("*** RUN DURATION INFORMATION ***");
            //LogEntry("Hours: " + hours + "	Minutes: " + minutes + "	Seconds: " + seconds);

        }

        public static void LogSuiteSetupEnd()
        {
            LogEntry("*** SUITE SETUP ENDED ***" + Environment.NewLine);
        }

        public static void LogSuiteSetupStart()
        {
            StartSuiteRunTimer();
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
            String result = "NULL";

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

        public static void StartSuiteRunTimer()
        {
            suiteRunStart = new DateTime();
        }

        private static void LogEntry(String entryText)
        {
            try
            {
                String textToLog = TestHelper.GetTodaysDateTime(logDateTimeFormat) + " " + entryText;
                writer.WriteLine(textToLog);
            }
            catch (Exception e)
            {
                TestHelper.HandleException("Unable to LogEntry", e, false);
            }
        }
    }
}
