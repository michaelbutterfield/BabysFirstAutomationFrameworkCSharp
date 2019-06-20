using OpenQA.Selenium;
using training.automation.common.Appium.Elements.Common;
using training.automation.common.Utilities;

namespace training.automation.common.Appium.Elements
{
    public class Text : Element
    {
        public Text(By myLocator, string elementName, string pageName) : base(myLocator, elementName, pageName) { }

        public string GetElementText(By locator)
        {
            return AppiumHelper.GetDriver().FindElement(locator).GetAttribute("Text");
        }
    }
}
