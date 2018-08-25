using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace client_gui
{
    public partial class Login : System.Web.UI.Page
    {
        HttpClient client = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationSettings.AppSettings.Get("baseadd"));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
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
        static User re2;
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            lblmsg.Text = "";
            User u = new client_gui.User();
            u.userId = txtusername.Text.ToString();
            u.password=txtpassword.Text.ToString();
           // var su = JsonConvert.SerializeObject(u);
           // var c = new StringContent(su, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsJsonAsync("api/CheckUser", u).Result;
            response.EnsureSuccessStatusCode();
            
            
          //  var response =await client.GetAsync("")
            if (response.IsSuccessStatusCode)
            {
               /* client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                lblmsg.Text = "success";
                HttpResponseMessage response1 = client.GetAsync("api/CheckUser?uid=" + txtusername.Text.ToString()).Result;
                List<User> s1 = response1.Content.ReadAsAsync<List<User>>().Result;
                List<User> u2 = new List<User>();
                foreach (User udata in s1)
                {
                    User u1 = new User();
                    u1 = udata;

                    u2.Add(u1);
                }
                */


                List<User> re1 = new List<User>();
                HttpResponseMessage responseUserid = ClientRequest("api/CheckUser?uid=" + txtusername.Text.ToString());
                responseUserid.EnsureSuccessStatusCode();
                if (responseUserid.IsSuccessStatusCode)
                {
                    List<User> rep = responseUserid.Content.ReadAsAsync<List<User>>().Result;
                    foreach (User udata in rep)
                    {
                        User u1 = new User();
                        u1 = udata;

                        re1.Add(u1);
                    }
                    re2 = re1.First();
                    if (re2 != null)
                    {
                        Session["user"] = re2;
                        lblmsg.Text = "success" ;
                        FormsAuthentication.RedirectFromLoginPage(txtusername.Text, chkBoxRememberMe.Checked);
                    }
                }


                lblmsg.ForeColor = System.Drawing.Color.Red;

            }
            else
            {
                lblmsg.Text = "unsuccess";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}