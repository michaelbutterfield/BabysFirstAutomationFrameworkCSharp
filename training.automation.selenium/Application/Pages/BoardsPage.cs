using OpenQA.Selenium;
using training.automation.common.Pages;
using training.automation.common.Selenium.Elements;

namespace training.automation.selenium.Application.Pages
{
    public class BoardsPage : Page
    {
        public Label boardNotFound;
        public Button createNewBoard;
        public Button favourite;
        public Button userBoard;

        public BoardsPage() : base("Boards Page") { BuildPage(); }

        private void BuildPage()
        {
            boardNotFound = new Label(By.XPath("//h1[contains(text(),'Board not found.')]"), "Board not found. message", name);
            createNewBoard = new Button(By.XPath("//a[@class=\"js-new-board\"]"), "Create Board... Button", name);
            favourite = new Button(By.XPath("//span[@class='icon-sm icon-star board-tile-options-star-icon']"), "Favourite Button", name);
            userBoard = new Button(By.XPath("//div[@title='TestBoard']"), "User Created Board", name);
        }

    }
}
