using OpenQA.Selenium;
using training.automation.common.Appium.Elements;
using training.automation.common.Page;

namespace training.automation.appium.Application.Pages.Chrome.Trello
{
    public class TrelloBoardsPage : Page
    {
        public Button PersonalBoards { get; private set; }

        public TrelloBoardsPage() : base("Trello Splash Page") { BuildPage(); }

        private void BuildPage()
        {
            PersonalBoards = new Button(By.XPath("//h3[@class='boards-page-board-section-header-name']"), "Personal Boards", name);
        }

    }
}
