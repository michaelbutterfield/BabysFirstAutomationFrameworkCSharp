using OpenQA.Selenium;
using training.automation.common.Pages;
using training.automation.common.Selenium.Elements;

namespace training.automation.selenium.Application.Pages
{
    public class BoardsPage : Page
    {
        public Button backgroundSelectionButton;
        public Label boardNotFound;
        public Button createBoardButton;
        public Button createNewBoardButton;
        public Button favouriteButton;
        public InputBox nameInput;
        public Button userBoardButton;

        public BoardsPage() : base("BoardsPage") { BuildPage(); }

        private void BuildPage()
        {
            backgroundSelectionButton = new Button(By.XPath("//*[@id=\"classic\"]/div[4]/div/div/div/form/div/ul/li[2]/button"), "Board Background Selection", name);
            boardNotFound = new Label(By.XPath("//h1[contains(text(),'Board not found.')]"), "Board not found. message", name);
            createBoardButton = new Button(By.XPath("//button[@class=\"primary\"][@type=\"submit\"]"), "Create Board Button", name);
            createNewBoardButton = new Button(By.XPath("//a[@class=\"js-new-board\"]"), "Create Board... Button", name);
            favouriteButton = new Button(By.XPath("//span[@class='icon-sm icon-star board-tile-options-star-icon']"), "Favourite Button", name);
            nameInput = new InputBox(By.XPath("//input[@placeholder='Add board title']"), "Board Name Input Box", name);
            userBoardButton = new Button(By.XPath("//div[@title='TestBoard']"), "User Created Board", name);
        }

    }
}
