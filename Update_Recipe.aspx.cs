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
    public partial class Update_Recipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        List<Recipe> re = new List<Recipe>();
        protected void Button1_Click(object sender, EventArgs e)
        {
            ViewRecipe(TextBox1.Text);
        }
        static Recipe re2;
        public void ViewRecipe(string id)
        {
            Label1.Text = "";
            try
            {
                User u = (User)Session["user"];
                
                List<Recipe> re1 = new List<Recipe>();
                HttpResponseMessage responseUserid = ClientRequest("api/Recipe?rid=" + TextBox1.Text.ToString()+"&uid="+u.userId.ToString());
                responseUserid.EnsureSuccessStatusCode();
                if (responseUserid.IsSuccessStatusCode)
                {
                    List<Recipe> rep = responseUserid.Content.ReadAsAsync<List<Recipe>>().Result;
                    foreach (Recipe udata in rep)
                    {
                        Recipe u1 = new Recipe();
                        u1 = udata;

                        re1.Add(u1);
                    }
                    re2 = re1.First();
                    if (re2 != null)
                    {
                        txtrecipename.Text = re2.name.ToString();
                        txtrecipeDes.Text = re2.des.ToString();
                        if (re2.url != null)
                        {
                            Image1.ImageUrl = re2.url.ToString();
                        }
                    }
                    else
                    {
                        Label1.Text = "Not Avilable";
                    }


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

        protected void Button2_Click(object sender, EventArgs e)
        {
            UpdateRecipe();
        }
        public void UpdateRecipe()
        {
            HttpClient client = new HttpClient();
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationSettings.AppSettings.Get("baseadd"));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (re2 == null)
            {
                Label1.Text = "search recipe first";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Recipe ur = new Recipe();
                ur = re2;

                ur.des = txtrecipeDes.Text.ToString();
                ur.name = txtrecipename.Text.ToString();

                HttpResponseMessage response = client.PostAsJsonAsync("api/UpdateRecipe", ur).Result;
                if (response.IsSuccessStatusCode)
                {

                    Label1.Text = "success";

                }
                else
                {
                    Label1.Text = "unsuccess";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }

            }


        }
    }
}