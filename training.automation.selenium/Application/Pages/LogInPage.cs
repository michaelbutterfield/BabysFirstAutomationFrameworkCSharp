using OpenQA.Selenium;
using training.automation.common.Pages;
using training.automation.common.Selenium.Elements;

namespace training.automation.selenium.Application.Pages
{
    public class LogInPage : Page
    { 
        public InputBox emailAddress;
        public Link forgotPassword;
        public Button logIn;
        public InputBox password;

        public LogInPage() : base("Log In Page") { BuildPage(); }

        private void BuildPage()
        {
            emailAddress = new InputBox(By.XPath("//*[@id=\"user\"]"), "Email Address Input Box", name);
            forgotPassword = new Link(By.XPath("//a[@href='/forgot']"), "Forgot Password", name);
            logIn = new Button(By.XPath("//*[@id=\"login\"]"), "Log In Button", name);
            password = new InputBox(By.XPath("//*[@id=\"password\"]"), "Password Input Box", name);
        }
    }
}
