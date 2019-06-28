using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;

namespace training.automation.common.Appium.Elements
{
    using Common;
    using Tests;

    public class InputBox : Element
    {
        public InputBox(By locator, string elementName, string pageName) : base(locator, elementName, pageName) { }

        public void Clear()
        {
            try
            {
                AppiumWebElement element = GetElement(true, true);
                element.Clear();
            }
            catch (Exception e)
            {
                HandleException("Clear Text", e);
            }
        }

        public void SendKeys(string text)
        {
            string stepDescription = string.Format("Input Text '{0}' into element {1} on page {2}", text, name, pageName);

            TestLogger.CreateTestStep(stepDescription);

            try
            { 
                    AppiumWebElement element = GetElement(true, true);
                    element.SendKeys(text);
            }
            catch (Exception e)
            {
                HandleException("Input Text", e);
            }
        }
    }
}