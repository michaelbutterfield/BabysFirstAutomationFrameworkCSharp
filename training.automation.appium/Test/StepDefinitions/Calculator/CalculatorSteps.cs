using NHamcrest;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using training.automation.appium.Application;
using training.automation.common.Utilities;

namespace training.automation.appium.Test.StepDefinitions.Calculator
{
    [Binding]
    class CalculatorSteps
    {
        [Given(@"the advanced tab is not open")]
        public void TheAdvancedTabIsNotOpen()
        {

        }

        [When(@"I enter (.*)")]
        public void WhenIEnter(int p0)
        {
            switch (p0)
            {
                case 0:
                    {
                        MobileApp.CalculatorPage.Zero.Click();
                        break;
                    }
                case 1:
                    {
                        MobileApp.CalculatorPage.One.Click();
                        break;
                    }
                case 2:
                    {
                        MobileApp.CalculatorPage.Two.Click();
                        break;
                    }
                case 3:
                    {
                        MobileApp.CalculatorPage.Three.Click();
                        break;
                    }
                case 4:
                    {
                        MobileApp.CalculatorPage.Four.Click();
                        break;
                    }
                case 5:
                    {
                        MobileApp.CalculatorPage.Five.Click();
                        break;
                    }
                case 6:
                    {
                        MobileApp.CalculatorPage.Six.Click();
                        break;
                    }
                case 7:
                    {
                        MobileApp.CalculatorPage.Seven.Click();
                        break;
                    }
                case 8:
                    {
                        MobileApp.CalculatorPage.Eight.Click();
                        break;
                    }
                case 9:
                    {
                        MobileApp.CalculatorPage.Nine.Click();
                        break;
                    }
                case 10:
                    {
                        MobileApp.CalculatorPage.One.Click();
                        MobileApp.CalculatorPage.Zero.Click();
                        break;
                    }
            }
        }
        
        [When(@"I press (.*)")]
        public void WhenIPress(string p0)
        {
            switch(p0.ToLower())
            {
                case "divide":
                    {
                        MobileApp.CalculatorPage.Divide.Click();
                        break;
                    }
                case "times":
                    {
                        MobileApp.CalculatorPage.Times.Click();
                        break;
                    }
                case "minus":
                    {
                        MobileApp.CalculatorPage.Minus.Click();
                        break;
                    }
                case "plus":
                    {
                        MobileApp.CalculatorPage.Plus.Click();
                        break;
                    }
                case "equals":
                    {
                        MobileApp.CalculatorPage.Equals.Click();
                        break;
                    }
                case "delete":
                    {
                        MobileApp.CalculatorPage.Divide.Click();
                        break;
                    }
            }
        }

        [Then(@"the result will be (.*)")]
        public void ThenTheResultWillBe(string p0)
        {
            string assertText = AppiumHelper.GetDriver().FindElement(By.Id("result")).Text;
            string StepDef = string.Format("Assert that the expected: {0} - is equal to the actual {1}", p0, assertText);
            TestHelper.AssertThat(assertText, Is.EqualTo(p0), StepDef);
        }
    }
}
