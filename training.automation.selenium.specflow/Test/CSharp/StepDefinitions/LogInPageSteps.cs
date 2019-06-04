using TechTalk.SpecFlow;
using training.automation.common.Utilities;
using training.automation.specflow.Application;
using training.automation.specflow.Data;
using Is = NHamcrest.Is;

namespace training.automation.selenium.specflow.Test.CSharp.StepDefinitions
{
    [Binding]
    public sealed class LogInPageSteps
    {
        [Given]
        public void I_Log_In()
        {
            DesktopWebsite.SplashPage.LogIn.Click();
            DesktopWebsite.LogInPage.ForgotPassword.WaitForElementToBeClickable();
            DesktopWebsite.LogInPage.EmailAddress.SendKeys(TrelloWebData.GetUsername());
            DesktopWebsite.LogInPage.Password.SendKeys(TrelloWebData.GetPassword());
            DesktopWebsite.LogInPage.LogIn.Click();

            DesktopWebsite.BoardsPage.PersonalBoards.WaitUntilExists();
        }

        [Given]
        public void I_am_on_the_log_in_page()
        {
            DesktopWebsite.LogInPage.EmailAddress.WaitUntilExists();
            DesktopWebsite.LogInPage.EmailAddress.AssertElementIsDisplayed();
        }

        [Given][When]
        public void I_enter_the_user_details()
        {
            DesktopWebsite.LogInPage.EmailAddress.SendKeys(TrelloWebData.GetUsername());
            DesktopWebsite.LogInPage.Password.SendKeys(TrelloWebData.GetPassword());
        }

        [When]
        public void I_click_log_in()
        {
            DesktopWebsite.LogInPage.LogIn.Click();
        }


        [Then]
        public void I_will_be_logged_in_successfully()
        {
            DesktopWebsite.BoardsPage.Header.BackToHome.WaitUntilExists();
            DesktopWebsite.BoardsPage.Header.BackToHome.AssertExists();
        }

        [Given][When]
        public void I_clear_the_P0(string p0)
        {
            if (p0.ToLower().Equals("email address"))
            {
                DesktopWebsite.LogInPage.EmailAddress.Clear();
            }

            if (p0.ToLower().Equals("password"))
            {
                DesktopWebsite.LogInPage.Password.Clear();
            }
        }

        [Then]
        public void the_error_P0_will_be_shown(string p0)
        {
            string actual = DesktopWebsite.LogInPage.ErrorMessage.GetElementAttribute("innerText");
            TestHelper.AssertThat(actual, Is.EqualTo(p0), string.Format("Assert the error {0} is equal to {1}", p0, actual), false);
        }

        [When(@"I enter ""(.*)"" in the username")]
        public void WhenIEnterInTheUsername(string p0)
        {
            DesktopWebsite.LogInPage.EmailAddress.SendKeys(p0);
        }

        [When(@"I enter ""(.*)"" in the password")]
        public void WhenIEnterInThePassword(string p0)
        {
            DesktopWebsite.LogInPage.EmailAddress.SendKeys(p0);
        }

        [Then(@"the error message ""(.*)"" appears")]
        public void ThenTheErrorMessageAppears(string p0)
        {
            DesktopWebsite.LogInPage.LogIn.Click();
            string actual = DesktopWebsite.LogInPage.ErrorMessage.GetElementAttribute("textContent");//.GetElementAttribute("innerText");
            TestHelper.AssertThat(actual, Is.EqualTo(p0), string.Format("Assert the error {0} is equal to {1}", p0, actual), false);
        }



    }
}
