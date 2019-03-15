using OpenQA.Selenium;
using training.automation.common.Pages;
using training.automation.common.Selenium.Elements;

namespace training.automation.specflow.Application.Pages
{
    public class BoardsPage : Page
    {
        public Label BoardNotFound;
        public Button CreateNewBoard;
        public Button Unstarred;
        public Button Starred;

        public BoardsPage() : base("Boards") { BuildPage(); }

        private void BuildPage()
        {
            BoardNotFound = new Label(By.XPath("//h1[contains(text(),'Board not found.')]"), "Board not found. message", name);
            CreateNewBoard = new Button(By.XPath("//a[@class=\"js-new-board\"]"), "Create Board... Button", name);
            Unstarred = new Button(By.XPath("//span[@class='icon-sm icon-star board-tile-options-star-icon']"), "Unstarred Board Button", name);
            Starred = new Button(By.XPath("//span[@class='icon-sm icon-star is-starred board-tile-options-star-icon']"), "Starred Board Button", name);
        }
    }
}
