using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Xml;

namespace phase3Elective1TryIt
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string address1 = textboxAddress1.Text;
            string address2 = textboxAddress2.Text;

            string url1 = "http://localhost:54845/Service1.svc/commute/" + address1 + "/" + address2;

            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(url1);
            WebResponse response1 = request1.GetResponse();
            Stream responseStream1 = response1.GetResponseStream();

            StreamReader reader1 = new StreamReader(responseStream1);

            string result1 = reader1.ReadToEnd();

            string url2 = "http://localhost:54845/Service1.svc/commuteRating/" + address1 + "/" + address2;

            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(url2);
            WebResponse response2 = request2.GetResponse();
            Stream responseStream2 = response2.GetResponseStream();

            StreamReader reader2 = new StreamReader(responseStream2);

            string result2 = reader2.ReadToEnd();

            textBoxTime.Text = clean(result1);
            textboxRating.Text = clean(result2);
        }

        public string clean(string str)
        {
            str = str.Replace("<string xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\">", "");
            str = str.Replace("</string>", "");
            return str;
        }
    }
}