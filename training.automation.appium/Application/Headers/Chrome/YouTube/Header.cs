using OpenQA.Selenium;
using training.automation.common.Appium.Elements;
using training.automation.common.Sections;

namespace training.automation.appium.Application.Headers.Chrome.YouTube
{
    public class Header : Section
    {
        public Button Home;
        public Button Search;

        public Header() : base("YouTube Header") { BuildHeader(); }

        public void BuildHeader()
        {
            Home = new Button(By.XPath("//button[@aria-label='Home']"), "YouTube Logo Home Button", name);
            Search = new Button(By.XPath("//button[@aria-label='Search YouTube']"), "Search", name);
        }
    }
}
