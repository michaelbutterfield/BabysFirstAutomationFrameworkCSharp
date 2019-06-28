using OpenQA.Selenium;

namespace training.automation.specflow.Application.Pages
{
    using common.Page;
    using common.Selenium.Elements;

    public class CreateBoardPage : Page
    {
        public Button BackgroundSelection { get; private set; }
        public Button CreateBoard { get; private set; }
        public InputBox NameInput { get; private set; }

        public CreateBoardPage() : base("Create Board") { BuildPage(); }

        private void BuildPage()
        {
            BackgroundSelection = new Button(By.XPath("//li[@class='_klewTgPDDU-Xd _1kqyrj8vA5LbVw'][2]"), "Board Background Selection", name);
            CreateBoard = new Button(By.XPath("//button[@data-test-id='header-create-board-submit-button' and text()='Create Board']"), "Create Board Button", name);
            NameInput = new InputBox(By.XPath("//input[@class='_2S-286TC5jzXKk']"), "Board Name Input Box", name);
        }
    }
}
