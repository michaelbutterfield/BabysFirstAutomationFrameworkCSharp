using OpenQA.Selenium;
using System;
using training.automation.common.Utilities;
using NHamcrest;
using training.automation.common.Tests;
using training.automation.winium.Utilities;

namespace training.automation.winium.Common.Winium.Elements.Common
{
    public class Element
    {
        protected By locator;
        protected string name;
        protected string pageName;

        public Element(By passedLocator, string passedElementName, string passedPageName)
        {
            locator = passedLocator;
            name = passedElementName;
            pageName = passedPageName;
        }

        public void AssertAttributeContains(string attribute, string expectedText)
        {
            string stepDescription = string.Format("Assert Element '{0}' Attribute '{1}' Contains '{2}'", name, attribute, expectedText);

            TestLogger.CreateTestStep(stepDescription);

            string actualText = GetAttribute(attribute);
            TestHelper.AssertThat(actualText, Contains.String(expectedText), stepDescription);
        }

        public void AssertAttributeEquals(string attributeName, string expectedAttributeValue)
        {
            string stepDescription = string.Format("Assert Element '{0}' Attribute '{1}' Equals '{2}'", name, attributeName, expectedAttributeValue);

            TestLogger.CreateTestStep(stepDescription);

            string actualAttributeValue = GetAttribute(attributeName);
            TestHelper.AssertThat(actualAttributeValue, Is.EqualTo(expectedAttributeValue), stepDescription);
        }

        public void AssertExists()
        {
            string stepDescription = "Assert Element Exists '{0}' on page '{1}'";
            stepDescription = string.Format(stepDescription, name, pageName);
            TestLogger.CreateTestStep(stepDescription);
            IWebElement element = null;

            try
            {
                element = WiniumHelper.GetElement(locator);
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

        public void Click()
        {
            string stepDef = string.Format("Clicking on Element '{0}' on page '{1}'", name, pageName);

            TestLogger.CreateTestStep(stepDef);

            GetElement().Click();
        }

        public string GetAttribute(string attribute)
        {
            //string actionName = "Get Attribute' '" + attribute;

            string stepDef = string.Format("Getting Attribute {0}", attribute);

            TestLogger.CreateTestStep(stepDef);

            string attributeValue = "";

            try
            {
                attributeValue = WiniumHelper.GetElement(locator).GetAttribute(attribute);
            }
            catch (Exception e)
            {
                HandleException("Get Attribute", e);
            }

            return attributeValue;
        }

        public IWebElement GetElement()
        {
            return WiniumHelper.GetElement(locator);
        }

        public void WaitUntilExists()
        {
            int maxRetry = 20;
            int retries = 0;

            while (retries++ < maxRetry)
            {
                try
                {
                    WiniumHelper.GetElement(locator);
                }
                catch (NoSuchElementException e)
                {
                    if (retries == maxRetry)
                    {
                        HandleException("Wait Until Exists", e);
                    }
                    else
                    {
                        TestHelper.SleepInSeconds(1);
                        continue;
                    }
                }
                catch (Exception e)
                {
                    HandleException("Wait Until Exists", e);
                }
            }
        }

        protected void HandleException(string actionName, Exception ex)
        {
            string errorMessage = string.Format("{0} failed on element \"{1}\" on page \"{2}\"", actionName, name, pageName);

            TestHelper.HandleException(errorMessage, ex);
        }
    }
}
