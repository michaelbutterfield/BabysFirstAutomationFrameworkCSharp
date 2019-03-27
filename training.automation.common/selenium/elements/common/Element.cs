using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using training.automation.common.utilities;
using NHamcrest;
using training.automation.common.Tests;

namespace training.automation.common.selenium.elements.common
{
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
            String stepDescription = string.Format("Assert Element '{0}' Exists on page '{1}'", name, pageName);
            IWebElement element = null;

            try
            {
                element = SeleniumHelper.GetElement(locator);
            }
            catch (Exception e)
            {
                HandleException(stepDescription, e);
            }
            finally
            {
                TestHelper.AssertThat(element, Is.NotNull(), stepDescription);
            }
        }

        public bool AssertElementIsNotDisplayed()
        {
            IWebElement element = GetWebElement(false, false);

            if (element != null)
            {
                string error = String.Format("{0} is still displayed. Whoops.", name);

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
            string assertionDescription = String.Format("Assert Element {0} on page {1} is displayed", name, pageName);

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
            string assertionDescription = String.Format("Assert Element {0} Text Contains {1}", name, containsText);

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
            String assertionDescription = String.Format("Clicking {0} on page {1}", name, pageName);

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
            string stepDef = string.Format("Making sure element '{0}' exists on page {1}", name, pageName);

            TestLogger.CreateTestStep(stepDef);

            return SeleniumHelper.GetElements(locator).Count() > 0;
        }

        public String GetElementAttribute(String attributeName)
        {
            String assertionDescription = String.Format("Getting attribute {0} from element {1} on page {2}", attributeName, name, pageName);


            TestLogger.CreateTestStep(assertionDescription);

            IWebElement element = GetWebElement(false, true);

            return element.GetAttribute(attributeName);
        }

        public int GetElementCount()
        {
            return SeleniumHelper.GetWebDriver().FindElements(locator).Count();
        }

        public String GetElementText()
        {
            string assertionDesc = string.Format("Getting element text from element {0} on page {1}", name, pageName);

            String elementText = null;

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

        public String GetElementValue()
        {
            IWebElement element = GetWebElement(false, true);

            return element.GetAttribute("value");
        }

        public String GetName()
        {
            return name;
        }

        protected void HandleException(String actionName, Exception ex)
        {
            String errorMessage = String.Format("{0} failed on element \"{1}\" on page \"{2}\"", actionName, name, pageName);

            TestHelper.HandleException(errorMessage, ex, true);
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

        protected IWebElement GetWebElement(Boolean waitUntilClickable, Boolean waitUntilVisible)
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

            int maxRetries = 20;
            int retries = 0;

            while (Exists() == false && retries < maxRetries)
            {
                TestHelper.SleepInSeconds(1);
                retries++;
            }

            if (Exists() == false)
            {
                string ErrorMessage = string.Format("Failed waiting for element to exist. Element: {0} -- Element Page: {1}", name, pageName);

                TestHelper.HandleException(ErrorMessage, new SystemException(ErrorMessage), true);
            }
        }
    }
}
