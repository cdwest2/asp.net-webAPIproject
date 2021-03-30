using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;

namespace phase2RESTTryIt
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string zip = textboxZip.Text;
            string storeName = textboxName.Text;
            if (zip != "" && storeName != "")
            {
                string url = "http://localhost:50692/Service1.svc/store/" + zip + "/" + storeName;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(responseStream);

                string result = reader.ReadToEnd();
                resultLabel.Text = result;
            }
            else
            {
                resultLabel.Text = "You didn't enter anything for one or more fields.";
            }
        }

        protected void textboxName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}