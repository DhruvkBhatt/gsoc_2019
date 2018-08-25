using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace client_gui
{
    public partial class SearchRecipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ViewRecipe(TextBox1.Text);
        }
        public void ViewRecipe(string id)
        {
            Label1.Text = "";
            try
            {
                

                List<Recipe> re1 = new List<Recipe>();
                HttpResponseMessage responseUserid = ClientRequest("api/Recipe?rid=" + TextBox1.Text.ToString());
                responseUserid.EnsureSuccessStatusCode();
                if (responseUserid.IsSuccessStatusCode)
                {
                    
                    List<Rep> re = new List<Rep>();
                    List<Recipe> rep = responseUserid.Content.ReadAsAsync<List<Recipe>>().Result;
                    foreach (Recipe rdata in rep)
                    {
                        Rep r1 = new Rep();
                        r1.des = rdata.des.ToString();
                        r1.name = rdata.name.ToString();
                        r1.url = rdata.url.ToString();
                        //Console.WriteLine("{0}\t{1}\t{2}\t{3}", _Empdata.Uid, _Empdata.Name, _Empdata.Address, _Empdata.City);
                        re.Add(r1);
                    }
                    GridView1.DataSource = re;
                    GridView1.DataBind();


                }
            }
            catch (Exception e)
            {
                Label1.Text = "Not Avilable";
            }
            finally { TextBox1.Text = id.ToString(); }
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
    }
}