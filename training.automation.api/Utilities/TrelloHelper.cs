using RestSharp;
using System;
using System.Collections.Generic;
using training.automation.api.Data;
using training.automation.common.utilities;
using Is = NHamcrest.Is;

namespace training.automation.api.Utilities
{
    public class TrelloHelper
    {
        public static void CreateBoard(string boardName, string boardDesc)
        {
            var client = new RestClient("https://api.trello.com/1/boards");

            var request = new RestRequest("/?name={name}&desc={desc}&key={key}&token={token}", Method.POST, DataFormat.Json);
            request.AddUrlSegment("name", boardName);
            request.AddUrlSegment("desc", boardDesc);
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());
            request.AddHeader("content-type", "application/json; charset=utf-8");

            IRestResponse response = client.Execute(request);

            TestHelper.AssertThat(response.StatusCode.ToString(), Is.EqualTo("OK"), String.Format("Asserting that actual: {0} is equal to expected: {1} -- Create Board", response.StatusCode.ToString(), "OK"));
        }

        public static void DeleteBoard(string boardId)
        {
            //if (boardId.Equals("More than one board returned. Be more specific."))
            //{
            //    throw new Exception("More than one board returned. Be more specific.");
            //}

            var client = new RestClient("https://api.trello.com/1/boards");

            var request = new RestRequest("/{id}?key={key}&token={token}", Method.DELETE, DataFormat.Json);
            request.AddUrlSegment("id", boardId);
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());
            request.AddHeader("content-type", "application/json; charset=utf-8");

            IRestResponse response = client.Execute(request);

            TestHelper.AssertThat(response.StatusCode.ToString(), Is.EqualTo("OK"), String.Format("Asserting that actual: {0} is equal to expected: {1} -- Delete Board", response.StatusCode.ToString(), "OK"));
        }

        //Won't work if multiple boards with the same name -- will always return first board
        public static string GetTrelloBoardId(string boardName)
        {
            var client = new RestClient("http://api.trello.com");

            var request = new RestRequest("/1/search?query={query}&key={key}&token={token}", Method.GET);
            request.AddUrlSegment("query", boardName);
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());

            Console.WriteLine(String.Format("Getting ID for board with the name {0}.", boardName));
            TestHelper.WriteToConsole(String.Format("Getting ID for board with the name {0}.", boardName));

            //deserealise data into root object first
            var response = client.Execute<RootObject>(request);
            RootObject board = response.Data;

            ////create a new list specifically for the boards contained in the root object
            //IList<Board> myBoard = new List<Board>();

            ////put the single searched board into the list
            //myBoard = board.boards;

            //if (board.boards.Count > 1)
            //{
            //    return "More than one board returned. Be more specific.";
            //}

            return board.boards[0].id;
        }

        public static RootObject GetTrelloBoardData(string boardId)
        {
            var client = new RestClient("http://api.trello.com");

            var request = new RestRequest("/1/boards/{boardId}?lists=open&list_fields=id,name,closed,pos&key={key}&token={token}", Method.GET, DataFormat.Json);
            request.AddHeader("content-type", "application/json; charset=utf-8");
            request.AddUrlSegment("boardId", boardId);
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());
           

            //deserealise data into root object first
            var response = client.Execute<RootObject>(request);
            RootObject board = response.Data;

            return board;
        }
    }
}
