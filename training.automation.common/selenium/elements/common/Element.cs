using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using NHamcrest;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace training.automation.common.Selenium.Elements.Common
{
    using OpenQA.Selenium.Interactions;
    using Tests;
    using Utilities;

    public class Element
    {
        protected By locator;
        protected string name;
        protected string pageName;

        public Element(By myLocator, string myElementName, string myPageName)
        {
            locator = myLocator;
            name = myElementName;
            pageName = myPageName;
        }

        public void AssertDoesNotExist()
        {
            string assertionDescription = string.Format("Assert Element '{0}' does not exist on {1}", name, pageName);
            TestHelper.AssertThat(Exists(), Is.False(), assertionDescription);
        }

        public void AssertExists()
        {
            string stepDescription = string.Format("Assert Element '{0}' Exists on page '{1}'", name, pageName);
            IWebElement element = null;

            try
            {
                element = SeleniumHelper.GetElement(locator);
            }
            catch (Exception e)
            {
                TestHelper.HandleException(stepDescription, e);
            }
        }

        public bool AssertElementIsNotDisplayed()
        {
            IWebElement element = GetWebElement(false, false);

            if (element != null)
            {
                string error = string.Format("{0} is still displayed. Whoops.", name);

                TestLogger.CreateTestStep(error);

                return false;
            }
            else
            {
                return true;
            }
        }

        public void AssertElementIsDisplayed()
        {
            string assertionDescription = string.Format("Assert Element {0} on page {1} is displayed", name, pageName);

            IWebElement element = null;

            try
            {
                element = GetWebElement(false, true);
            }
            catch (Exception e)
            {
                HandleException("Assert Element is Displayed", e);
            }
            finally
            {
                TestHelper.AssertThat(element, Is.NotNull(), assertionDescription);
            }
        }

        public void AssertElementTextContains(string containsText)
        {
            string assertionDescription = string.Format("Assert Element {0} Text Contains {1}", name, containsText);

            try
            {
                string fullText = GetElementText();
                Console.WriteLine(fullText);
                TestHelper.AssertThat(fullText, Contains.String(containsText), assertionDescription);
            }
            catch (Exception e)
            {
                HandleException(assertionDescription, e);
            }
        }

        public void Click()
        {
            TestLogger.CreateTestStep("Click", name, pageName);
           
            try
            {
                GetWebElement(true, true).Click();
            }
            catch (Exception e)
            {
                HandleException("Click", e);
            }
        }

        public void ClickNoWait()
        {
            string assertionDescription = string.Format("Clicking {0} on page {1}", name, pageName);

            TestLogger.CreateTestStep(assertionDescription);

            try
            {
                GetWebElement(false, false).Click();
            }
            catch (Exception e)
            {
                HandleException("Click", e);
            }
        }

        public bool Exists()
        {
            //string stepDef = string.Format("Asserting element '{0}' exists on page {1}", name, pageName);

            //TestLogger.CreateTestStep(stepDef);

            return SeleniumHelper.GetElements(locator).Count() > 0;
        }

        public string GetElementAttribute(string attributeName)
        {
            string assertionDescription = string.Format("Getting attribute {0} from element {1} on page {2}", attributeName, name, pageName);


            TestLogger.CreateTestStep(assertionDescription);

            IWebElement element = GetWebElement(false, true);

            return element.GetAttribute(attributeName);
        }

        public int GetElementCount()
        {
            return SeleniumHelper.GetWebDriver().FindElements(locator).Count();
        }

        public string GetElementText()
        {
            string assertionDesc = string.Format("Getting element text from element {0} on page {1}", name, pageName);

            string elementText = null;

            try
            {
                elementText = GetWebElement(false, true).ToString();
            }
            catch (Exception e)
            {
                HandleException("Get Element Text", e);
            }

            return elementText;
        }

        public string GetElementValue()
        {
            IWebElement element = GetWebElement(false, true);

            return element.GetAttribute("value");
        }

        public string GetName()
        {
            return name;
        }

        protected void HandleException(string actionName, Exception ex)
        {
            string errorMessage = string.Format("{0} failed on element \"{1}\" on page \"{2}\"", actionName, name, pageName);

            TestHelper.HandleException(errorMessage, ex);
        }

        public void HoverOverElement()
        {
            try
            {
                IWebElement UserBoard = SeleniumHelper.GetWebDriver().FindElement(locator);
                Actions action = new Actions(SeleniumHelper.GetWebDriver());
                action.MoveToElement(UserBoard).Perform();
            }
            catch (Exception e)
            {
                string ErrorMessage = string.Format("Failed hovering over element");
                TestHelper.HandleException(ErrorMessage, e);
            }
        }


        public bool IsEnabled()
        {
            IWebElement element = null;

            element = GetWebElement(true, false);

            if (element != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void JsClick()
        {
            string assertionDesc = string.Format("Javascript click element {0} on page {1}", name, pageName);

            try
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)SeleniumHelper.GetWebDriver();

                executor.ExecuteScript("arguments[0].click();", GetWebElement(true, true));
            }
            catch (Exception e)
            {
                HandleException(assertionDesc, e);
            }
        }

        public void WaitForElementToBeClickable()
        {
            try
            {
                WaitUntilElementToBeClickable();
            }
            catch (Exception e)
            {
                HandleException("Wait For Element To Be Clickable", e);
            }
        }

        public void WaitForElementToVisible()
        {
            try
            {
                WaitUntilElementToBeVisible();
            }
            catch (Exception e)
            {
                HandleException("Wait For Element To Be Visible", e);
            }
        }

        protected IWebElement GetWebElement(bool waitUntilClickable, bool waitUntilVisible)
        {
            if (waitUntilClickable)
            {
                WaitUntilElementToBeClickable();
            }
            else if (waitUntilVisible)
            {
                WaitUntilElementToBeVisible();
            }

            return SeleniumHelper.GetWebDriver().FindElement(locator);
        }

        private void WaitUntilElementToBeClickable()
        {
            WebDriverWait wait = new WebDriverWait(SeleniumHelper.GetWebDriver(), SeleniumHelper.DEFAULT_TIMEOUT);
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        private void WaitUntilElementToBeVisible()
        {
            WebDriverWait wait = new WebDriverWait(SeleniumHelper.GetWebDriver(), SeleniumHelper.DEFAULT_TIMEOUT);
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitUntilExists()
        {
            string assertionDesc = string.Format("Wait until element {0} exists on page {1}", name, pageName);
            TestLogger.CreateTestStep(assertionDesc);

            int MaxRetries = 20;
            int Retries = 0;

            while (Exists() == false && Retries < MaxRetries)
            {
                TestHelper.SleepInSeconds(1);
                Retries++;
            }

            if (Exists() == false)
            {
                string ErrorMessage = string.Format("Failed waiting for element to exist. Element: {0} -- Element Page: {1}", name, pageName);

                TestHelper.HandleException(ErrorMessage, new SystemException(ErrorMessage));
            }
        }
    }
}
