using OpenQA.Selenium;
using System;
using training.automation.common.selenium.elements.common;
using training.automation.common.Tests;
using training.automation.common.utilities;

namespace training.automation.common.Selenium.Elements
{
    public class InputBox : Element
    {
        public InputBox(By locator, String elementName, String pageName) : base(locator, elementName, pageName) { }

        public void ClearText()
        {
            try
            {
                IWebElement element = GetWebElement(true, true);
                element.Clear();
            }
            catch (Exception e)
            {
                HandleException("Clear Text", e);
            }
        }

        public void InputText(String text)
        {
            String stepDescription = String.Format("Input Text '{0}' into", text);

            TestLogger.CreateTestStep(stepDescription, name, pageName);

            int retries = 0;
            int maxRetries = 10;
            bool sentKeysSuccess = false;
            try
            { 
                while (!sentKeysSuccess)
                {
                    if (retries >= 10)
                    {
                        throw new Exception("Tried to input text too many times");
                    }

                    IWebElement element = GetWebElement(true, true);
                    element.SendKeys(text);

                    if (element.GetAttribute("value").Equals(""))
                    {
                        sentKeysSuccess = false;
                        retries++;
                        break;
                    }
                    else
                    {
                        sentKeysSuccess = true;
                    }
                }
            }
            catch (Exception e)
            {
                HandleException("Input Text", e);
            }
        }
    }
}