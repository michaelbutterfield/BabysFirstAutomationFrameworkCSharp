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

        public static void BuildAndPerformAction(string ActionToPerform)
        {
            Actions act = new Actions(SeleniumHelper.GetWebDriver());

            if (ActionToPerform.ToLower().Equals("tododoing"))
            {
                IWebElement From = SeleniumHelper.GetWebDriver().FindElement(By.XPath("//*[@id=\"board\"]/div[1]/div/div[2]/a[1]/div[3]/span"));
                IWebElement To = SeleniumHelper.GetWebDriver().FindElement(By.XPath("//*[@id=\"board\"]/div[2]/div/div[1]/div[1]"));

                try
                {
                    act.DragAndDrop(From, To).Build().Perform();
                    Counter.CardsMoved++;
                }
                catch (Exception e)
                {
                    Counter.CardsMoved--;
                    TestHelper.HandleException("Couldn't move card from 'To Do' to 'Doing'", e, true);
                }
            }
            else if (ActionToPerform.ToLower().Equals("donedoing"))
            {
                IWebElement From = SeleniumHelper.GetWebDriver().FindElement(By.XPath("//*[@id=\"board\"]/div[3]/div/div[2]/a[2]/div[3]/span"));
                IWebElement To = SeleniumHelper.GetWebDriver().FindElement(By.XPath("//*[@id=\"board\"]/div[2]/div/div[1]/div[1]"));

                try
                {
                    act.DragAndDrop(From, To).Build().Perform();
                    Counter.CardsMoved++;
                }
                catch (Exception e)
                {
                    Counter.CardsMoved--;
                    TestHelper.HandleException("Couldn't move card from 'To Do' to 'Doing'", e, true);
                }
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
