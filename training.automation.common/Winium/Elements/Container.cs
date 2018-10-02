using OpenQA.Selenium;
using System;
using training.automation.common.Winium.Elements.Common;

namespace training.automation.common.Winium.Elements
{
    public class Container : Element
    {
        public Container(By myLocator, String elementName, String pageName) : base(myLocator, elementName, pageName) { }
    }
}
