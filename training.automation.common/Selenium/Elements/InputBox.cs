﻿using OpenQA.Selenium;
using System;
using training.automation.common.selenium.elements.common;
using training.automation.common.Tests;
using training.automation.common.utilities;

namespace training.automation.common.Selenium.Elements
{
    public class InputBox : Element
    {
        public InputBox(By locator, String elementName, String pageName) : base(locator, elementName, pageName) { }

        public void Clear()
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

        public void SendKeys(string text)
        {
            string stepDescription = string.Format("Input Text '{0}' into element {1} on page {2}", text, name, pageName);

            TestLogger.CreateTestStep(stepDescription);

            int retries = 0;
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