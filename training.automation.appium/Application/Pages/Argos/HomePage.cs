using training.automation.appium.Application.Sections.Argos;
using training.automation.common.Page;

namespace training.automation.appium.Application.Pages.Argos
{
    public class HomePage : Page
    {
        public Header Header;

        public HomePage() : base("HomePage") { BuildHeader(); }

        private void BuildHeader()
        {
            Header = new Header();
            Header.BuildHomePageHeader();
        }
    }
}
