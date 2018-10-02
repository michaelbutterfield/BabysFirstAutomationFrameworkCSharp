using OpenQA.Selenium;
using training.automation.common.Pages;
using training.automation.common.Winium.Elements;

namespace training.automation.winium.Application.Pages.Calculator
{
    public class MainPage : Page
    {
        public Container CalculatorResults;
        public Button EqualsButton;
        public Button Log;
        public Button One;
        public Button OpenNavigation;
        public Button Plus;
        public Button PositiveNegative;
        public Button ScientificCalculator;
        public Button StandardCalculator;
        public Button Two;
        public Button Zero;

        public MainPage() : base("MainPage") { BuildPage(); }

        private void BuildPage()
        {
            CalculatorResults = new Container(By.Id("CalculatorResults"), "Results Display", name);
            EqualsButton = new Button(By.Id("equalButton"), "= Button", name);
            Log = new Button(By.Id("logBase10Button"), "Log Button", name);
            One = new Button(By.Id("num1Button"), "1 Button", name);
            OpenNavigation = new Button(By.Id("TogglePaneButton"), "Open Navigation", name);
            Plus = new Button(By.Id("plusButton"), "+ Button", name);
            PositiveNegative = new Button(By.Id("negateButton"), "Positive Negative Button", name);
            Two = new Button(By.Id("num2Button"), "2 Button", name);
            Zero = new Button(By.Id("num0Button"), "0 Button", name);
        }
    }
}
