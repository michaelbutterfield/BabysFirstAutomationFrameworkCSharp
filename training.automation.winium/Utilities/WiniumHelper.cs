using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Winium;
using System;

namespace training.automation.winium.Utilities
{
    using common.Utilities;

    public class WiniumHelper
    {
        private static DesktopOptions Options = new DesktopOptions { ApplicationPath = @"C:\\Windows\\System32\\calc.exe" };
        private static WiniumDriverService Service = WiniumDriverService.CreateDesktopService(AppDomain.CurrentDomain.BaseDirectory);
        private static WiniumDriver Driver = null;

        private WiniumHelper() { }

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

        public static void Initialise()
        {
            try
            {
                Driver = new WiniumDriver(Service, Options);
                TestHelper.WriteToConsole("Winium Driver Started");
            }
            catch (Exception e)
            {
                string errorMessage = "Failed to launch Winium Driver";
                TestHelper.HandleException(errorMessage, e);
            }
        }

    }
}
