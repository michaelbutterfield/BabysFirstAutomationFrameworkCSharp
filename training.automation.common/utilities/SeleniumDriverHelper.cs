using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace training.automation.common.utilities
{
    class SeleniumDriverHelper
    { 
        private static IWebDriver m_Driver = null;
        public static TimeSpan m_DEFAULT_TIMEOUT = new TimeSpan(0, 0, 10);

        private SeleniumDriverHelper()
        {
            //
        }

        public void DestroyDriver()
        {
            m_Driver.Quit();
            m_Driver = null;
        }

        public string GetCurrentUrl()
        {
            return m_Driver.Url;
        }

        public static IWebDriver GetWebDriver()
        {
            return m_Driver;
        }

        public void GoToUrl(string Url)
        {
            m_Driver.Navigate().GoToUrl(Url);
        }

        public void Initialise(string browser)
        {
            browser = browser.ToLower();

            switch(browser)
            {
                case "chrome":
                    {
                        m_Driver = new ChromeDriver();
                        break;
                    }
                case "firefox":
                    {
                        m_Driver = new FirefoxDriver();
                        break;
                    }
                case "ie":
                    {
                        m_Driver = new InternetExplorerDriver();
                        break;
                    }
                default:
                    throw new System.ArgumentException("Browser choice not set or choice incorrect: " + browser);
            }

            m_Driver.Manage().Window.Maximize();
        }

        public void WaitForElementToBeClickable(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(GetWebDriver(), m_DEFAULT_TIMEOUT);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public void WaitForElementToBeVisible(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(GetWebDriver(), m_DEFAULT_TIMEOUT);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementSelectionStateToBe(element, true));
        }
    }
}
