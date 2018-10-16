using OpenQA.Selenium;
using training.automation.common.Pages;
using training.automation.common.Selenium.Elements;

namespace training.automation.selenium.Application.Pages
{
    public class BoardsPage : Page
    {
        public Label boardNotFound;
        public Button createNewBoardButton;
        public Button favouriteButton;
        public Button userBoardButton;

        public BoardsPage() : base("Boards Page") { BuildPage(); }

        private void BuildPage()
        {
            boardNotFound = new Label(By.XPath("//h1[contains(text(),'Board not found.')]"), "Board not found. message", name);
            createNewBoardButton = new Button(By.XPath("//a[@class=\"js-new-board\"]"), "Create Board... Button", name);
            favouriteButton = new Button(By.XPath("//span[@class='icon-sm icon-star board-tile-options-star-icon']"), "Favourite Button", name);
            userBoardButton = new Button(By.XPath("//div[@title='TestBoard']"), "User Created Board", name);
        }

    }
}
