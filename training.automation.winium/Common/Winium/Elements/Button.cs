using OpenQA.Selenium;
using System;
using training.automation.winium.Common.Winium.Elements.Common;

namespace training.automation.winium.Common.Winium.Elements
{
    public class Button : Element
    {
        public Button(By myLocator, string elementName, string pageName) : base(myLocator, elementName, pageName) { }
    }
}
