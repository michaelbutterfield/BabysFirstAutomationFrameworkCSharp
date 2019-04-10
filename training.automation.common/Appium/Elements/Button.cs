using OpenQA.Selenium;
using training.automation.common.selenium.elements.common;

namespace training.automation.common.Appium.Elements
{
    public class Button : Element
    {
        public Button(By myLocator, string elementName, string pageName) : base(myLocator, elementName, pageName) { }
    }
}
