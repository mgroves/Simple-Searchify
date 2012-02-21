using RestSharp;
using SimpleSearchify.Entities;

namespace SimpleSearchify.Services
{
    public class SearchService
    {
        readonly string _key;
        readonly string _indexName;
        readonly string _apiUrl;

        public SearchService(string apiUrl, string key, string indexName)
        {
            _apiUrl = apiUrl;
            _key = key;
            _indexName = indexName;
        }

        public SearchifyQueryResult Search(string query, int pageNumber, int pageSize)
        {
            var client = new RestClient();
            client.Authenticator = new HttpBasicAuthenticator("", _key);
            var req = new RestRequest("http://" + _apiUrl + ".api.searchify.com/v1/indexes/" + _indexName + "/search", Method.GET);
            req.RequestFormat = DataFormat.Json;
            req.AddParameter("q", query);
            req.AddParameter("start", (pageNumber-1)*pageSize);
            req.AddParameter("len", pageSize);
            return client.Execute<SearchifyQueryResult>(req).Data;
        }
    }
}