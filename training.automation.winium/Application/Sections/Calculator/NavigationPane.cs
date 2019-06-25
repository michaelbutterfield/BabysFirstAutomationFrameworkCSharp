using OpenQA.Selenium;

namespace training.automation.winium.Application.Sections.Calculator
{
    using common.Page;
    using Common.Winium.Elements;

    public class NavigationPane : Section
    {
        public Button ScientificCalculator { get; private set; }
        public Button StandardCalculator { get; private set; }

        public NavigationPane() : base("Navigation Pane")
        {
            BuildSections();
        }

        private void BuildSections()
        {
            ScientificCalculator = new Button(By.Id("Scientific"), "Scientific Calculator option in Navigation Pane", name);
            StandardCalculator = new Button(By.Id("Standard"), "Standard Calculator option in Navigation Pane", name);
        }
    }
}
