using OpenQA.Selenium;
using training.automation.common.selenium.elements.common;

namespace training.automation.common.Selenium.Elements
{
    public class Text : Element
    {
        public Text(By myLocator, string elementName, string pageName) : base(myLocator, elementName, pageName) { }
    }
}
