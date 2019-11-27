using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Social_Monitor.Models
{
    public class SearchEngine
    {
        public string APIKEY = ConfigurationManager.AppSettings["APIKEY"];
        public string EngineID = ConfigurationManager.AppSettings["EngineID"];
        public string SearchURL = ConfigurationManager.AppSettings["SearchURL"];

        public dynamic CustomeSearch(string searchString)
        {
            dynamic jsonData = null;
            try
            {
                var request = WebRequest.Create(SearchURL + APIKEY + "&cx=" + EngineID + "&q=" + searchString);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string respString = reader.ReadToEnd();
                jsonData = JsonConvert.DeserializeObject(respString);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return jsonData;
        }

        public List<SearchResult> GetSearchResults(dynamic jsonData)
        {
            var searchresult = new List<SearchResult>();
            foreach(var item in jsonData.items)
            {
                searchresult.Add(new SearchResult
                {
                    Title = item.title,
                    Link = item.link,
                    Snippet = item.snippet,
                    Source = item.source,
                    Query = item.query,
                    Index = item.index
                    
                });
            }
            return searchresult;
        }
    }
}