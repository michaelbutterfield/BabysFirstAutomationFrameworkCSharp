using OpenQA.Selenium;
using training.automation.common.Sections;
using training.automation.common.Winium.Elements;

namespace training.automation.winium.Application.Sections.Calculator
{
    public class NavigationPane : Section
    {
        public Button ScientificCalculator;
        public Button StandardCalculator;

        public NavigationPane() : base("NavigationPane") { BuildSections(); }

        private void BuildSections()
        {
            ScientificCalculator = new Button(By.Id("Scientific"), "Scientific Calculator option in Navigation Pane", name);
            StandardCalculator = new Button(By.Id("Standard"), "Standard Calculator option in Navigation Pane", name);
        }
    }
}
