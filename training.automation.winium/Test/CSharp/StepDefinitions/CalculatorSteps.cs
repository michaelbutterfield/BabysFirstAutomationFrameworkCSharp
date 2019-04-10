using NHamcrest;
using TechTalk.SpecFlow;
using training.automation.common.Utilities;
using training.automation.winium.Application;
using training.automation.winium.Utilities;
using training.automation.winium.Winium.Elements;

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
            DesktopApplication.MainPage.One.Click();
            DesktopApplication.MainPage.EqualsButton.Click();
        }

        [Then]
        public void the_answer_will_be_P0(int p0)
        {
            string Answer = WiniumHelper.GetWiniumDriver().FindElementByName("Display is 4").GetAttribute("Name");
            string ActualAnswer = "Display is 4";
            TestHelper.AssertThat(Answer, Is.EqualTo(ActualAnswer), "Asserting that the calculation adds up the correct result of 4");
        }
    }
}
