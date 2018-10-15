using training.automation.common.Pages;
using training.automation.common.Selenium.Elements;
using OpenQA.Selenium;

namespace training.automation.selenium.Application.Pages
{
    public class HomePage : Page
    {
        public Button logIn;
        public Button signUp;

        public HomePage() : base("HomePage") { BuildPage(); }

        private void BuildPage()
        {
            logIn = new Button(By.XPath("//a[@href='/login?returnUrl=%2F']"), "Log In Button", name);
            signUp = new Button(By.XPath("//a[@href='/signup?returnUrl=%2F']"), "Sign Up Button", name);
        }
    }
}
