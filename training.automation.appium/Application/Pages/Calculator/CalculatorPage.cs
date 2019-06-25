using OpenQA.Selenium;
using training.automation.common.Appium.Elements;
using training.automation.common.Page;

namespace training.automation.appium.Application.Pages.Calculator
{
    public class CalculatorPage : Page
    {
        public Button Advanced { get; private set; }
        public Button Delete { get; private set; }
        public Button Divide { get; private set; }
        public Button Eight { get; private set; }
        public Button Equals { get; private set; }
        public Button Five { get; private set; }
        public Text Fomula { get; private set; }
        public Button Four { get; private set; }
        public Button Minus { get; private set; }
        public Button Nine { get; private set; }
        public Button One { get; private set; }
        public Button Plus { get; private set; }
        public Button Point { get; private set; }
        public Text Result { get; private set; }
        public Button Seven { get; private set; }
        public Button Six { get; private set; }
        public Button Three { get; private set; }
        public Button Times { get; private set; }
        public Button Two { get; private set; }
        public Button Zero { get; private set; }

        public CalculatorPage() : base("Calculator Page") { BuildPage(); }

        private void BuildPage()
        {
            Advanced = new Button(By.Id("pad_advanced"), "Advanced", name);
            Delete = new Button(By.Id("del"), "Delete", name);
            Divide = new Button(By.Id("op_div"), "Divide", name);
            Eight = new Button(By.Id("digit_8"), "Number 8", name);
            Equals = new Button(By.Id("eq"), "Equals", name);
            Five = new Button(By.Id("digit_5"), "Number 5", name);
            Fomula = new Text(By.Id("Formula"), "Formula", name);
            Four = new Button(By.Id("digit_4"), "Number 4", name);
            Minus = new Button(By.Id("op_sub"), "Subtract", name);
            Nine = new Button(By.Id("digit_9"), "Number 9", name);
            One = new Button(By.Id("digit_1"), "Number 1", name);
            Plus = new Button(By.Id("op_add"), "Add", name);
            Point = new Button(By.Id("dec_point"), "Decimal Point", name);
            Result = new Text(By.Id("Result"), "Result", name);
            Seven = new Button(By.Id("digit_7"), "Number 7", name);
            Six = new Button(By.Id("digit_6"), "Number 6", name);
            Three = new Button(By.Id("digit_3"), "Number 3", name);
            Times = new Button(By.Id("op_mul"), "Multiply", name);
            Two = new Button(By.Id("digit_2"), "Number 2", name);
            Zero = new Button(By.Id("digit_0"), "Number 0", name);
        }
    }
}
