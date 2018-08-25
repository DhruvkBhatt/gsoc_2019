using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

using System.Net.Http;
using System.Net.Http.Headers;

namespace client_gui
{
    public partial class Change_pwd : System.Web.UI.Page
    {

        HttpClient client = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationSettings.AppSettings.Get("baseadd"));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected void btnchangepass_Click(object sender, EventArgs e)
        {
            lblmsg.Text = "";
            User u = (User)Session["user"];
            u.password = txtnewpass.Text.ToString();
            HttpResponseMessage response = client.PostAsJsonAsync("api/UpdatePwd", u).Result;
            if (response.IsSuccessStatusCode)
            {
               
                lblmsg.Text = "success";
                
            }
            else
            {
                lblmsg.Text = "unsuccess";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}