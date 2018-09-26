using training.automation.common.Pages;
using training.automation.common.Selenium.Elements;
using OpenQA.Selenium;

namespace training.automation.selenium.Application.Pages
{
    public class HomePage : Page
    {
        public Button logIn;
        public Button signUp;

        public HomePage() : base("HomePage") { BuildPage(); }

        private void BuildPage()
        {
            logIn = new Button(By.XPath("/html/body/div[1]/div[2]/a[1]"), "Log In Button", name);
            signUp = new Button(By.XPath("/html/body/div[1]/div[2]/a[2]"), "Sign Up Button", name);
        }
    }
}
