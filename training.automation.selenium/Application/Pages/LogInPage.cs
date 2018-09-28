using OpenQA.Selenium;
using training.automation.common.Pages;
using training.automation.common.Selenium.Elements;

namespace training.automation.selenium.Application.Pages
{
    public class LogInPage : Page
    { 
        public Link createAnAccount;
        public InputBox emailAddress;
        public Button logInButton;
        public InputBox password;

        public LogInPage() : base("LogInPage") { BuildPage(); }

        private void BuildPage()
        {
            createAnAccount = new Link(By.XPath("//*[@id=\"signup\"]"), "Create An Account Link", name);
            emailAddress = new InputBox(By.XPath("//*[@id=\"user\"]"), "Email Address Input Box", name);
            logInButton = new Button(By.XPath("//*[@id=\"login\"]"), "Log In Button", name);
            password = new InputBox(By.XPath("//*[@id=\"password\"]"), "Password Input Box", name);
        }
    }
}
