using OpenQA.Selenium;
using System;
using training.automation.common.utilities;
using training.automation.common.Utilities;

namespace training.automation.common.Winium.Elements.Common
{
    class Element
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

        //public void assertAttributeContains(String attribute, String expectedText)
        //{
        //    String stepDescription = String.Format("Assert Element '%1$s' Attribute '%2$s' Contains '%3$s'", name, attribute, expectedText);

        //    String actualText = getAttribute(attribute);
        //    //TestHelper.assertThat(actualText, containsString(expectedText), stepDescription);
        //}

        //public void assertAttributeEquals(String attributeName, String expectedAttributeValue)
        //{
        //    String stepDescription = String.format("Assert Element '%1$s' Attribute '%2$s' Equals '%3$s'", name, attributeName, expectedAttributeValue);

        //    String actualAttributeValue = getAttribute(attributeName);
        //    TestHelper.assertThat(actualAttributeValue, is (equalTo(expectedAttributeValue)), stepDescription);
        //}

        //public void assertDoesNotExist()
        //{
        //    String stepDescription = "Assert Element Does Not Exists";
        //    TestHelper.assertThat(exists(), is (false), stepDescription);
        //}

        //public void assertExists()
        //{
        //    String stepDescription = "Assert Element Exists '%1$s' on page '%2$s'";
        //    stepDescription = String.format(stepDescription, name, pageName);
        //    WebElement element = null;

        //    try
        //    {
        //        element = WiniumDriverHelper.getElement(locator);
        //    }
        //    catch (Exception e)
        //    {
        //        handleException(stepDescription, e);
        //    }
        //    finally
        //    {
        //        TestHelper.assertThat(element, is (notNullValue()), stepDescription);
        //    }
        //}

        public void AttemptClick(Boolean throwNoSuchElementException)
        {
            Click("Attempt Click", 5, throwNoSuchElementException);
        }

        public void Click()
        {
            Click("Click", 5, false);
        }

        //public Boolean exists()
        //{
        //    return WiniumDriverHelper.getElements(locator).size() > 0;
        //}

        public String GetAttribute(String attribute)
        {
            //String actionName = "Get Attribute' '" + attribute;

            String attributeValue = "";

            try
            {
                attributeValue = WiniumDriverHelper.GetElement(locator).GetAttribute(attribute);
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
        //            TestHelper.handleException(message, new Throwable(message), true);
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
                    WiniumDriverHelper.GetElement(locator);
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
            String errorMessage = "Action '%1$s' Failed";
            errorMessage = String.Format(errorMessage, action, name, pageName);

            TestHelper.HandleException(errorMessage, e, true);
        }

        private void Click(String clickType, int maxRetry, Boolean throwNoSuchElementException)
        {
            int retries = 0;

            while (retries++ < maxRetry)
            {
                try
                {
                    WiniumDriverHelper.GetElement(locator).Click();
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
