using OpenQA.Selenium;
using training.automation.common.Sections;
using training.automation.common.Selenium.Elements;

namespace training.automation.selenium.Application.Sections
{
    public class Header : Section
    {
        public Image backToHome;
        public Image trelloLogoHome;

        public Header() : base("Header") { BuildSections(); }

        private void BuildSections()
        {
            backToHome = new Image(By.XPath("//*[@id=\"header\"]/div[1]/a/span"), "Back to Home button in Top Left", name);
            trelloLogoHome = new Image(By.XPath("//*[@id=\"header\"]/a/span[2]"), "Trello Logo Home Button", name);
        }
    }
}