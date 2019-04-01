using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace training.automation.api.Data
{
    public class TrelloResponseData
    {

    }

    public class TrelloListResponseData
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool closed { get; set; }
        public string idBoard { get; set; }
        public int pos { get; set; }
    }

    public class TrelloBoardStarredData
    {
        public string id { get; set; }
        public bool starred { get; set; }
    }

    public class TrelloQueryResponseData
    {
        public class Term
        {
            public string text { get; set; }
        }

        public class Options
        {
            public List<Term> terms { get; set; }
            public List<object> modifiers { get; set; }
            public List<string> modelTypes { get; set; }
            public bool partial { get; set; }
        }

        public class Board
        {
            public string id { get; set; }
            public string name { get; set; }
            public object idOrganization { get; set; }
        }

        public class RootObject
        {
            public Options options { get; set; }
            public List<Board> boards { get; set; }
            public List<object> cards { get; set; }
            public List<object> organizations { get; set; }
            public List<object> members { get; set; }
        }
    }

    public class TrelloCreateCardResponse
    {
        public class Trello
        {
            public int board { get; set; }
            public int card { get; set; }
        }

        public class AttachmentsByType
        {
            public Trello trello { get; set; }
        }

        public class Badges
        {
            public AttachmentsByType attachmentsByType { get; set; }
            public bool location { get; set; }
            public int votes { get; set; }
            public bool viewingMemberVoted { get; set; }
            public bool subscribed { get; set; }
            public string fogbugz { get; set; }
            public int checkItems { get; set; }
            public int checkItemsChecked { get; set; }
            public int comments { get; set; }
            public int attachments { get; set; }
            public bool description { get; set; }
            public object due { get; set; }
            public bool dueComplete { get; set; }
        }

        public class Emoji
        {
        }

        public class DescData
        {
            public Emoji emoji { get; set; }
        }

        public class Limits
        {
        }

        public class RootObject
        {
            public string id { get; set; }
            public Badges badges { get; set; }
            public List<object> checkItemStates { get; set; }
            public bool closed { get; set; }
            public bool dueComplete { get; set; }
            public DateTime dateLastActivity { get; set; }
            public string desc { get; set; }
            public DescData descData { get; set; }
            public object due { get; set; }
            public object dueReminder { get; set; }
            public object email { get; set; }
            public string idBoard { get; set; }
            public List<object> idChecklists { get; set; }
            public List<object> attachments { get; set; }
            public string idList { get; set; }
            public List<object> idMembers { get; set; }
            public List<object> idMembersVoted { get; set; }
            public int idShort { get; set; }
            public object idAttachmentCover { get; set; }
            public List<object> labels { get; set; }
            public List<object> idLabels { get; set; }
            public bool manualCoverAttachment { get; set; }
            public string name { get; set; }
            public int pos { get; set; }
            public string shortLink { get; set; }
            public string shortUrl { get; set; }
            public bool subscribed { get; set; }
            public List<object> stickers { get; set; }
            public string url { get; set; }
            public Limits limits { get; set; }
        }
    }

    public class CardsOnListResponseData
    {
        public class RootObject
        {
            public string id { get; set; }
            public string name { get; set; }
        }
    }
}
