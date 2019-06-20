using OpenQA.Selenium;
using training.automation.common.Appium.Elements;
using training.automation.common.Page;

namespace training.automation.appium.Application.Pages.Calculator
{
    public class CalculatorPage : Page
    {
        public Button Seven;
        public Button Eight;
        public Button Nine;
        public Button Four;
        public Button Five;
        public Button Six;
        public Button One;
        public Button Two;
        public Button Three;
        public Button Point;
        public Button Zero;
        public Button Delete;
        public Button Divide;
        public Button Times;
        public Button Minus;
        public Button Plus;
        public new Button Equals;
        public Text Fomula;
        public Text Result;
        public Button Advanced;

        public CalculatorPage() : base("Calculator Page") { BuildPage(); }

        private void BuildPage()
        {
            Seven = new Button(By.Id("digit_7"), "Number 7", name);
            Eight = new Button(By.Id("digit_8"), "Number 8", name);
            Nine = new Button(By.Id("digit_9"), "Number 9", name); 
            Four = new Button(By.Id("digit_4"), "Number 4", name); 
            Five = new Button(By.Id("digit_5"), "Number 5", name);
            Six = new Button(By.Id("digit_6"), "Number 6", name);
            One = new Button(By.Id("digit_1"), "Number 1", name);
            Two = new Button(By.Id("digit_2"), "Number 2", name);
            Three = new Button(By.Id("digit_3"), "Number 3", name);
            Point = new Button(By.Id("dec_point"), "Decimal Point", name);
            Zero = new Button(By.Id("digit_0"), "Number 0", name);
            Delete = new Button(By.Id("del"), "Delete", name);
            Divide = new Button(By.Id("op_div"), "Divide", name);
            Times = new Button(By.Id("op_mul"), "Multiply", name);
            Minus = new Button(By.Id("op_sub"), "Subtract", name);
            Plus = new Button(By.Id("op_add"), "Add", name);
            Equals = new Button(By.Id("eq"), "Equals", name);
            Fomula = new Text(By.Id("Formula"), "Formula", name);
            Result = new Text(By.Id("Result"), "Result", name);
            Advanced = new Button(By.Id("pad_advanced"), "Advanced", name);
    }
}
}
