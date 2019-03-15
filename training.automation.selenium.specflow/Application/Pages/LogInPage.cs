using OpenQA.Selenium;
using training.automation.common.Pages;
using training.automation.common.Selenium.Elements;

namespace training.automation.specflow.Application.Pages
{
    public class LogInPage : Page
    { 
        public InputBox EmailAddress;
        public Link ForgotPassword;
        public Text ErrorMessage;
        public Button LogIn;
        public InputBox Password;

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
