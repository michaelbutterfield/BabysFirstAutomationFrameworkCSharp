using OpenQA.Selenium;

namespace training.automation.common.Appium.Elements
{
    using Common;
    using Utilities;

    public class Text : Element
    {
        public Text(By myLocator, string elementName, string pageName) : base(myLocator, elementName, pageName) { }

        public string GetElementText(By locator)
        {
            return AppiumHelper.GetDriver().FindElement(locator).GetAttribute("Text");
        }
    }
}
