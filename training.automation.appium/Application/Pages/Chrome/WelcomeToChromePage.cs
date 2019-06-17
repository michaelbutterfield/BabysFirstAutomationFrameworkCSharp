using OpenQA.Selenium;
using training.automation.common.Appium.Elements;
using training.automation.common.Page;

namespace training.automation.appium.Application.Pages.Chrome
{
    public class WelcomeToChromePage : Page
    {
        public Button UsageAndCrashReports;
        public Button AcceptAndContinue;
        public Text WelcomeToChrome;

        public WelcomeToChromePage() : base("Welcome to Chrome") { BuildPage(); }

        private void BuildPage()
        {
            AcceptAndContinue = new Button(By.Id("terms_accept"), "Accept and Continue", name);
            UsageAndCrashReports = new Button(By.Id("send_report_checkbox"), "Send Usage Statistics and Crash Reports", name);
            WelcomeToChrome = new Text(By.Id("title"), "Welcome to Chrome Text", name);
        }
    }
}
