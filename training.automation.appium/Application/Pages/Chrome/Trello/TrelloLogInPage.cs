using OpenQA.Selenium;
using training.automation.common.Appium.Elements;
using training.automation.common.Page;

namespace training.automation.appium.Application.Pages.Chrome.Trello
{
    public class TrelloLogInPage : Page
    {
        public InputBox Email { get; private set; }
        public Button ForgotPassword { get; private set; }
        public Button LogIn { get; private set; }
        public InputBox Password { get; private set; }

        public TrelloLogInPage() : base("Trello Splash Page") { BuildPage(); }

        private void BuildPage()
        {
            Email = new InputBox(By.XPath("//input[@type='email']"), "Email Input", name);
            ForgotPassword = new Button(By.XPath("//a[@href='/forgot']"), "Forgot your password?", name);
            LogIn = new Button(By.XPath("//input[@id='login']"), "Log In", name);
            Password = new InputBox(By.XPath("//input[@type='password']"), "Password Input", name);
        }
    }
}
