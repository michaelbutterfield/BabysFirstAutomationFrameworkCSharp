using OpenQA.Selenium;
using training.automation.common.Page;
using training.automation.common.Selenium.Elements;

namespace training.automation.selenium.Application.Pages
{
    public class CreateBoardPage : Page
    {
        public Button BackgroundSelection;
        public Button CreateBoard;
        public InputBox NameInput;

        public CreateBoardPage() : base("Create Board Page") { BuildPage(); }

        private void BuildPage()
        {
            BackgroundSelection = new Button(By.XPath("//*[@id=\"classic\"]/div[4]/div/div/div/form/div/ul/li[2]/button"), "Board Background Selection", name);
            CreateBoard = new Button(By.XPath("//button[@class=\"primary\"][@type=\"submit\"]"), "Create Board Button", name);
            NameInput = new InputBox(By.XPath("//input[@placeholder='Add board title']"), "Board Name Input Box", name);
        }
    }
}
