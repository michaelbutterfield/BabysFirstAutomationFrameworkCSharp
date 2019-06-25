using training.automation.appium.Application.Pages.Calculator;
using training.automation.appium.Application.Pages.Chrome;
using training.automation.appium.Application.Pages.Chrome.Trello;

namespace training.automation.appium.Application
{
    public class MobileApp
    {
        //App
        public static CalculatorPage CalculatorPage { get; private set; }

        //Chrome
        public static AccountLogInPage AccountLogInPage { get; private set; }
        public static NewTabSplashPage NewTabSplashPage { get; private set; }
        public static TrelloBoardsPage TrelloBoardsPage { get; private set; }
        public static TrelloLogInPage TrelloLogInPage { get; private set; }
        public static TrelloSplashPage TrelloSplashPage { get; private set; }
        public static WelcomeToChromePage WelcomeToChromePage { get; private set; }

        static MobileApp()
        {
            BuildPages();
        }

        private static void BuildPages()
        {
            //App
            CalculatorPage = new CalculatorPage();

            //Chrome
            AccountLogInPage = new AccountLogInPage();
            NewTabSplashPage = new NewTabSplashPage();
            TrelloBoardsPage = new TrelloBoardsPage();
            TrelloLogInPage = new TrelloLogInPage();
            TrelloSplashPage = new TrelloSplashPage();
            WelcomeToChromePage = new WelcomeToChromePage();

        }
    }
}
