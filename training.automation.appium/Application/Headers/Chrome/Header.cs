using OpenQA.Selenium;
using training.automation.common.Appium.Elements;
using training.automation.common.Page;

namespace training.automation.appium.Application.Headers.Chrome
{
    public class Header : Section
    {
        public Button Menu { get; private set; }
        public InputBox SearchBar { get; private set; }
        public Button Tabs { get; private set; }

        public Header() : base("Account Log In") { BuildHeader(); }

        private void BuildHeader()
        {
            Menu = new Button(By.Id("menu_button"), "Menu - Top Right", name);
            SearchBar = new InputBox(By.Id("url_bar"), "Web Address Bar", name);
            Tabs = new Button(By.Id("tab_switcher_button"), "Tabs", name);
        }
    }
}
