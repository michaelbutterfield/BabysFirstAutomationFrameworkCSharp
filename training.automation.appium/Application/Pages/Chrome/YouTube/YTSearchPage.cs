using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using training.automation.common.Appium.Elements;
using training.automation.common.Page;

namespace training.automation.appium.Application.Pages.Chrome.YouTube
{
    public class YTSearchPage : Page
    {
        public Button Back;
        public Button Search;
        public InputBox SearchBar;

        public YTSearchPage() : base("YouTube Search Page") { BuildPage(); }

        private void BuildPage()
        {
            Back = new Button(By.XPath("//button[@aria-label='Close search']"), "Close Search", name);
            Search = new Button(By.XPath("//button[@class='icon-button ' and @aria-label='Search YouTube']"), "Search", name);
            SearchBar = new InputBox(By.XPath("//input[@class='searchbox-input title' and @name='search']"), "Search Bar", name);
        }
    }
}
