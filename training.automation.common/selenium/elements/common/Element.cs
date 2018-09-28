using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using training.automation.common.utilities;

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

        public bool AssertElementIsNotDisplayed()
        {
            IWebElement element = null;

            element = GetWebElement(false, false);

            if (element != null)
            {
                string error = String.Format("{0} is still displayed. Whoops.", name);
                Console.WriteLine(error);
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

           Console.WriteLine(assertionDescription);

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
                //TODO create assert that in test helper
                //TestHelper.AssertThat(element, is(notNullValue()), assertionDescription);
            }
        }

        public void AssertElementTextContains(string containsText)
        {
            string assertionDescription = String.Format("Assert Element {0} Text Contains {1}", name, containsText);

            Console.WriteLine(assertionDescription);
            try
            {
                //TODO fix the testhelper assert that class
                string fullText = GetElementText();
                Console.WriteLine(fullText);
                //TestHelper.AssertThat(fullText, containsString(containsText), assertionDescription);
            }
            catch (Exception e)
            {
                HandleException(assertionDescription, e);
            }
        }

        public void Click()
        {
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
            try
            {
                GetWebElement(false, false).Click();
            }
            catch (Exception e)
            {
                HandleException("Click", e);
            }
        }

        public String GetElementAttribute(String attributeName)
        {
            IWebElement element = GetWebElement(false, true);
            return element.GetAttribute(attributeName);
        }

        public int GetElementCount()
        {
            return SeleniumDriverHelper.GetWebDriver().FindElements(locator).Count();
        }

        public String GetElementText()
        {
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
            String errorMessage = String.Format("%1$s failed on element \"%2$s\" on page \"%3$s\"", actionName, name, pageName);
            TestHelper.HandleException(errorMessage, ex, true);
        }

        public void JsClick()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)SeleniumDriverHelper.GetWebDriver();
            executor.ExecuteScript("arguments[0].click();", GetWebElement(true, true));
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

            return SeleniumDriverHelper.GetWebDriver().FindElement(locator);
        }

        private void WaitUntilElementToBeClickable()
        {
            WebDriverWait wait = new WebDriverWait(SeleniumDriverHelper.GetWebDriver(), SeleniumDriverHelper.DEFAULT_TIMEOUT);
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        private void WaitUntilElementToBeVisible()
        {
            WebDriverWait wait = new WebDriverWait(SeleniumDriverHelper.GetWebDriver(), SeleniumDriverHelper.DEFAULT_TIMEOUT);
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}
