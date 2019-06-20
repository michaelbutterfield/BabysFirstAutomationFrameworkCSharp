using OpenQA.Selenium;
using training.automation.common.Page;
using training.automation.common.Selenium.Elements;

namespace training.automation.specflow.Application.Pages
{
    public class CreateBoardPage : Page
    {
        public Button BackgroundSelection;
        public Button CreateBoard;
        public InputBox NameInput;

        public CreateBoardPage() : base("Create Board") { BuildPage(); }

        private void BuildPage()
        {
            BackgroundSelection = new Button(By.XPath("//li[@class='_klewTgPDDU-Xd _1kqyrj8vA5LbVw'][2]"), "Board Background Selection", name);
            CreateBoard = new Button(By.XPath("//button[@data-test-id='header-create-board-submit-button' and text()='Create Board']"), "Create Board Button", name);
            NameInput = new InputBox(By.XPath("//input[@class='_2S-286TC5jzXKk']"), "Board Name Input Box", name);
        }
    }
}
