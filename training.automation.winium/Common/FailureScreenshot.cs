using OpenQA.Selenium;
using System;
using System.Drawing.Imaging;
using System.IO;
using training.automation.common.Utilities;
using training.automation.winium.Utilities;

namespace training.automation.winium.Common
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

            WiniumHelper.GetWiniumDriver().GetScreenshot().SaveAsFile(string.Concat(RuntimeTestData.GetAsString("ScreenshotDirectory"), "\\", ScreenshotName), ImageFormat.Png);

            //screenshot.SaveAsFile(string.Concat(RuntimeTestData.GetAsString("ScreenshotDirectory"), "\\", ScreenshotName), ImageFormat.Png);
        }
    }
}
