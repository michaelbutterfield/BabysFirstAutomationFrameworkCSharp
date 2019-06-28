using OpenQA.Selenium;

namespace training.automation.specflow.Application.Pages
{
    using common.Page;
    using common.Selenium.Elements;

    public class SplashPage : Page
    {
        public Button LogIn { get; private set; }
        //public Button SignUp;

        public SplashPage() : base("Splash Page") { BuildPage(); }

        private void BuildPage()
        {
            LogIn = new Button(By.XPath("//a[@href='/login']"), "Log In Button", name);
            //SignUp = new Button(By.XPath("//a[@href='/signup']"), "Sign Up Button", name);
        }
    }
}
