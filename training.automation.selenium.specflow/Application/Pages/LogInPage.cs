using OpenQA.Selenium;

namespace training.automation.specflow.Application.Pages
{
    using common.Page;
    using common.Selenium.Elements;

    public class LogInPage : Page
    { 
        public InputBox EmailAddress { get; private set; }
        public Link ForgotPassword { get; private set; }
        public Text ErrorMessage { get; private set; }
        public Button LogIn { get; private set; }
        public InputBox Password { get; private set; }

        public LogInPage() : base("Log In") { BuildPage(); }

        private void BuildPage()
        {
            EmailAddress = new InputBox(By.XPath("//*[@id=\"user\"]"), "Email Address Input Box", name);
            ForgotPassword = new Link(By.XPath("//a[@href='/forgot']"), "Forgot Password", name);
            ErrorMessage = new Text(By.XPath("//p[@class=\"error-message\"]"), "Error Message", name);
            LogIn = new Button(By.XPath("//*[@id=\"login\"]"), "Log In Button", name);
            Password = new InputBox(By.XPath("//*[@id=\"password\"]"), "Password Input Box", name);
        }
    }
}
