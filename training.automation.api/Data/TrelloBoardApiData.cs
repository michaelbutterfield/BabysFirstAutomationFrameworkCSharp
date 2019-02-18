
using System;
using System.Collections.Generic;

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
    public int votes { get; set; }
    public AttachmentsByType attachmentsByType { get; set; }
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

public class Card
{
    public string id { get; set; }
    public object checkItemStates { get; set; }
    public bool closed { get; set; }
    public DateTime dateLastActivity { get; set; }
    public string desc { get; set; }
    public object descData { get; set; }
    public string idBoard { get; set; }
    public string idList { get; set; }
    public List<object> idMembersVoted { get; set; }
    public int idShort { get; set; }
    public object idAttachmentCover { get; set; }
    public List<object> idLabels { get; set; }
    public bool manualCoverAttachment { get; set; }
    public string name { get; set; }
    public int pos { get; set; }
    public string shortLink { get; set; }
    public Badges badges { get; set; }
    public bool dueComplete { get; set; }
    public object due { get; set; }
    public List<object> idChecklists { get; set; }
    public List<object> idMembers { get; set; }
    public List<object> labels { get; set; }
    public string shortUrl { get; set; }
    public bool subscribed { get; set; }
    public string url { get; set; }
}

public class List
{
    public string id { get; set; }
    public string name { get; set; }
    public bool closed { get; set; }
    public string idBoard { get; set; }
    public int pos { get; set; }
    public bool subscribed { get; set; }
}

public class Member
{
    public string id { get; set; }
    public object avatarHash { get; set; }
    public object avatarUrl { get; set; }
    public string initials { get; set; }
    public string fullName { get; set; }
    public string username { get; set; }
    public bool confirmed { get; set; }
    public string memberType { get; set; }
}

public class Membership
{
    public string id { get; set; }
    public string idMember { get; set; }
    public string memberType { get; set; }
    public bool unconfirmed { get; set; }
    public bool deactivated { get; set; }
}

public class RootObject
{
    public string id { get; set; }
    public string name { get; set; }
    public string desc { get; set; }
    public object descData { get; set; }
    public bool closed { get; set; }
    public object idOrganization { get; set; }
    public bool pinned { get; set; }
    public string url { get; set; }
    public List<Card> cards { get; set; }
    public List<List> lists { get; set; }
    public List<Member> members { get; set; }
    public List<object> checklists { get; set; }
    public List<Membership> memberships { get; set; }
}