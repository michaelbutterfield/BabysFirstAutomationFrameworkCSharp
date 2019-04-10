using OpenQA.Selenium;
using training.automation.common.Page;
using training.automation.common.Selenium.Elements;

namespace training.automation.selenium.Application.Pages
{
    public class BoardsPage : Page
    {
        public Label BoardNotFound;
        public Button CreateNewBoard;
        public Button Favourite;
        public Button UserBoard;

        public BoardsPage() : base("Boards Page") { BuildPage(); }

        private void BuildPage()
        {
            BoardNotFound = new Label(By.XPath("//h1[contains(text(),'Board not found.')]"), "Board not found. message", name);
            CreateNewBoard = new Button(By.XPath("//a[@class=\"js-new-board\"]"), "Create Board... Button", name);
            Favourite = new Button(By.XPath("//span[@class='icon-sm icon-star board-tile-options-star-icon']"), "Favourite Button", name);
            UserBoard = new Button(By.XPath("//div[@title='TestBoard']"), "User Created Board", name);
        }

    }
}
