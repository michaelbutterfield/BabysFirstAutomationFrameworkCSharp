using RestSharp;
using RestSharp.Deserializers;
using System.Collections.Generic;
using Is = NHamcrest.Is;

namespace training.automation.common.Utilities
{
    using Data.Trello;

    public class TrelloAPIHelper
    {
        private static IRestClient client = new RestClient("https://api.trello.com/");
        private static JsonDeserializer deserial = new JsonDeserializer();

        public static void CreateBoard(string boardName, string boardDesc)
        {
            IRestRequest request = new RestRequest("1/boards/?name={name}&desc={desc}&defaultLists=false&key={key}&token={token}", Method.POST, DataFormat.Json);
            request.AddUrlSegment("name", boardName);
            request.AddUrlSegment("desc", boardDesc);
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());
            request.AddHeader("content-type", "application/json; charset=utf-8");

            IRestResponse response = client.Execute(request);

            string statusCode = response.StatusCode.ToString();
            string assertionDesc = string.Format("Assert Create Board response code actual: {0} is equal to expected: {1}", statusCode, "OK");

            TestHelper.AssertThat(statusCode, Is.EqualTo("OK"), assertionDesc);
        }

        public static void DeleteBoard(string boardId)
        {
            IRestRequest request = new RestRequest("1/boards/{id}?key={key}&token={token}", Method.DELETE, DataFormat.Json);
            request.AddUrlSegment("id", boardId);
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());
            request.AddHeader("content-type", "application/json; charset=utf-8");

            IRestResponse response = client.Execute(request);

            string statusCode = response.StatusCode.ToString();
            string assertionDesc = string.Format("Assert Delete Board response code actual: {0} is equal to expected: {1}", statusCode, "OK");

            TestHelper.AssertThat(statusCode, Is.EqualTo("OK"), assertionDesc);
        }

        public static void CreateCard(int listNum)
        {
            IRestRequest request = new RestRequest("/1/cards?name={name}&idList={idList}&key={key}&token={token}", Method.POST, DataFormat.Json);

            string cardName = RandomGen.RandomAlphanumericString(5);
            RuntimeTestData.Add("cardName", cardName);

            request.AddUrlSegment("name", cardName);
            request.AddUrlSegment("idList", RuntimeTestData.GetAsString("listId_" + listNum));
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());
            request.AddHeader("content-type", "application/json; charset=utf-8");

            //this is how to deserialise do this for the rest
            IRestResponse response = client.Execute(request);
            
            TrelloCreateCardResponse.RootObject Data = deserial.Deserialize<TrelloCreateCardResponse.RootObject>(response);

            RuntimeTestData.Add("cardId", Data.id);

            string statusCode = response.StatusCode.ToString();
            string assertionDesc = string.Format("Assert Create Card response code actual: {0} is equal to expected: {1}", statusCode, "OK");

            TestHelper.AssertThat(statusCode, Is.EqualTo("OK"), assertionDesc);

        }

        public static void CreateCards(int numOfCards, int listNum)
        {
            int cardNum = 1;

            if (numOfCards > 0)
            {
                for (int i = 0; i < numOfCards; i++)
                {
                    IRestRequest request = new RestRequest("/1/cards?name={name}&idList={idList}&key={key}&token={token}", Method.POST, DataFormat.Json);

                    string cardName = RandomGen.RandomAlphanumericString(5);
                    string dataAdd = string.Format("list_{0} cardName_{1}", listNum, cardNum);
                    RuntimeTestData.Add(dataAdd, cardName);

                    request.AddUrlSegment("name", cardName);
                    request.AddUrlSegment("idList", RuntimeTestData.GetAsString("listId_" + listNum));
                    request.AddUrlSegment("key", TrelloApiData.GetApiKey());
                    request.AddUrlSegment("token", TrelloApiData.GetApiToken());
                    request.AddHeader("content-type", "application/json; charset=utf-8");

                    IRestResponse response = client.Execute(request);

                    TrelloCreateCardResponse.RootObject Data = deserial.Deserialize<TrelloCreateCardResponse.RootObject>(response);

                    dataAdd = string.Format("list_{0} cardId_{1}", listNum, cardNum); 
                    RuntimeTestData.Add(dataAdd, Data.id);

                    string statusCode = response.StatusCode.ToString();
                    string assertionDesc = string.Format("Assert Create Card response code actual: {0} is equal to expected: {1}", statusCode, "OK");

                    TestHelper.AssertThat(statusCode, Is.EqualTo("OK"), assertionDesc);

                    cardNum++;
                }
            }
        }

        public static void DeleteCard(string cardId)
        {
            IRestRequest request = new RestRequest("1/cards/{id}?key={key}&token={token}", Method.DELETE, DataFormat.Json);

            request.AddUrlSegment("id", cardId);
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());
            request.AddHeader("content-type", "application/json; charset=utf-8");

            IRestResponse response = client.Execute(request);

            string statusCode = response.StatusCode.ToString();
            string assertionDesc = string.Format("Assert Delete Card response code actual: {0} is equal to expected: {1}", statusCode, "OK");

            TestHelper.AssertThat(statusCode, Is.EqualTo("OK"), assertionDesc);
        }

        public static void ArchiveList(string listId)
        {
            IRestRequest request = new RestRequest("1/lists/{listId}/closed?value=true&key={key}&token={token}", Method.PUT, DataFormat.Json);

            request.AddUrlSegment("listId", RuntimeTestData.GetAsString(listId));
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());
            request.AddHeader("content-type", "application/json; charset=utf-8");

            IRestResponse response = client.Execute(request);

            string statusCode = response.StatusCode.ToString();
            string assertionDesc = string.Format("Assert Archive List response code actual: {0} is equal to expected: {1}", statusCode, "OK");

            TestHelper.AssertThat(statusCode, Is.EqualTo("OK"), assertionDesc);
        }

        public static void CreateList(string boardId)
        {
            IRestRequest request = new RestRequest("/1/lists?name={name}&idBoard={idBoard}&key={key}&token={token}", Method.POST, DataFormat.Json);

            string listName = RandomGen.RandomAlphanumericString(5);
            RuntimeTestData.Add("listName", listName);

            request.AddUrlSegment("name", listName);
            request.AddUrlSegment("idBoard", GetTrelloBoardId(RuntimeTestData.GetAsString("BoardName")));
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());
            request.AddHeader("content-type", "application/json; charset=utf-8");

            IRestResponse response = client.Execute(request);

            TrelloListResponseData Data = deserial.Deserialize<TrelloListResponseData>(response);

            RuntimeTestData.Add("listId_1", Data.id);

            string statusCode = response.StatusCode.ToString();
            string assertionDesc = string.Format("Assert Create List response code actual: {0} is equal to expected: {1}", statusCode, "OK");

            TestHelper.AssertThat(statusCode, Is.EqualTo("OK"), assertionDesc);
        }

        public static void CreateLists(string boardId, int numOfLists)
        {
            int listCount = numOfLists;

            for (int i = 0; i < numOfLists; i++)
            {
                IRestRequest request = new RestRequest("/1/lists?name={name}&idBoard={idBoard}&key={key}&token={token}", Method.POST, DataFormat.Json);

                string listName = RandomGen.RandomAlphanumericString(5);
                RuntimeTestData.Add("list_" + listCount, listName);

                request.AddUrlSegment("name", listName);
                request.AddUrlSegment("idBoard", GetTrelloBoardId(RuntimeTestData.GetAsString("BoardName")));
                request.AddUrlSegment("key", TrelloApiData.GetApiKey());
                request.AddUrlSegment("token", TrelloApiData.GetApiToken());
                request.AddHeader("content-type", "application/json; charset=utf-8");

                IRestResponse response = client.Execute(request);

                TrelloListResponseData Data = deserial.Deserialize<TrelloListResponseData>(response);

                RuntimeTestData.Add("listId_" + listCount, Data.id);

                string statusCode = response.StatusCode.ToString();
                string assertionDesc = string.Format("Assert Create List response code actual: {0} is equal to expected: {1}", statusCode, "OK");

                TestHelper.AssertThat(statusCode, Is.EqualTo("OK"), assertionDesc);

                listCount--;
            }
        }

        public static int GetNumOfCardsOnAList(int listNum)
        {
            IRestRequest request = new RestRequest("https://api.trello.com/1/lists/{listId}/cards?fields=id,name&key={key}&token={token}");
            request.AddUrlSegment("listId", RuntimeTestData.GetAsString("listId_" + listNum));
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());
            request.AddHeader("content-type", "application/json; charset=utf-8");

            IRestResponse response = client.Execute(request);

            List<CardsOnListResponseData.RootObject> Data = deserial.Deserialize<List<CardsOnListResponseData.RootObject>>(response);

            string statusCode = response.StatusCode.ToString();
            string assertionDesc = string.Format("Assert Create List response code actual: {0} is equal to expected: {1}", statusCode, "OK");

            TestHelper.AssertThat(statusCode, Is.EqualTo("OK"), assertionDesc);

            return Data.Count;
        }

        //Won't work if multiple boards with the same name -- will always return first board
        public static string GetTrelloBoardId(string boardName)
        {
            IRestRequest request = new RestRequest("/1/search?query={query}&key={key}&token={token}", Method.GET);
            request.AddUrlSegment("query", boardName);
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());

            IRestResponse response = client.Execute(request);

            TrelloQueryResponseData.RootObject Data = deserial.Deserialize<TrelloQueryResponseData.RootObject>(response);

            return Data.boards[0].id;
        }

        public static int GetListLength(string boardId)
        {
            IRestRequest request = new RestRequest("/1/boards/{boardId}?actions=none&boardStars=none&cards=all&card" +
                "_pluginData=false&checklists=all&customFields=false&fields=name%2Cdesc%2CdescData%2Cclose" +
                "d%2CidOrganization%2Cpinned%2Curl%2C&lists=open&members=all&memberships=all&membersInvite" +
                "d=none&membersInvited_fields=all&pluginData=false&organization=false&organization_pluginD" +
                "ata=false&myPrefs=false&tags=false&key={key}&token={token}", Method.GET, DataFormat.Json);

            request.AddUrlSegment("boardId", boardId);
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());

            IRestResponse response = client.Execute(request);

            TrelloEntireBoardApiData.RootObject Data = deserial.Deserialize<TrelloEntireBoardApiData.RootObject>(response);

            return Data.lists.Count;
        }

        public static int GetNumOfCards(string boardId)
        {
            IRestRequest request = new RestRequest("/1/boards/{boardId}?actions=none&boardStars=none&cards=all&car" +
                "d_pluginData=false&checklists=all&customFields=false&fields=name%2Cdesc%2CdescData%2Cclo" +
                "sed%2CidOrganization%2Cpinned%2Curl%2C&lists=open&members=all&memberships=all&membersInv" +
                "ited=none&membersInvited_fields=all&pluginData=false&organization=false&organization_plu" +
                "ginData=false&myPrefs=false&tags=false&key={key}&token={token}", Method.GET, DataFormat.Json);
            request.AddUrlSegment("boardId", boardId);
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());

            IRestResponse response = client.Execute(request);

            TrelloEntireBoardApiData.RootObject Data = deserial.Deserialize<TrelloEntireBoardApiData.RootObject>(response);

            return Data.cards.Count;
        }

        public static bool GetBoardStarredStatus(string boardId)
        {
            IRestRequest request = new RestRequest("/1/boards/{boardId}?fields=starred&key={key}&token={token}", Method.GET, DataFormat.Json);
            request.AddUrlSegment("boardId", boardId);
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());

            IRestResponse response = client.Execute(request);

            TrelloBoardStarredData Data = deserial.Deserialize<TrelloBoardStarredData>(response);

            return Data.starred;
        }
    }
}
