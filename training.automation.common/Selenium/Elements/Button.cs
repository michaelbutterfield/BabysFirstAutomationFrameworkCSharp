using OpenQA.Selenium;
using System;
using training.automation.common.selenium.elements.common;

namespace training.automation.common.Selenium.Elements
{
    public class Button : Element
    {
        public Button(By myLocator, String elementName, String pageName) : base(myLocator, elementName, pageName) { }
    }
}
