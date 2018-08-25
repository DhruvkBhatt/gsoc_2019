using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace client_gui
{
    public class Recipe
    {
        public string Id { get; set; }
        public string userId { get; set; }
        public string resID { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string des { get; set; }
        
    }
}