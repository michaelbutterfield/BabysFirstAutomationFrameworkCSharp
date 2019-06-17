using OpenQA.Selenium;
using System;
using System.Linq;
using NHamcrest;
using training.automation.common.Tests;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using training.automation.common.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium;

namespace training.automation.common.Appium.Elements.Common
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
            string stepDescription = string.Format("Assert Element '{0}' Exists on page '{1}'", name, pageName);
            AppiumWebElement element = null;

            try
            {
                element = AppiumHelper.GetDriver().FindElement(locator);
            }
            catch (Exception e)
            {
                TestHelper.HandleException(stepDescription, e);
            }
            finally
            {
                TestHelper.AssertThat(element, Is.NotNull(), stepDescription);
            }
        }

        public bool AssertElementIsNotDisplayed()
        {
            IWebElement element = GetElement(false, false);

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

            AppiumWebElement element = null;

            try
            {
                element = GetElement(false, true);
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

     

        public void Click()
        {
            TestLogger.CreateTestStep("Click", name, pageName);
           
            try
            {
                GetElement(true, true).Click();
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
                GetElement(false, false).Click();
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

            return AppiumHelper.FindElements(locator).Count() > 0;
        }

  

        public int GetElementCount()
        {
            return AppiumHelper.GetDriver().FindElements(locator).Count();
        }

       

       

        

        protected void HandleException(string actionName, Exception ex)
        {
            string errorMessage = string.Format("{0} failed on element \"{1}\" on page \"{2}\"", actionName, name, pageName);

            TestHelper.HandleException(errorMessage, ex);
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

        protected AppiumWebElement GetElement(bool waitUntilClickable, bool waitUntilVisible)
        {
            if (waitUntilClickable)
            {
                WaitUntilElementToBeClickable();
            }
            else if (waitUntilVisible)
            {
                WaitUntilElementToBeVisible();
            }

            return AppiumHelper.GetDriver().FindElement(locator);
        }

        private void WaitUntilElementToBeClickable()
        {
            WebDriverWait wait = new WebDriverWait(AppiumHelper.GetDriver(), AppiumHelper.DEFAULT_TIMEOUT);
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        private void WaitUntilElementToBeVisible()
        {
            WebDriverWait wait = new WebDriverWait(AppiumHelper.GetDriver(), AppiumHelper.DEFAULT_TIMEOUT);
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

                TestHelper.HandleException(ErrorMessage, new SystemException(ErrorMessage));
            }
        }
    }
}
