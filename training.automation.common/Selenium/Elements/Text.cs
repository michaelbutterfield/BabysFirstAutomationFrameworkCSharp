using OpenQA.Selenium;

namespace training.automation.common.Selenium.Elements
{
    using Common;

    public class Text : Element
    {
        public Text(By myLocator, string elementName, string pageName) : base(myLocator, elementName, pageName) { }
    }
}
