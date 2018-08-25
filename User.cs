using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace client_gui
{
    public class User
    {
        public string Id { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string Email { get; set; }
        public string cbId { get; set; }


    }
}