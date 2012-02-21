using System.Collections.Generic;

namespace SimpleSearchify.Entities
{
    public class SearchifyQueryResult
    {
        public int Matches { get; set; }
        public double Search_Time { get; set; }
        public List<SearchifyResult> Results { get; set; }
    }
}