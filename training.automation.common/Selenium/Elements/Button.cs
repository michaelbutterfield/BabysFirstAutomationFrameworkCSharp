using OpenQA.Selenium;
using System;
using training.automation.common.selenium.elements.common;

namespace training.automation.common.Selenium.Elements
{
    public class Button : Element
    {
        public Button(By myLocator, string elementName, string pageName) : base(myLocator, elementName, pageName) { }
    }
}
