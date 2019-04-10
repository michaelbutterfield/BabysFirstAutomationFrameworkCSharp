using OpenQA.Selenium;
using System;
using System.IO;
using training.automation.common.utilities;
using training.automation.common.Utilities;

namespace training.automation.common.Tests
{
    public class FailureScreenshot
    {
        private static string screenshotDirectory = null;

        private static void CreateScreenshotDirectory()
        {
            try
            {
                screenshotDirectory = string.Concat(RuntimeTestData.GetAsString("TestRunDirectory"), "\\FailureScreenshots");

                if (!Directory.Exists(screenshotDirectory))
                {
                    RuntimeTestData.Add("ScreenshotDirectory", screenshotDirectory);

                    Directory.CreateDirectory(screenshotDirectory);
                }
            }
            catch (Exception e)
            {
                string ErrorMessage = string.Format("Failed to create the screenshot directory with directory string: {0}", screenshotDirectory);
                TestHelper.HandleException(ErrorMessage, e);
            }
        }

        public static void TakeScreenshot()
        {
            CreateScreenshotDirectory();

            string ScreenshotName = string.Concat(TestHelper.GetScenario().Test.Name, ".png");

            IWebDriver driver = SeleniumHelper.GetWebDriver();

            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            screenshot.SaveAsFile(string.Concat(RuntimeTestData.GetAsString("ScreenshotDirectory"), "\\", ScreenshotName));
        }


    }
}
