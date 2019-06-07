using training.automation.appium.Application.Pages.Argos;
using training.automation.common.Page;

namespace training.automation.appium.Application
{
    public class MobileApp : Page
    {
        public static HomePage HomePage;

        public MobileApp() : base("Mobile App") { BuildPages(); }

        private void BuildPages()
        {
            HomePage = new HomePage();
        }
    }
}
