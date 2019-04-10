using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using training.automation.common.Tests;
using training.automation.common.Utilities;

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

        public static void DragAndDropAction(By startLocation, By endLocation)
        {
            Actions act = new Actions(GetWebDriver());

            IWebElement From = GetWebDriver().FindElement(startLocation);
            IWebElement To = GetWebDriver().FindElement(endLocation);

            try
            {
                act.DragAndDrop(From, To).Build().Perform();
            }
            catch (Exception e)
            {
                TestHelper.HandleException("Failed to perform Drag and Drop action.", e);
            }
        }

        public static void DragAndDropAction(IWebElement From, IWebElement To)
        {
            Actions act = new Actions(GetWebDriver());

            try
            {
                act.DragAndDrop(From, To).Build().Perform();
            }
            catch (Exception e)
            {
                TestHelper.HandleException("Failed to perform Drag and Drop action.", e);
            }


        }

        public static void DestroyDriver()
        {
            TestLogger.CreateTestStep("Selenium Driver Destroyed");
            Driver.Quit();
            Driver = null;
        }

        public static string GetCurrentUrl()
        {
            return Driver.Url;
        }

        public static IWebElement GetElement(By locator)
        {
            return Driver.FindElement(locator);
        }

        public static IReadOnlyCollection<IWebElement> GetElements(By locator)
        {
            return Driver.FindElements(locator);
        }

        public static IWebDriver GetWebDriver()
        {
            return Driver;
        }

        public static void GoToUrl(string Url)
        {
            Driver.Navigate().GoToUrl(Url);
        }

        public void Refresh()
        {
            Driver.Navigate().Refresh();
        }

        public static void HoverOverElement(string ElementXPath)
        {
            try
            {
                IWebElement UserBoard = GetWebDriver().FindElement(By.XPath(ElementXPath));
                Actions action = new Actions(GetWebDriver());
                action.MoveToElement(UserBoard).Perform();
            }
            catch (Exception e)
            {
                string ErrorMessage = string.Format("Failed hovering over element");
                TestHelper.HandleException(ErrorMessage, e);
            }
        }

        public static void Initialise(string browser)
        {
            browser = browser.ToLower();

            switch(browser)
            {
                case "chrome":
                    {
                        Driver = new ChromeDriver();
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
                    throw new ArgumentException("Browser choice not set or choice incorrect: " + browser);
            }

            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("http://www.trello.com");
        }
    }
}