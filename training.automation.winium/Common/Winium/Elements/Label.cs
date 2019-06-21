using OpenQA.Selenium;

namespace training.automation.winium.Common.Winium.Elements
{
    using Common;

    public class Label : Element
    {
        public Label(By myLocator, string elementName, string pageName) : base(myLocator, elementName, pageName) { }
    }
}
