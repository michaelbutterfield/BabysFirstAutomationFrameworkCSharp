using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using training.automation.common.Pages;
using training.automation.common.Selenium.Elements;

namespace training.automation.selenium.Application.Pages
{
    public class CreateBoardPage : Page
    {
        public Button backgroundSelectionButton;
        public Button createBoardButton;
        public InputBox nameInput;

        public CreateBoardPage() : base("Create Board Page") { BuildPage(); }

        private void BuildPage()
        {
            backgroundSelectionButton = new Button(By.XPath("//*[@id=\"classic\"]/div[4]/div/div/div/form/div/ul/li[2]/button"), "Board Background Selection", name);
            createBoardButton = new Button(By.XPath("//button[@class=\"primary\"][@type=\"submit\"]"), "Create Board Button", name);
            nameInput = new InputBox(By.XPath("//input[@placeholder='Add board title']"), "Board Name Input Box", name);
        }
    }
}
