﻿using OpenQA.Selenium;

namespace training.automation.common.Appium.Elements
{
    using Common;

    public class Button : Element
    {
        public Button(By myLocator, string elementName, string pageName) : base(myLocator, elementName, pageName) { }
    }
}
