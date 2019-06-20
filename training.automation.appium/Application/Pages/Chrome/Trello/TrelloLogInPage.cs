using OpenQA.Selenium;
using training.automation.common.Appium.Elements;
using training.automation.common.Page;

namespace training.automation.appium.Application.Pages.Chrome.Trello
{
    public class TrelloLogInPage : Page
    {
        public TrelloLogInPage() : base("Trello Splash Page") { BuildPage(); }

        public InputBox Email;
        public InputBox Password;
        public Button LogIn;
        public Button ForgotPassword;

        private void BuildPage()
        {
            Email = new InputBox(By.XPath("//input[@type='email']"), "Email Input", name);
            Password = new InputBox(By.XPath("//input[@type='password']"), "Password Input", name);
            LogIn = new Button(By.XPath("//input[@id='login']"), "Log In", name);
            ForgotPassword = new Button(By.XPath("//a[@href='/forgot']"), "Forgot your password?", name);
        }

    }
}
