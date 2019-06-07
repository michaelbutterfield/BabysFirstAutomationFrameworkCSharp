using OpenQA.Selenium;
using training.automation.common.Appium.Elements;
using training.automation.common.Sections;

namespace training.automation.appium.Application.Sections.Argos
{
    public class Header : Section
    {
        public Button Search;

        public Header() : base("Header") { }

        public void BuildHomePageHeader()
        {
            //Add = new Button(By.XPath("//a[@class='header-btn js-open-add-menu']"), "Header + Button", name);
            Search = new Button(By.Id("menu_search"), "Header + Button", name);
        }

    }
}
