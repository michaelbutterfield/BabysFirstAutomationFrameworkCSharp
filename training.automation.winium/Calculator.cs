using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using training.automation.common.Tests;
using training.automation.common.Utilities;
using training.automation.winium.Application;
using training.automation.winium.Utilities;
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
            TestLogger.Initialise();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            WiniumHelper.DestroyDriver();
            TestLogger.Close();
        }

        [SetUp]
        public void ResetCalculator()
        {
            DesktopApplication.MainPage.OpenNavigation.AssertExists();
            DesktopApplication.MainPage.OpenNavigation.Click();
            DesktopApplication.NavigationPane.StandardCalculator.AssertExists();
            DesktopApplication.NavigationPane.StandardCalculator.Click();
            DesktopApplication.MainPage.EqualsButton.Click();

            try
            {
                WiniumHelper.GetWiniumDriver().FindElementByName("Standard Calculator mode").Equals("Standard Calculator mode");
            }
            catch (Exception e)
            {
                TestHelper.HandleException("Calculator has not been set to standard mode.", e);
            }
        }

        [Test]
        public void SimpleAddition()
        {
            //Given the calculators open
            DesktopApplication.MainPage.PositiveNegative.AssertExists();
            Console.WriteLine("Application 'Calculator' is open");
            TestHelper.WriteToConsole("Application 'Calculator' is open");

            //When I enter 2+2
            DesktopApplication.MainPage.Two.Click();
            DesktopApplication.MainPage.Plus.Click();
            DesktopApplication.MainPage.Two.Click();
            DesktopApplication.MainPage.EqualsButton.Click();

            Console.WriteLine("2+2= has been entered successfully");
            TestHelper.WriteToConsole("2+2= has been entered successfully");

            //Then the answer will be 4
            TestHelper.AssertThat(WiniumHelper.GetWiniumDriver().FindElementByName("Display is 4").GetAttribute("Name"), Is.EqualTo("Display is 4"), "Asserting that the calculation adds up the correct result of 4");

        }

        [Test]
        public void Log10()
        {
            //Given I change the caluclator to scientific
            DesktopApplication.MainPage.OpenNavigation.AssertExists();
            DesktopApplication.MainPage.OpenNavigation.Click();

            DesktopApplication.NavigationPane.ScientificCalculator.AssertExists();
            DesktopApplication.NavigationPane.ScientificCalculator.Click();

            //When I enter log ten
            DesktopApplication.MainPage.One.Click();
            DesktopApplication.MainPage.Zero.Click();
            DesktopApplication.MainPage.Log.Click();

            //The answer will be one
            TestHelper.AssertThat(WiniumHelper.GetWiniumDriver().FindElementByName("Expression is log(10)").GetAttribute("Name"), Is.EqualTo("Expression is log(10)"), "Assert that the answer to log(10) is 1");
        }
    }
}
