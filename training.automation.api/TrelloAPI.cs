using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using training.automation.api.Data;
using training.automation.api.Utilities;
using training.automation.common.utilities;

namespace training.automation.api
{
    [TestFixture]
    [Category("Boards")]
    public class ApiTest_Boards
    {
        public ApiTest_Boards()
        {

        }

        [OneTimeSetUp]
        public void SetUp()
        {
            TrelloApiData.ReadApiKeyToken();
        }

        [Test, Order(1)]
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

    [TestFixture]
    [Category("Lists")]
    public class ApiTest_Lists
    {
        public ApiTest_Lists()
        {

        }

        [OneTimeSetUp]
        public void SetUp()
        {
            TrelloApiData.ReadApiKeyToken();
        }

        [Test]
        public void GetLists()
        {
            RootObject boardData = new RootObject();
            boardData = TrelloHelper.GetTrelloBoardData(TrelloHelper.GetTrelloBoardId("TestBoard"));

            TestHelper.WriteToConsole(boardData.lists[0].id);
            TestHelper.WriteToConsole(boardData.lists[0].name);

            TestHelper.WriteToConsole(boardData.lists[1].id);
            TestHelper.WriteToConsole(boardData.lists[1].name);
        }
    }
}
