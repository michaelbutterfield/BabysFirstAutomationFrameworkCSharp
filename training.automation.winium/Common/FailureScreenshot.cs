using System;
using System.Drawing.Imaging;
using System.IO;

namespace training.automation.winium.Common
{
    using common.Utilities;
    using training.automation.common.Tests;
    using Utilities;

    public class FailureScreenshot
    {
        private static string screenshotDirectory = null;

        private static void CreateScreenshotDirectory()
        {
            try
            {
                
                screenshotDirectory = string.Concat(TestLogger.GetTestRunDirectory(RuntimeTestData.GetAsString("FeatureName")), "FailureScreenshots");

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
