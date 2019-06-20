using TechTalk.SpecFlow;
using training.automation.appium.Application;

namespace training.automation.appium.Test.StepDefinitions.Chrome
{
    [Binding]
    public class AccountLogInSteps
    {
        [When(@"I complete the account login page")]
        public static void ICompleteTheAccountLoginPage()
        {
            MobileApp.AccountLogInPage.NoThanks.WaitUntilExists();
            MobileApp.AccountLogInPage.NoThanks.Click();
        }
    }
}
