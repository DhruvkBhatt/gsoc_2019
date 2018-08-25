using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Configuration;

namespace client_gui
{
    public partial class AddToCookBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != null)
            {
                AddToCb(TextBox1.Text.ToString());
            }
            else
            {
                Label1.Text = "enter rid";
            }
        }
        public void AddToCb(string id)
        {
            Label1.Text = "";
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(ConfigurationSettings.AppSettings.Get("baseadd"));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                rbook cb = new rbook();
                cb.resID = id.ToString();
                User u = (User)Session["user"];
                cb.cbId = u.cbId.ToString();
                Label1.Text = u.cbId.ToString();
                HttpResponseMessage response = client.PostAsJsonAsync("api/AddCbRp", cb).Result;
                if (response.IsSuccessStatusCode)
                {

                    Label1.Text = "success";

                }
                else
                {
                    Label1.Text = "unsuccess";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
            }catch(Exception e)
            {
               // Label1.Text = "unsuccess";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            }
        }
}