using System;
using TechTalk.SpecFlow;

namespace training.automation.winium.Test.CSharp.StepDefinitions
{
    using Application;
    using common.Utilities;
    using Utilities;

    [Binding]
    public class CalculatorSteps
    {
        [Given]
        public void I_change_the_calculator_to_scientific()
        {
            DesktopApplication.MainPage.OpenNavigation.Click();
            DesktopApplication.NavigationPane.ScientificCalculator.Click();
        }

        [When]
        public void I_enter_log_ten()
        {
            DesktopApplication.MainPage.One.Click();
            DesktopApplication.MainPage.Zero.Click();
            DesktopApplication.MainPage.Log.Click();
        }

        [When]
        public void I_enter_two_plus_two()
        {
            DesktopApplication.MainPage.Two.Click();
            DesktopApplication.MainPage.Plus.Click();
            DesktopApplication.MainPage.Two.Click();
            DesktopApplication.MainPage.EqualsButton.Click();
        }

        [Given]
        public static void I_reset_the_calculator()
        {
            DesktopApplication.MainPage.OpenNavigation.Click();
            DesktopApplication.NavigationPane.StandardCalculator.Click();
            DesktopApplication.MainPage.EqualsButton.Click();

            try
            {
                WiniumHelper.GetWiniumDriver().FindElementByName("Standard Calculator mode");
            }
            catch (Exception e)
            {
                TestHelper.HandleException("Calculator has not been set to standard mode.", e);
            }
        }

        [Then]
        public void the_answer_will_be_P0(int expected)
        {
            DesktopApplication.MainPage.AssertAnswerIs(expected);
        }

        [Given]
        public void the_calculator_is_open()
        {
            DesktopApplication.MainPage.PositiveNegative.WaitUntilExists();
        }
    }
}
