using OpenQA.Selenium;

namespace training.automation.specflow.Application.Sections
{
    using common.Page;
    using common.Selenium.Elements;

    public class Header : Section
    {
        public Button Add { get; private set; }
        public Image BackToHome { get; private set; }
        public Image TrelloLogoHome { get; private set; }

        public Header() : base("Header")
        {
            BuildSections();
        }

        private void BuildSections()
        {
            Add = new Button(By.XPath("//span[@name='add']"), "Header +", name);
            BackToHome = new Image(By.XPath("//span[@name='house']"), "Back to Home", name);
            TrelloLogoHome = new Image(By.XPath("//a[@href='/' and @class='_1R0epOOwzhMcir']"), "Trello Logo Home", name);
        }
    }
}