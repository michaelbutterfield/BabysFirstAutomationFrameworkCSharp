using OpenQA.Selenium;
using training.automation.common.Appium.Elements;
using training.automation.common.Page;

namespace training.automation.appium.Application.Pages.Chrome.Trello
{
    public class TrelloSplashPage : Page
    {
        public Button Home { get; private set; }
        public Button LogIn { get; private set; }

        public TrelloSplashPage() : base("Trello Splash Page") { BuildPage(); }

        private void BuildPage()
        {
            Home = new Button(By.XPath("//a[@href='/home']"), "Home Logo", name);
            LogIn = new Button(By.XPath("//a[@href='/login']"), "Log In", name);
        }
    }
}
