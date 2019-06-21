using OpenQA.Selenium;

namespace training.automation.winium.Common.Winium.Elements
{
    using Common;

    public class Container : Element
    {
        public Container(By myLocator, string elementName, string pageName) : base(myLocator, elementName, pageName) { }
    }
}
