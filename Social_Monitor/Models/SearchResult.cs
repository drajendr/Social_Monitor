using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Monitor.Models
{
    public class SearchResult
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Snippet { get; set; }
        public string Query { get; set; }
        public string Source { get; set; }
        public string Index { get; set; }
    }
}