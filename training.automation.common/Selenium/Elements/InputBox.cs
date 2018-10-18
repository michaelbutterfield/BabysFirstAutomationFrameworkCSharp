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

            try
            {
                IWebElement element = GetWebElement(true, true);
                element.SendKeys(text);
            }
            catch (Exception e)
            {
                HandleException("Input Text", e);
            }
        }
    }
}