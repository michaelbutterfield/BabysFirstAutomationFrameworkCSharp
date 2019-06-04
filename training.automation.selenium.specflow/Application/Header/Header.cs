using OpenQA.Selenium;
using training.automation.common.Sections;
using training.automation.common.Selenium.Elements;

namespace training.automation.specflow.Application.Sections
{
    public class Header : Section
    {
        public Button Add;
        public Image BackToHome;
        public Image TrelloLogoHome;

        public Header() : base("Header") { BuildSections(); }

        private void BuildSections()
        {
            //Add = new Button(By.XPath("//a[@class='header-btn js-open-add-menu']"), "Header + Button", name);
            Add = new Button(By.XPath("//span[@class='header-btn-icon icon-lg icon-add light']"), "Header + Button", name);
            BackToHome = new Image(By.XPath("//*[@id=\"header\"]/div[1]/a/span"), "Back to Home button in Top Left", name);
            TrelloLogoHome = new Image(By.XPath("//a[@class='header-logo js-home-via-logo'"), "Trello Logo Home Button", name);
        }
    }
}