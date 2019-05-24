using NHamcrest;
using System;
using TechTalk.SpecFlow;
using training.automation.common.Utilities;
using training.automation.winium.Application;
using training.automation.winium.Utilities;

namespace training.automation.winium.Test.CSharp.StepDefinitions
{
    [Binding]
    public class CalculatorSteps
    {
        [Given]
        public void the_calculator_is_open()
        {
            DesktopApplication.MainPage.PositiveNegative.WaitUntilExists();
            DesktopApplication.MainPage.PositiveNegative.AssertExists();
        }

        [When]
        public void I_enter_two_plus_two()
        {
            DesktopApplication.MainPage.Two.Click();
            DesktopApplication.MainPage.Plus.Click();
            DesktopApplication.MainPage.Two.Click();
            DesktopApplication.MainPage.EqualsButton.Click();
        }

        [Then]
        public void the_answer_will_be_P0(int p0)
        {
            string Answer = WiniumHelper.GetWiniumDriver().FindElementByName("Display is 4").GetAttribute("Name");
            string ExpectedAnswer = "Display is 4";
            TestHelper.AssertThat(Answer, Is.EqualTo(ExpectedAnswer), "Asserting that the calculation adds up the correct result of 4");
        }

        [Given]
        public void I_change_the_calculator_to_scientific()
        {
            DesktopApplication.MainPage.OpenNavigation.AssertExists();
            DesktopApplication.MainPage.OpenNavigation.Click();

            DesktopApplication.NavigationPane.ScientificCalculator.AssertExists();
            DesktopApplication.NavigationPane.ScientificCalculator.Click();
        }

        [When]
        public void I_enter_log_ten()
        {
            DesktopApplication.MainPage.One.Click();
            DesktopApplication.MainPage.Zero.Click();
            DesktopApplication.MainPage.Log.Click();
        }

        [Then]
        public void the_answer_will_be_one()
        {
            TestHelper.AssertThat(WiniumHelper.GetWiniumDriver().FindElementByName("Expression is log(10)").GetAttribute("Name"),
                Is.EqualTo("Expression is log(10)"), "Assert that the answer to log(10) is 1");
        }

        [Given]
        public static void I_reset_the_calculator()
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
    }
}
