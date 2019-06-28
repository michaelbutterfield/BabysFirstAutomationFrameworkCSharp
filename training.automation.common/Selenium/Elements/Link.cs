using OpenQA.Selenium;
using System;

namespace training.automation.common.Selenium.Elements
{
    using Common;

    public class Link : Element
    {
        public Link(By myLocator, String elementName, String pageName) : base(myLocator, elementName, pageName) { }
    }
}
