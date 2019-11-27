using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Social_Monitor.Models;

namespace Social_Monitor.Controllers
{
    public class HomeController : Controller
    {
        SearchEngine _searchEngine = new SearchEngine();
        // GET: Home
        public ActionResult Index()
        {
            dynamic jsonData = _searchEngine.CustomeSearch("Maggi");
            var searchResult = new List<SearchResult>();
            searchResult = _searchEngine.GetSearchResults(jsonData);
            return View(searchResult.ToList());
        }
    }
}