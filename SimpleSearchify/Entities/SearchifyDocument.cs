using System.Collections.Generic;

namespace SimpleSearchify.Entities
{
    public class SearchifyDocument
    {
        public SearchifyDocument()
        {
            Fields = new Dictionary<string, string>();
        }
        public string DocID { get; set; }
        public IDictionary<string,string> Fields { get; private set; }
    }
}