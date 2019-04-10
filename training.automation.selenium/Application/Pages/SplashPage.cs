using training.automation.common.Page;
using training.automation.common.Selenium.Elements;
using OpenQA.Selenium;

namespace training.automation.selenium.Application.Pages
{
    public class SplashPage : Page
    {
        public Button LogIn;
        public Button SignUp;

        public SplashPage() : base("Splash Page") { BuildPage(); }

        private void BuildPage()
        {
            LogIn = new Button(By.XPath("//a[@href='/login?returnUrl=%2F']"), "Log In Button", name);
            SignUp = new Button(By.XPath("//a[@href='/signup?returnUrl=%2F']"), "Sign Up Button", name);
        }
    }
}
