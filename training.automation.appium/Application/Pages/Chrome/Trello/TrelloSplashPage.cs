using OpenQA.Selenium;
using training.automation.common.Appium.Elements;
using training.automation.common.Page;

namespace training.automation.appium.Application.Pages.Chrome.Trello
{
    public class TrelloSplashPage : Page
    {
        public TrelloSplashPage() : base("Trello Splash Page") { BuildPage(); }

        public Button LogIn;
        public Button Home;

        private void BuildPage()
        {
            Home = new Button(By.XPath("//a[@href='/home']"), "Home Logo", name);
            LogIn = new Button(By.XPath("//a[@href='/login']"), "Log In", name);
        }
    }
}
