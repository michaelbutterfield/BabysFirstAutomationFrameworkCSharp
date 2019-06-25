using TechTalk.SpecFlow;
using training.automation.appium.Application;
using training.automation.common.Utilities;

namespace training.automation.appium.Test.StepDefinitions.Chrome.Trello
{
    [Binding]
    class SplashPageSteps
    {
        [Given]
        public void I_am_on_the_splash_page()
        {
            AppiumHelper.GoToUrl("http://trello.com");
            MobileApp.TrelloSplashPage.Home.WaitUntilExists();
        }

        [When]
        public void I_click_the_log_in_button()
        {
            MobileApp.TrelloSplashPage.LogIn.Click();
        }


    }
}
