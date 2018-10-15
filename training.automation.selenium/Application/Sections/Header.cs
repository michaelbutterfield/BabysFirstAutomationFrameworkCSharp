using OpenQA.Selenium;
using training.automation.common.Sections;
using training.automation.common.Selenium.Elements;

namespace training.automation.selenium.Application.Sections
{
    public class Header : Section
    {
        public Button addButton;
        public Image backToHome;
        public Image trelloLogoHome;

        public Header() : base("Header") { BuildSections(); }

        private void BuildSections()
        {
            addButton = new Button(By.XPath("//span[@class=\"header-btn-icon icon-lg icon-add light\"]"), "Header + Button", name);
            backToHome = new Image(By.XPath("//*[@id=\"header\"]/div[1]/a/span"), "Back to Home button in Top Left", name);
            trelloLogoHome = new Image(By.XPath("//*[@id=\"header\"]/a/span[2]"), "Trello Logo Home Button", name);
        }
    }
}