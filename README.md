Simple Searchify
================
This is a very, very simple .NET API for Searchify. I originally wrote it for [CrossCuttingConcerns.com](http://CrossCuttingConcerns.com), where I only wanted to do two things with Searchify: index each blog post as I published it, and provide relevant search results for users.  There is a lot more that Searchify can do that I didn't need for this project, but if you're like me, or you just want a simple, gentle introduction to Searchify, I hope this project helps you.

Hopefully the tests will provide you with enough documentation on my API. The rest you can figure out from [Searchify's own documentation](http://www.searchify.com/documentation/).

Some details
-------------
* This project uses RestSharp (which uses NewtonSoft's JSON.NET)
* The test project uses MSpec
* The tests are NOT unit tests. They depend on Searchify's actual API and will mutate the index under test

To run the tests
----------------
* Modify the App.Config with your URL and key information
* The tests make these assumptions
	* You have a DemoIndex index
	* There are at least 10 search results for "guitar" in that DemoIndex

If you have the DemoIndex that Searchify provides you out of the box, then the above assumptions are already true.
If not, you'll have to modify the tests.

Roadmap
-------
I have no roadmap for future features, but pull requests with corrections or new features are very much welcome!