using OpenQA.Selenium;
using System;
using training.automation.common.Winium.Elements.Common;

namespace training.automation.common.Winium.Elements
{
    public class Button : Element
    {
        public Button(By myLocator, String elementName, String pageName) : base(myLocator, elementName, pageName) { }
    }
}
