using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
namespace client_gui
{
    public class rbook
    {
        public ObjectId Id { get; set; }
        public string resID { get; set; }
        public string cbId { get; set; }
    }
}