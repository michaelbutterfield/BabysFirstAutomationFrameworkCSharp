using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using training.automation.specflow.Application.Data;

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
            Actions act = new Actions(SeleniumHelper.GetWebDriver());

            IWebElement From = GetWebDriver().FindElement(startLocation);
            IWebElement To = GetWebDriver().FindElement(endLocation);

            try
            {
                act.DragAndDrop(From, To).Build().Perform();
            }
            catch (Exception e)
            {
                TestHelper.HandleException("Failed to perform Drag and Drop action. Stack trace: " + e, e, true);
            }
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
            IWebElement userBoard = SeleniumHelper.GetWebDriver().FindElement(By.XPath(ElementXPath)); //TODO Create hover method with all this shit
            Actions action = new Actions(SeleniumHelper.GetWebDriver());
            action.MoveToElement(userBoard).Perform();
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
                    throw new System.ArgumentException("Browser choice not set or choice incorrect: " + browser);
            }

            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("http://www.trello.com");
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
