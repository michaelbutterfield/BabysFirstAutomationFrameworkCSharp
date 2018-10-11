using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace training.automation.api.Data
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
