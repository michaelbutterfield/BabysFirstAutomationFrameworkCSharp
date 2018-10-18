using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace training.automation.common.utilities
{
    public class SeleniumHelper
    { 
        private static IWebDriver Driver = null;
        public static TimeSpan DEFAULT_TIMEOUT = new TimeSpan(0, 0, 10);

        private SeleniumHelper()
        {
            //
        }

        public static void DestroyDriver()
        {
            Driver.Quit();
            Driver = null;
        }

        public static string GetCurrentUrl()
        {
            return Driver.Url;
        }

        public static IWebDriver GetWebDriver()
        {
            return Driver;
        }

        public static void GoToUrl(string Url)
        {
            Driver.Navigate().GoToUrl(Url);
        }

        public static void Initialise(string browser)
        {
            browser = browser.ToLower();

            switch(browser)
            {
                case "chrome":
                    {
                        Driver = new ChromeDriver(@"C:\Users\michael.butterfield\git\BabysFirstAutomationFrameworkCSharp\training.automation.common\Drivers");
                        break;
                    }
                case "firefox":
                    {
                        Driver = new FirefoxDriver();
                        break;
                    }
                case "ie":
                    {
                        Driver = new InternetExplorerDriver();
                        break;
                    }
                default:
                    throw new System.ArgumentException("Browser choice not set or choice incorrect: " + browser);
            }

            Driver.Manage().Window.Maximize();

            GoToUrl("http://trello.com");
        }

        public void WaitForElementToBeClickable(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(GetWebDriver(), DEFAULT_TIMEOUT);
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public void WaitForElementToBeVisible(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(GetWebDriver(), DEFAULT_TIMEOUT);
            wait.Until(ExpectedConditions.ElementSelectionStateToBe(element, true));
        }
    }
}
