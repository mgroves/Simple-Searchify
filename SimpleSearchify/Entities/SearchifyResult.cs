using System;

namespace SimpleSearchify.Entities
{
    public class SearchifyResult
    {
        public string DocID { get; set; }
        public double Query_Relevance_Score { get; set; }
    }
}