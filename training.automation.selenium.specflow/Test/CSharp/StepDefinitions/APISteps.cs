using TechTalk.SpecFlow;
using training.automation.common.Utilities;

namespace training.automation.selenium.specflow.Test.CSharp.StepDefinitions
{
    class APISteps
    {
        [Given]
        public void I_create_a_board_through_the_API()
        {
            RuntimeTestData.Add("BoardName", Random.RandomAlphanumericString(10));
        }

    }
}
