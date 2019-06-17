using training.automation.appium.Application.Headers.Chrome.YouTube;
using training.automation.common.Appium.Elements;
using training.automation.common.Page;

namespace training.automation.appium.Application.Pages.Chrome.YouTube
{
    public class YTHomePage : Page
    {
        public Header Header;

        public YTHomePage() : base("YouTube Home Page") { BuildPage(); }

        private void BuildPage()
        {
            
        }

        private void BuildHeader()
        {
            Header = new Header();
        }
    }
}
