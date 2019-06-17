using OpenQA.Selenium;
using training.automation.common.Appium.Elements;
using training.automation.common.Page;

namespace training.automation.appium.Application.Pages.Chrome
{
    public class AccountLogInPage : Page
    {
        public Button NoThanks;

        public AccountLogInPage() : base("Account Log In") { BuildPage(); }

        private void BuildPage()
        {
            NoThanks = new Button(By.XPath("//android.widget.Button[@resource-id='com.android.chrome:id/negative_button']"), "No, thanks", name);
        }
    }
}
