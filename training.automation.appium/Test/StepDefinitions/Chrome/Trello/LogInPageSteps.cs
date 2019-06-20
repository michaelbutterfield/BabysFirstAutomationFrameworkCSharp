using TechTalk.SpecFlow;
using training.automation.appium.Application;
using training.automation.common.Utilities.Data;

namespace training.automation.appium.Test.StepDefinitions.Chrome.Trello
{
    [Binding]
    class LogInPageSteps
    {
        [Given(@"I am on the log in page")]
        public void IAmOnTheLogInPage()
        {
            MobileApp.TrelloLogInPage.ForgotPassword.WaitUntilExists();
        }

        [When(@"I put in the user details")]
        public void IPutInTheUserDetails()
        {
            MobileApp.TrelloLogInPage.Email.SendKeys(TrelloWebData.GetUsername());
            MobileApp.TrelloLogInPage.Password.SendKeys(TrelloWebData.GetPassword());
        }

        [When(@"I click log in")]
        public void IClickLogIn()
        {
            MobileApp.TrelloLogInPage.LogIn.Click();
        }
    }
}
