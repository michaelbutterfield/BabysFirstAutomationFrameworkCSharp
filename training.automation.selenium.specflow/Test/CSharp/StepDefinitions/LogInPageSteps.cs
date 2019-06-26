using TechTalk.SpecFlow;
using training.automation.common.Utilities;
using training.automation.common.Utilities.Data;
using training.automation.specflow.Application;
using Is = NHamcrest.Is;

namespace training.automation.selenium.specflow.Test.CSharp.StepDefinitions
{
    [Binding]
    public sealed class LogInPageSteps
    {
        [Given]
        public void I_am_on_the_log_in_page()
        {
            DesktopWebsite.LogInPage.EmailAddress.WaitUntilExists();
        }

        [When]
        public void I_click_log_in()
        {
            DesktopWebsite.LogInPage.LogIn.Click();
        }

        [Given][When]
        public void I_enter_the_user_details()
        {
            DesktopWebsite.LogInPage.EmailAddress.SendKeys(TrelloWebData.GetUsername());
            DesktopWebsite.LogInPage.Password.SendKeys(TrelloWebData.GetPassword());
        }

        [When]
        public void I_enter_P0_in_the_password(string p0)
        {
            DesktopWebsite.LogInPage.EmailAddress.SendKeys(p0);
        }

        [When]
        public void I_enter_P0_in_the_username(string p0)
        {
            DesktopWebsite.LogInPage.EmailAddress.SendKeys(p0);
        }

        [Given]
        public void I_Log_In()
        {
            DesktopWebsite.SplashPage.LogIn.Click();
            DesktopWebsite.LogInPage.ForgotPassword.WaitUntilExists();
            I_enter_the_user_details();
            DesktopWebsite.LogInPage.LogIn.Click();

            DesktopWebsite.BoardsPage.PersonalBoards.WaitUntilExists();
        }

        [Then]
        public void I_will_be_logged_in_successfully()
        {
            DesktopWebsite.BoardsPage.Header.BackToHome.WaitUntilExists();
        }

        [Then]
        public void the_error_message_P0_appears(string p0)
        {
            DesktopWebsite.LogInPage.LogIn.Click();
            string actual = DesktopWebsite.LogInPage.ErrorMessage.GetElementAttribute("textContent");//.GetElementAttribute("innerText");
            TestHelper.AssertThat(actual, Is.EqualTo(p0), string.Format("Assert the error {0} is equal to {1}", p0, actual), false);
        }
    }
}
