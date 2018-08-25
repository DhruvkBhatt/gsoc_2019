using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Configuration;
using System.Web.Security;

namespace client_gui
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            GetRecipe();
        }
        private static HttpResponseMessage ClientRequest(string RequestURI)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationSettings.AppSettings.Get("baseadd"));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(RequestURI).Result;
            return response;
        }
        public void GetRecipe()
        {
            User u = new User();
            u = (User)Session["user"];
            if(u==null)
            { return; }
            


                List<Rep> re = new List<Rep>();
                HttpResponseMessage responseRes = ClientRequest("api/Recipe?uid="+u.userId.ToString());
                responseRes.EnsureSuccessStatusCode();
                if (responseRes.IsSuccessStatusCode)
                {
                    Console.WriteLine("---------------Get All Employee list------------");
                    List<Recipe> rep = responseRes.Content.ReadAsAsync<List<Recipe>>().Result;
                
                    foreach (Recipe rdata in rep)
                    {
                    Rep rp3 =new Rep();
                    rp3.name = rdata.name.ToString();
                    rp3.url = rdata.url.ToString();
                    rp3.des = rdata.des.ToString();
                        //Console.WriteLine("{0}\t{1}\t{2}\t{3}", _Empdata.Uid, _Empdata.Name, _Empdata.Address, _Empdata.City);
                        re.Add(rp3);
                    }
                    GridView1.DataSource = re;
                    GridView1.DataBind();
                }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}