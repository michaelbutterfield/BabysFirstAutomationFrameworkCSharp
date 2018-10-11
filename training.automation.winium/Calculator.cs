using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using training.automation.common.utilities;
using training.automation.common.Utilities;
using training.automation.winium.Application;
using Is = NHamcrest.Is;

namespace training.automation.winium
{
    [TestClass]
    public class Calculator
    {
        [OneTimeSetUp]
        public void Initialise()
        {
            WiniumHelper.Initialise();
        }

        [SetUp]
        public void ResetCalculator()
        {
            DesktopApplication.mainPage.OpenNavigation.AssertExists();
            DesktopApplication.mainPage.OpenNavigation.Click();
            DesktopApplication.navigationPane.StandardCalculator.AssertExists();
            DesktopApplication.navigationPane.StandardCalculator.Click();
            DesktopApplication.mainPage.EqualsButton.Click();

            try
            {
                WiniumHelper.GetWiniumDriver().FindElementByName("Standard Calculator mode").Equals("Standard Calculator mode");
            }
            catch (Exception e)
            {
                TestHelper.HandleException("Calculator has not been set to standard mode.", e, false);
            }
        }

        [Test]
        public void SimpleAddition()
        {
            //Given the calculators open
            DesktopApplication.mainPage.PositiveNegative.AssertExists();
            Console.WriteLine("Application 'Calculator' is open");
            TestHelper.WriteToConsole("Application 'Calculator' is open");

            //When I enter 2+2
            DesktopApplication.mainPage.Two.Click();
            DesktopApplication.mainPage.Plus.Click();
            DesktopApplication.mainPage.Two.Click();
            DesktopApplication.mainPage.EqualsButton.Click();

            Console.WriteLine("2+2= has been entered successfully");
            TestHelper.WriteToConsole("2+2= has been entered successfully");

            //Then the answer will be 4
            TestHelper.AssertThat(WiniumHelper.GetWiniumDriver().FindElementByName("Display is 4").GetAttribute("Name"), Is.EqualTo("Display is 4"), "Asserting that the calculation adds up the correct result of 4");

        }

        [Test]
        public void Log10()
        {
            //Given I change the caluclator to scientific
            DesktopApplication.mainPage.OpenNavigation.AssertExists();
            DesktopApplication.mainPage.OpenNavigation.Click();
            DesktopApplication.navigationPane.ScientificCalculator.AssertExists();
            DesktopApplication.navigationPane.ScientificCalculator.Click();

            //When I enter log ten
            DesktopApplication.mainPage.One.Click();
            DesktopApplication.mainPage.Zero.Click();
            DesktopApplication.mainPage.Log.Click();

            //The answer will be one
            TestHelper.AssertThat(WiniumHelper.GetWiniumDriver().FindElementByName("Expression is log(10)").GetAttribute("Name"), Is.EqualTo("Expression is log(10)"), "Assert that the answer to log(10) is 1");
        }
    }
}
