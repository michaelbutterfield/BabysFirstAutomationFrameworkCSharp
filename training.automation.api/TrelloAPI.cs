using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using training.automation.api.Data;
using training.automation.api.Utilities;
using training.automation.common.utilities;

namespace training.automation.api
{
    [TestClass]
    public class TrelloAPI
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            TrelloApiData.ReadApiKeyToken();
        }

        [Test]
        public void CreateBoard()
        {
            TrelloHelper.CreateBoard("my api test board from c sharp", "haha");
        }

        [Test]
        public void DeleteBoard()
        {
            TrelloHelper.DeleteBoard(TrelloHelper.GetTrelloBoardId("my api test board from c sharp"));
        }

    }
}
