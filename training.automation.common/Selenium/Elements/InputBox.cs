using OpenQA.Selenium;
using System;
using training.automation.common.selenium.elements.common;

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
            String testStepDescription = String.Format("'Input Text' \"%1$s\" into element '%2$s' on page '%3$s' ", text, name, pageName);

            Console.WriteLine(testStepDescription);

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