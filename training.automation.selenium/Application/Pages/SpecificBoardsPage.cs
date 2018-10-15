using OpenQA.Selenium;
using training.automation.common.Pages;
using training.automation.common.Selenium.Elements;

namespace training.automation.selenium.Application.Pages
{
    public class SpecificBoardsPage : Page
    {
        public Button addACard;
        public Button addAnotherList;
        public Button addAList;
        public Button addCardButton;
        public Button addCardCancel;
        public Button addCardFirstCol;
        public Button addCardSecondCol;
        public Button addCardThirdCol;
        public Button addListButton;
        public Button closeBoard;
        public Button closeBoardConfirmation;
        public InputBox enterCardTitle;
        public InputBox enterListTitle;
        public Button homeButton;
        public InputBox listTitle;
        public Button moreSideMenuButton;
        public Link permDeleteBoard;
        public Button permDeleteBoardConfirm;

        public SpecificBoardsPage() : base("SpecificBoardsPage") { BuildPage(); }

        private void BuildPage()
        {
            //Side Menu
            closeBoard = new Button(By.XPath("//a[@class='board-menu-navigation-item-link js-close-board']"), "Close Board...", name);
            closeBoardConfirmation = new Button(By.XPath("//input[@class='js-confirm full negate']"), "Confirm Close Board", name);
            moreSideMenuButton = new Button(By.XPath("//a[@class='board-menu-navigation-item-link js-open-more']"), "More Button in Side Menu", name);
            permDeleteBoard = new Link(By.XPath("//a[@class='quiet js-delete']"), "Permanently Delete Board...", name);
            permDeleteBoardConfirm = new Button(By.XPath("//input[@class='js-confirm full negate']"), "Yes, Permanently Delete Board.", name);

            //General
            addACard = new Button(By.XPath("//span[@class='js-add-a-card']"), "Add a card", name);
            addAList = new Button(By.XPath("//span[text()='Add a list']"), "Add a list", name);
            addAnotherList = new Button(By.XPath("//span[text()='Add another list']"), "Add another list (used for adding any list after the first one)", name);
            addCardCancel = new Button(By.XPath("//a[@class='icon-lg icon-close dark-hover js-cancel']"), "Add a card cancel", name);
            addCardButton = new Button(By.XPath("//input[@class='primary confirm mod-compact js-add-card'][@type='submit']"), "Add Card Button", name);
            addCardFirstCol = new Button(By.XPath("//*[@id=\"board\"]/div[1]/div/a/span[2]"), "Add a card (First column)", name);
            addCardSecondCol = new Button(By.XPath("//*[@id=\"board\"]/div[2]/div/a/span[2]"), "Add a card (Second column)", name);
            addCardThirdCol = new Button(By.XPath("//*[@id=\"board\"]/div[3]/div/a/span[2]"), "Add a card (Second column)", name);
            addListButton = new Button(By.XPath("//input[@class='primary mod-list-add-button js-save-edit']"), "Add List Confirmation Button", name);
            enterCardTitle = new InputBox(By.XPath("//textarea[@class='list-card-composer-textarea js-card-title']"), "Entering card title", name);
            enterListTitle = new InputBox(By.XPath("//input[@class='list-name-input']"), "Entering the list title", name);
        }
    }
}
