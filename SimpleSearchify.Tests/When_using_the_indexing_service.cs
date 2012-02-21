using System;
using System.Configuration;
using System.Net;
using Machine.Specifications;
using SimpleSearchify.Entities;
using SimpleSearchify.Services;

namespace SimpleSearchify.Tests
{
    public class When_using_the_indexing_service
    {
        static IndexingService _indexingService;
        static SearchifyDocument _doc;
        static SearchService _searchService;
        static SearchifyQueryResult _searchResults;
        static HttpStatusCode _status;

        Establish context = () =>
            {
                var searchifyKey = ConfigurationManager.AppSettings["searchifyKey"];
                var apiUrl = ConfigurationManager.AppSettings["searchifyApiUrl"];
                _indexingService = new IndexingService(apiUrl, searchifyKey, "DemoIndex");
                _searchService = new SearchService(apiUrl, searchifyKey, "DemoIndex");
                _doc = new SearchifyDocument();
                _doc.DocID = Guid.NewGuid().ToString();
                _doc.Fields["text"] = "The 'text' field is the default corpus/verbatim that is searched. " + Guid.NewGuid();
            };

        Because of = () =>
            {
                _status = _indexingService.AddDocument(_doc);
                _searchResults = _searchService.Search(_doc.Fields["text"], 1, 1);
            };

        It should_return_an_http_OK_code = () =>
            _status.ShouldEqual(HttpStatusCode.OK);
        It should_have_indexed_the_test_document = () =>
            _searchResults.Results.Count.ShouldEqual(1);
        It should_have_indexed_with_the_given_document_ID = () =>
            _searchResults.Results[0].DocID.ShouldEqual(_doc.DocID);

    }
}