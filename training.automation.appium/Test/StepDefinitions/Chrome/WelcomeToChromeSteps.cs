using TechTalk.SpecFlow;
using training.automation.appium.Application;

namespace training.automation.appium.Test.StepDefinitions.Chrome
{
    [Binding]
    public class WelcomeToChromeSteps
    {
        [Given(@"I am on the Welcome To Chrome page")]
        public static void IAmOnTheWelcomeToChromePage()
        {
            MobileApp.WelcomeToChromePage.WelcomeToChrome.AssertExists();
            //AppiumHelper.GetDriver().FindElementById("title");
            //AppiumHelper.GetDriver().FindElement(By.Id("title"));
        }

        [When(@"I click the usage and crash reports textbox")]
        public static void IClickTheUsageAndCrashReportsTextbox()
        {
            MobileApp.WelcomeToChromePage.UsageAndCrashReports.Click();
            //AppiumHelper.GetDriver().FindElementById("com.android.chrome:id/send_report_checkbox").Click();
        }

        [When(@"I click the Accept & continue button")]
        public static void IClickTheAcceptContinueButton()
        {
            //IF THIS FAILS:
            //you'll need to up your display size from 'small' in the display settings of your phone
            //if its 'small' the 'Accept & continue' button has no bounds and can't be clicked
            MobileApp.WelcomeToChromePage.AcceptAndContinue.Click();
        }
    }
}
