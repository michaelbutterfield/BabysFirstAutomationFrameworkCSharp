using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using training.automation.common.utilities;
using training.automation.common.Utilities;
using training.automation.winium.Application;

namespace training.automation.winium
{
    [TestClass]
    public class Calculator
    {
        [OneTimeSetUp]
        public void Initialise()
        {
            WiniumDriverHelper.Initialise("x", 1);

            //DesktopApplication.mainPage.OpenNavigation.AssertExists();
            DesktopApplication.mainPage.OpenNavigation.Click();
            //DesktopApplication.navigationPane.StandardCalculator.AssertExists();
            DesktopApplication.navigationPane.StandardCalculator.Click();
            DesktopApplication.mainPage.EqualsButton.Click();

            try
            {
                WiniumDriverHelper.GetWiniumDriver().FindElementByName("Standard Calculator mode").Equals("Standard Calculator mode");
            }
            catch (Exception e)
            {
                TestHelper.HandleException("Calculator has not been set to standard mode.", e, false);
            }
        }

        [Test]
        public void InitialiseTest()
        {

        }
    }
}
