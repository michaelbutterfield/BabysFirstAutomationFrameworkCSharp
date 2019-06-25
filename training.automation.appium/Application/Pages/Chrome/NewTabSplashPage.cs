using OpenQA.Selenium;
using training.automation.common.Appium.Elements;
using training.automation.common.Page;

namespace training.automation.appium.Application.Pages.Chrome
{
    public class NewTabSplashPage : Page
    {
        public Button Search { get; private set; }
        public InputBox UrlAddressBar { get; private set; }

        public NewTabSplashPage() : base("New Tab Splash Page") { BuildPage(); }

        private void BuildPage()
        {
            Search = new Button(By.Id("search_box_text"), "Search or type web address", name);
            UrlAddressBar = new InputBox(By.Id("url_bar"), "Url Address Bar", name);
        }
    }
}
