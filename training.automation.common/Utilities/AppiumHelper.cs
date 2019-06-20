using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;

namespace training.automation.common.Utilities
{
    public class AppiumHelper
    {
        private static string appPackage { get; set; }
        private static string appActivity { get; set; }

        public static TimeSpan DEFAULT_TIMEOUT = new TimeSpan(0, 0, 10);
        private static AppiumDriver<AppiumWebElement> _driver;
        private static AppiumLocalService _appiumLocalService;


        public static void DestroyDriver()
        {
            _driver.Dispose();
            _driver.Quit();
        }

        /*
            In order for this to work you have to update Appium.Webdriver to the
            4.0.0.6-beta - otherwise it won't understand AppiumOptions or allow
            you to start a driver with the local service.
        */

        public static void InitialiseAndroid()
        {
            _appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            _appiumLocalService.Start();
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "OnePlus 7 Pro");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, "9b29e3d6");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "9");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.BrowserName, "Chrome");
            //appiumOptions.AddAdditionalCapability("appPackage", appPackage);
            //appiumOptions.AddAdditionalCapability("appActivity", appActivity);
            _driver = new AndroidDriver<AppiumWebElement>(_appiumLocalService, appiumOptions);
        }

        public void CloseApp()
        {
            _driver.CloseApp();
        }


        public static void InitialiseCalculatorApp()
        {
            appPackage = "com.oneplus.calculator";
            appActivity = "com.oneplus.calculator.Calculator";
        }

        //        public static void InitialiseIOS(string application)
        //       {
        //            string BundleId = null;
        //            DesiredCapabilities capabilities = new DesiredCapabilities();


        //            switch (application.ToLower())
        //            {
        //                case "calendar":
        //                    {
        //                        BundleId = "com.apple.mobilecal";
        //                        break;
        //                    }
        //            }

        //            capabilities.SetCapability("automationName", "XCUITest");
        //            capabilities.SetCapability("platformName", "iOS");
        //            capabilities.SetCapability("updatedWDABundleId", "com.roq.WebDriverAgentRunner");
        //            capabilities.SetCapability("udid", "0464173d5acf9c1c5375ddf6d447b72c111d6ff4");
        //            capabilities.SetCapability("deviceName", "iPad");
        //            capabilities.SetCapability("platformVersion", "12.1.1");
        //            capabilities.SetCapability("bundleId", BundleId);
        //            driver = new IOSDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4923/wd/hub"), capabilities, TimeSpan.FromSeconds(180));
        //        }

        public static AppiumDriver<AppiumWebElement> GetDriver()
        {
            return _driver;
        }

        public static void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public static AppiumWebElement FindElement(By locator)
        {
            return _driver.FindElement(locator);
        }

        public static ReadOnlyCollection<AppiumWebElement> FindElements(By locator)
        {
            return _driver.FindElements(locator);
        }

    }

}
