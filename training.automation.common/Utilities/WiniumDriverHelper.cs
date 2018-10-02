using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using training.automation.common.utilities;

namespace training.automation.common.Utilities
{
    public class WiniumDriverHelper
    {
        private static RemoteWebDriver Driver = null;

        private WiniumDriverHelper() { }

        public static RemoteWebDriver GetWiniumDriver()
        {
            return Driver;
        }

        public static void DestroyDriver()
        {
            Driver.Quit();

            Driver = null;
        }

        public static IWebElement GetElement(By locator)
        {
            return Driver.FindElement(locator);
        }

        public static void Initialise(String winiumPath, int winiumPort)
        {
            var desiredCapabailities = new DesiredCapabilities();
            desiredCapabailities.SetCapability("app", @"C:\Windows\System32\calc.exe");

            try
            {
                Driver = new RemoteWebDriver(new Uri("http://localhost:9999"), desiredCapabailities);
                TestHelper.WriteToConsole("Winium Driver Started");
            }
            catch (Exception e)
            {
                String errorMessage = "Failed to launch Winium Driver";
                TestHelper.HandleException(errorMessage, e, false);
            }
        }

    }
}
