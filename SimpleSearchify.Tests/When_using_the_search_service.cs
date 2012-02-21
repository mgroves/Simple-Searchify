using System.Configuration;
using System.Linq;
using Machine.Specifications;
using SimpleSearchify.Entities;
using SimpleSearchify.Services;

namespace SimpleSearchify.Tests
{
    public class When_using_the_search_service
    {
        static SearchService _searchService;
        static SearchifyQueryResult _results;
        static int _pageSize;

        Establish context = () =>
            {
                var searchifyKey = ConfigurationManager.AppSettings["searchifyKey"];
                var apiurl = ConfigurationManager.AppSettings["searchifyApiUrl"];
                _pageSize = 10;
                _searchService = new SearchService(apiurl, searchifyKey, "DemoIndex");
            };

        Because of = () =>
            {
                _results = _searchService.Search("guitar", 1, _pageSize);
            };

        It should_return_a_query_result = () =>
            _results.ShouldNotBeNull();
        It should_return_a_query_result_with_the_number_of_matches = () =>
            _results.Matches.ShouldBeGreaterThanOrEqualTo(0);
        It should_return_q_query_result_with_the_search_time = () =>
            _results.Search_Time.ShouldBeGreaterThan(0.0);
        It should_return_a_query_result_with_at_least_one_search_result = () =>
            _results.Results.Count.ShouldBeGreaterThan(0);
        It should_return_a_query_result_with_one_page_of_search_results = () =>
            _results.Results.Count.ShouldEqual(10);
        It should_return_a_query_result_with_search_results_that_have_DocIDs = () =>
            _results.Results.Any(r => string.IsNullOrEmpty(r.DocID)).ShouldBeFalse();
        It should_return_a_query_result_with_search_results_that_have_Query_Relevance_Scores = () =>
            _results.Results.Any(r => r.Query_Relevance_Score == default(double)).ShouldBeFalse();
    }
}