using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.IO;
using training.automation.common.utilities;
using training.automation.common.Utilities;
using training.automation.common.Utilities.Data;

namespace training.automation.common.Tests
{
    public class FailureScreenshot
    {
        private static string screenshotDirectory = null;

        private static void CreateScreenshotDirectory()
        {
            try
            {
                screenshotDirectory = string.Concat(RuntimeTestData.GetAsString("TestRunDirectory"), "FailureScreenshots");

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

            string scenarioName = TestHelper.GetScenario().Test.Name;

            scenarioName = scenarioName.RemoveBackslashAndQuotation();

            string ScreenshotName = string.Concat(scenarioName, ".png");

            if (DriverType.driverType == DriverType.DRIVER_TYPE.APPIUM)
            {
                AppiumDriver<AppiumWebElement> driver = AppiumHelper.GetDriver();

                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                screenshot.SaveAsFile(string.Concat(RuntimeTestData.GetAsString("ScreenshotDirectory"), "\\", ScreenshotName));
            }
            else if(DriverType.driverType == DriverType.DRIVER_TYPE.SELENIUM)
            {

                IWebDriver driver = SeleniumHelper.GetWebDriver();

                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                screenshot.SaveAsFile(string.Concat(RuntimeTestData.GetAsString("ScreenshotDirectory"), "\\", ScreenshotName));
            }
        }
    }
}
