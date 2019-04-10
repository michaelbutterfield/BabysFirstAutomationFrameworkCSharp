using OpenQA.Selenium;
using System;
using training.automation.common.selenium.elements.common;

namespace training.automation.winium.Winium.Elements
{
    public class Label : Element
    {
        public Label(By myLocator, String elementName, String pageName) : base(myLocator, elementName, pageName) { }
    }
}
