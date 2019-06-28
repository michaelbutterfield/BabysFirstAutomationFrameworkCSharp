using OpenQA.Selenium;
using System;

namespace training.automation.common.Selenium.Elements
{
    using Common;

    public class Label : Element
    {
        public Label(By myLocator, String elementName, String pageName) : base(myLocator, elementName, pageName) { }
    }
}
