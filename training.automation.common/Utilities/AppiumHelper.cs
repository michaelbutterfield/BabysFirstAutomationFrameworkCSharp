using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;

namespace training.automation.common.Utilities
{
    public class AppiumHelper
    {
        public static TimeSpan DEFAULT_TIMEOUT = new TimeSpan(0, 0, 10);
        private static AppiumDriver<AppiumWebElement> driver;
        private static Uri testServerAddress = new Uri("http://127.0.0.1:4723/wd/hub");

        public void InitialiseAndroid()
        {

        }

        public void InitialiseAndroid(string applicationId)
        {

        }

        public void InitialiseIOS(string application)
        {
            string BundleId = null;

#pragma warning disable CS0618 // Type or member is obsolete
            DesiredCapabilities capabilities = new DesiredCapabilities();


            switch (application.ToLower())
            {
                case "contacts":
                    {
                        BundleId = "com.apple.MobileAddressBook";
                        break;
                    }
            }

            capabilities.SetCapability("automationName", "XCUITest");
            capabilities.SetCapability("platformName", "iOS");
            capabilities.SetCapability("updatedWDABundleId", "com.roq.WebDriverAgentRunner");
            capabilities.SetCapability("udid", "0464173d5acf9c1c5375ddf6d447b72c111d6ff4");
            capabilities.SetCapability("deviceName", "RoqIT Ipad");
            capabilities.SetCapability("platformVersion", "10.2.1");
            capabilities.SetCapability("bundleId", BundleId);
#pragma warning restore CS0618 // Type or member is obsolete
            driver = new IOSDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));
        }

        public static AppiumDriver<AppiumWebElement> GetDriver()
        {
            return driver;
        }

        public static AppiumWebElement FindElement(By locator)
        {
            return driver.FindElement(locator);
        }

        public static ReadOnlyCollection<AppiumWebElement> FindElements(By locator)
        {
            return driver.FindElements(locator);
        }
    }
}
