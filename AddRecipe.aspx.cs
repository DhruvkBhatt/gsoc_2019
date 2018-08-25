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
    public partial class AddRecipe : System.Web.UI.Page
    {
        HttpClient client = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationSettings.AppSettings.Get("baseadd"));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                string imgurl;
                imgurl = imgu();
                if (imgurl != null)
                {
                    if (AddRecipe1(txtrecipename.Text.ToString(), txtrecipeDes.Text.ToString(), imgurl.ToString()))
                    {
                        Label1.Text = "Recipe Added";
                    }
                    else
                    {
                        Label1.Text = "try Again";
                    }
                }
            }catch(Exception e12)
            {
                Label1.Text = "try Again";
            }
            
        }
        
        public string imgu()
        {
            if (FileUpload1.HasFile)
            {
                string str = FileUpload1.FileName;
                string name = GetUniqueKey(10);
                name +=".png";
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Upload/" + name));
                string Image = "~/Upload/" + name.ToString();


                /* SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
                 SqlCommand cmd = new SqlCommand("insert into tbl_data values(@name,@Image)", con);
                 cmd.Parameters.AddWithValue("@name", name);
                 cmd.Parameters.AddWithValue("Image", Image);

                 con.Open();
                 cmd.ExecuteNonQuery();
                 con.Close();
                 */
                Label1.Text = "Image Uploaded";
                Label1.ForeColor = System.Drawing.Color.ForestGreen;
                return Image;

            }

            else
            {
                Label1.Text = "Please Upload your Image";
                Label1.ForeColor = System.Drawing.Color.Red;
                return null;
            }
        }

        public bool AddRecipe1(string name,string des,string imgname)
        {
            string un;
            Recipe re=new Recipe();
            User u = (User)Session["user"];
            if (u != null)
            {
                re.userId = u.userId.ToString();
                re.url= imgname;
                re.resID =GetUniqueKey(10);
                re.name = name;
                re.des = des;


                //User u = new client_gui.User();
                //u.userId = txtusername.Text.ToString();
                //u.password = txtpassword.Text.ToString();
                try
                {

                    HttpResponseMessage response = client.PostAsJsonAsync("api/AddRecipe", re).Result;
                    if(response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e12)
                {
                    Label1.Text = "try Again";
                    return false;
                }

            }
            return false;
        }

     

        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
    }
}