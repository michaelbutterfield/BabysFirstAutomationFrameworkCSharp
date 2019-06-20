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
            Add = new Button(By.XPath("//span[@name='add']"), "Header +", name);
            BackToHome = new Image(By.XPath("//span[@name='house']"), "Back to Home", name);
            TrelloLogoHome = new Image(By.XPath("//a[@href='/' and @class='_1R0epOOwzhMcir']"), "Trello Logo Home", name);
        }
    }
}