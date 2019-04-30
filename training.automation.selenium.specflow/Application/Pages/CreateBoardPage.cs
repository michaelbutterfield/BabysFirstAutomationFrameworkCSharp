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
            BackgroundSelection = new Button(By.XPath("//ul[@class='background-grid']/li[2]"), "Board Background Selection", name);
            CreateBoard = new Button(By.XPath("//div[@class='window-wrapper js-tab-parent']//button[@class='primary'][@type='submit']"), "Create Board Button", name);
            NameInput = new InputBox(By.XPath("//input[@placeholder='Add board title']"), "Board Name Input Box", name);
        }
    }
}
