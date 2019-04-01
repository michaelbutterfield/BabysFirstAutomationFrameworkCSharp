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
        protected String name;
        protected String pageName;

        public Element(By passedLocator, String passedElementName, String passedPageName)
        {
            locator = passedLocator;
            name = passedElementName;
            pageName = passedPageName;
        }

        public void AssertAttributeContains(String attribute, String expectedText)
        {
            String stepDescription = String.Format("Assert Element '{0}' Attribute '{1}' Contains '{2}'", name, attribute, expectedText);

            TestLogger.CreateTestStep(stepDescription);

            String actualText = GetAttribute(attribute);
            TestHelper.AssertThat(actualText, Contains.String(expectedText), stepDescription);
        }

        public void AssertAttributeEquals(String attributeName, String expectedAttributeValue)
        {
            String stepDescription = String.Format("Assert Element '{0}' Attribute '{1}' Equals '{2}'", name, attributeName, expectedAttributeValue);

            TestLogger.CreateTestStep(stepDescription);

            String actualAttributeValue = GetAttribute(attributeName);
            TestHelper.AssertThat(actualAttributeValue, Is.EqualTo(expectedAttributeValue), stepDescription);
        }

        //public void assertDoesNotExist()
        //{
        //    String stepDescription = "Assert Element Does Not Exists";
        //    TestHelper.AssertThat(Exists(), Is.False(), stepDescription);
        //}

        public void AssertExists()
        {
            String stepDescription = "Assert Element Exists '{0}' on page '{1}'";
            stepDescription = String.Format(stepDescription, name, pageName);
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

        public void AttemptClick(Boolean throwNoSuchElementException)
        {
            Click("Attempt Click", 5, throwNoSuchElementException);
        }

        public void Click()
        {
            string stepDef = String.Format("Clicking on Element '{0}' on page '{1}'", name, pageName);

            TestLogger.CreateTestStep(stepDef);

            Click("Click", 5, false);
        }

        //public Boolean exists()
        //{
        //    return WiniumDriverHelper.getElements(locator).size() > 0;
        //}

        public String GetAttribute(String attribute)
        {
            //String actionName = "Get Attribute' '" + attribute;

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

        //public List<IWebElement> GetChildElements()
        //{
        //    return GetChildElementsByXpath("./*");
        //}

        //public List<IWebElement> GetChildElementsByXpath(String xpath)
        //{
        //    return WiniumDriverHelper.GetElement(locator).FindElements(By.XPath(xpath));
        //}

        //public int GetCount()
        //{
        //    return WiniumDriverHelper.GetElements(locator).size();
        //}

        //public void WaitUntilDoesNotExist()
        //{
        //    int maxRetry = 20;
        //    int retries = 0;

        //    while (retries++ < maxRetry)
        //    {
        //        if (!Exists)
        //        {
        //            break;
        //        }

        //        if (retries == maxRetry)
        //        {
        //            String message = "";
        //            TestHelper.HandleException(message, new Exception(message), true);
        //        }
        //    }
        //}

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

        protected void HandleException(String action, Exception e)
        {
            String errorMessage = "Action '{0}' Failed";
            errorMessage = String.Format(errorMessage, action, name, pageName);

            TestHelper.HandleException(errorMessage, e);
        }

        private void Click(String clickType, int maxRetry, Boolean throwNoSuchElementException)
        {
            int retries = 0;

            while (retries++ < maxRetry)
            {
                try
                {
                    WiniumHelper.GetElement(locator).Click();
                    break;
                }
                catch (NoSuchElementException e)
                {
                    if (clickType.Equals("Attempt Click"))
                    {
                        if (retries == maxRetry &&
                            throwNoSuchElementException)
                        {
                            throw e;
                        }
                        else
                        {
                            TestHelper.SleepInSeconds(1);
                            continue;
                        }
                    }
                    else
                    {
                        if (retries == maxRetry)
                        {
                            HandleException(clickType, e);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                catch (WebDriverException e)
                {
                    // added to try an swallow exception when element exists but is not currently intractable
                    if (e.Message.Contains("NOT CLICK") && retries < maxRetry)
                    {
                        TestHelper.SleepInSeconds(5);
                        continue;
                    }
                    else
                    {
                        HandleException(clickType, e);
                    }
                }
                catch (Exception e)
                {
                    HandleException(clickType, e);
                }
            }
        }
    }
}
