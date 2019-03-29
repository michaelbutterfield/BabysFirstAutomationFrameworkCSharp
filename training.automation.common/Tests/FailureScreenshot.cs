using OpenQA.Selenium;
using System;
using System.Drawing;
using System.IO;
using training.automation.common.utilities;
using training.automation.common.Utilities;
using System.Drawing.Imaging;

namespace training.automation.common.Tests
{
    public class FailureScreenshot
    {
        private static string screenshotDirectory = null;

        private static void CreateScreenshotDirectory()
        {
            try
            {
                screenshotDirectory = RuntimeTestData.GetAsString("TestRunDirectory") + "\\FailureScreenshot";
                RuntimeTestData.Add("ScreenshotDirectory", screenshotDirectory);

                if (!Directory.Exists(screenshotDirectory))
                {
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

            string ScreenshotName = TestHelper.GetScenario().Test.Name;

            IWebDriver driver = SeleniumHelper.GetWebDriver();

            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            screenshot.SaveAsFile(RuntimeTestData.GetAsString("ScreenshotDirectory") + ScreenshotName, ImageFormat.Gif);
        }


    }
}
