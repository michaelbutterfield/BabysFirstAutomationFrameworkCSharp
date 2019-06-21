using NHamcrest;
using OpenQA.Selenium;
using System;

namespace training.automation.winium.Application.Pages.Calculator
{
    using common.Page;
    using common.Utilities;
    using Common.Winium.Elements;
    using Utilities;

    public class MainPage : Page
    {
        public Container CalculatorResults { get; private set; }
        public Button EqualsButton { get; private set; }
        public Button Log { get; private set; }
        public Button One { get; private set; }
        public Button OpenNavigation { get; private set; }
        public Button Plus { get; private set; }
        public Button PositiveNegative { get; private set; }
        public Button Two { get; private set; }
        public Button Zero { get; private set; }

        public MainPage() : base("Main Page")
        {
            BuildPage();
        }

        public void AssertAnswerIs(int expected)
        {
            try
            {
                string actual = WiniumHelper.GetWiniumDriver().FindElementByName($"Display is {expected}").GetAttribute("Name");
                string expectedAnswer = $"Display is {expected}";
                string stepDef = $"Assert expected outcome: {expectedAnswer} is equal to the actual: {actual}";
                TestHelper.AssertThat(expectedAnswer, Is.EqualTo(actual), stepDef);
            }
            catch(Exception e)
            {
                TestHelper.HandleException("FAILED: Asserting Calculator answer", e);
            }
        }

        private void BuildPage()
        {
            CalculatorResults = new Container(By.Id("CalculatorResults"), "Results Display", name);
            EqualsButton = new Button(By.Id("equalButton"), "=", name);
            Log = new Button(By.Id("logBase10Button"), "Log", name);
            One = new Button(By.Id("num1Button"), "1", name);
            OpenNavigation = new Button(By.Id("TogglePaneButton"), "Open Navigation", name);
            Plus = new Button(By.Id("plusButton"), "+", name);
            PositiveNegative = new Button(By.Id("negateButton"), "Positive Negative", name);
            Two = new Button(By.Id("num2Button"), "2", name);
            Zero = new Button(By.Id("num0Button"), "0", name);
        }
    }
}
