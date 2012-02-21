using System.Net;
using RestSharp;
using SimpleSearchify.Entities;

namespace SimpleSearchify.Services
{
    public class IndexingService
    {
        readonly string _key;
        readonly string _indexName;
        readonly string _apiUrl;

        public IndexingService(string apiUrl, string key, string indexName)
        {
            _apiUrl = apiUrl;
            _key = key;
            _indexName = indexName;
        }

        public HttpStatusCode AddDocument(SearchifyDocument doc)
        {
            var client = new RestClient();
            client.Authenticator = new HttpBasicAuthenticator("", _key);
            var req = new RestRequest("http://" + _apiUrl + ".api.searchify.com/v1/indexes/" + _indexName + "/docs", Method.PUT);
            req.RequestFormat = DataFormat.Json;
            req.AddBody(new { docid = doc.DocID, fields = doc.Fields });
            var resp = client.Execute(req);
            return resp.StatusCode;
        }
    }
}