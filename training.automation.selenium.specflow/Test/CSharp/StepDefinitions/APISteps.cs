using NHamcrest;
using RestSharp;
using TechTalk.SpecFlow;
using training.automation.api.Data;
using training.automation.api.Utilities;
using training.automation.common.utilities;
using training.automation.common.Utilities;

namespace training.automation.selenium.specflow.Test.CSharp.StepDefinitions
{
    [Binding]
    public class APISteps
    {
        [Given]
        public void I_create_a_board_through_the_API()
        {
            string boardName = Random.RandomAlphanumericString(10);
            RuntimeTestData.Add("boardName", boardName);

            string boardDesc = Random.RandomAlphanumericString(20);
            RuntimeTestData.Add("boardDesc", boardDesc);

            TrelloHelper.CreateBoard(boardName, boardDesc);
        }

        [Given]
        public void I_add_P0_lists_to_the_board(int p0)
        {
            var client = new RestClient("https://api.trello.com");
            int numOfLists = p0;

            if (p0 > 0)
            {
                for (int i = 0; i < p0; i++)
                {
                    var request = new RestRequest("/1/lists?name={name}&idBoard={idBoard}&key={key}&token={token}", Method.POST, DataFormat.Json);

                    string listName = Random.RandomAlphanumericString(5);
                    RuntimeTestData.Add("listName_" + numOfLists, listName);

                    request.AddUrlSegment("name", listName);
                    request.AddUrlSegment("idBoard", TrelloHelper.GetTrelloBoardId(RuntimeTestData.GetAsString("boardName")));
                    request.AddUrlSegment("key", TrelloApiData.GetApiKey());
                    request.AddUrlSegment("token", TrelloApiData.GetApiToken());
                    request.AddHeader("content-type", "application/json; charset=utf-8");

                    var response = client.Execute<TrelloListResponseData>(request);
                    TrelloListResponseData Data = response.Data;

                    RuntimeTestData.Add("listId_" + numOfLists, Data.id);

                    string statusCode = response.StatusCode.ToString();
                    string assertionDesc = string.Format("Asserting that actual: {0} is equal to expected: {1}", statusCode, "OK");

                    TestHelper.AssertThat(statusCode, Is.EqualTo("OK"), assertionDesc);

                    numOfLists--;
                }
            }
        }

        [Given]
        public void I_add_P0_cards_to_a_list(int p0)
        {
            var client = new RestClient("https://api.trello.com");
            int numOfCards = 1;

            if (p0 > 0)
            {
                for (int i = 0; i < p0; i++)
                {
                    var request = new RestRequest("/1/cards?name={name}&idList={idList}&key={key}&token={token}", Method.POST, DataFormat.Json);

                    string cardName = Random.RandomAlphanumericString(5);
                    RuntimeTestData.Add("card_" + numOfCards, cardName);

                    request.AddUrlSegment("name", cardName);
                    request.AddUrlSegment("idList", RuntimeTestData.GetAsString("listId_1"));
                    request.AddUrlSegment("key", TrelloApiData.GetApiKey());
                    request.AddUrlSegment("token", TrelloApiData.GetApiToken());
                    request.AddHeader("content-type", "application/json; charset=utf-8");

                    var response = client.Execute<TrelloCreateCardResponse.RootObject>(request);
                    TrelloCreateCardResponse.RootObject Data = response.Data;

                    RuntimeTestData.Add("cardId_" + numOfCards, Data.id);

                    string statusCode = response.StatusCode.ToString();
                    string assertionDesc = string.Format("Asserting that actual: {0} is equal to expected: {1}", statusCode, "OK");

                    TestHelper.AssertThat(statusCode, Is.EqualTo("OK"), assertionDesc);

                    numOfCards++;
                }
            }
        }

        [Given]
        public void I_delete_card_P0(int p0)
        {
            var client = new RestClient("https://api.trello.com");

            var request = new RestRequest("/1/cards/{id}?key={key}&token={token}", Method.DELETE, DataFormat.Json);

            request.AddUrlSegment("id", RuntimeTestData.GetAsString("cardId_7"));
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());
            request.AddHeader("content-type", "application/json; charset=utf-8");

            IRestResponse response = client.Execute(request);

            string statusCode = response.StatusCode.ToString();
            string assertionDesc = string.Format("Asserting that actual: {0} is equal to expected: {1}", statusCode, "OK");

            TestHelper.AssertThat(statusCode, Is.EqualTo("OK"), assertionDesc);
        }

        [Given]
        public void I_delete_list_P0(int p0)
        {
            var client = new RestClient("https://api.trello.com");

            var request = new RestRequest("1/lists/{listId}/closed?value=true&key={key}&token={token}", Method.PUT, DataFormat.Json);

            request.AddUrlSegment("listId", RuntimeTestData.GetAsString("listId_" + p0));
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());
            request.AddHeader("content-type", "application/json; charset=utf-8");

            IRestResponse response = client.Execute(request);

            string statusCode = response.StatusCode.ToString();
            string assertionDesc = string.Format("Asserting that actual: {0} is equal to expected: {1}", statusCode, "OK");

            TestHelper.AssertThat(statusCode, Is.EqualTo("OK"), assertionDesc);
        }

        [Given]
        public void I_delete_the_board_through_the_API()
        {
            var client = new RestClient("https://api.trello.com/");

            var request = new RestRequest("1/boards/{id}?key={key}&token={token}", Method.DELETE, DataFormat.Json);
            request.AddUrlSegment("id", TrelloHelper.GetTrelloBoardId(RuntimeTestData.GetAsString("boardName")));
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());
            request.AddHeader("content-type", "application/json; charset=utf-8");

            IRestResponse response = client.Execute(request);

            string statusCode = response.StatusCode.ToString();
            string assertionDesc = string.Format("Asserting that actual: {0} is equal to expected: {1}", statusCode, "OK");

            TestHelper.AssertThat(statusCode, Is.EqualTo("OK"), assertionDesc);
        }

    }
}
