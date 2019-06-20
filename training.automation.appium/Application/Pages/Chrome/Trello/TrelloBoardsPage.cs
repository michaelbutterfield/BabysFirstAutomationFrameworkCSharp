using OpenQA.Selenium;
using training.automation.common.Appium.Elements;
using training.automation.common.Page;

namespace training.automation.appium.Application.Pages.Chrome.Trello
{
    public class TrelloBoardsPage : Page
    {
        public TrelloBoardsPage() : base("Trello Splash Page") { BuildPage(); }

        public Button PersonalBoards;

        private void BuildPage()
        {
            PersonalBoards = new Button(By.XPath("//h3[@class='boards-page-board-section-header-name']"), "Personal Boards", name);
        }

    }
}
