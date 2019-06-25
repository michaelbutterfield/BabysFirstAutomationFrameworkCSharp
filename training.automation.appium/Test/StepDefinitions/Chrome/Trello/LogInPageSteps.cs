using TechTalk.SpecFlow;
using training.automation.appium.Application;
using training.automation.common.Utilities.Data;

namespace training.automation.appium.Test.StepDefinitions.Chrome.Trello
{
    [Binding]
    class LogInPageSteps
    {
        [Given]
        public void I_am_on_the_log_in_page()
        {
            MobileApp.TrelloLogInPage.ForgotPassword.WaitUntilExists();
        }

        [When]
        public void I_put_in_the_user_details()
        {
            MobileApp.TrelloLogInPage.Email.SendKeys(TrelloWebData.GetUsername());
            MobileApp.TrelloLogInPage.Password.SendKeys(TrelloWebData.GetPassword());
        }

        [When]
        public void I_click_log_in()
        {
            MobileApp.TrelloLogInPage.LogIn.Click();
        }
    }
}
