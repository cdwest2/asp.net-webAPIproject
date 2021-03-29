using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Xml;

namespace phase3Elective2TryIt
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string pref1 = textboxPref1.Text;
            string pref2 = textboxPref2.Text;
            string zip = textboxZip.Text;
            string url = "http://localhost:51398/Service1.svc/restaurants/" + pref1 + "/" + pref2 + "/" + zip;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(responseStream);

            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNodeList list = doc.GetElementsByTagName("string");

            textboxRest1.Text = list[0].InnerText;
            textboxRest2.Text = list[1].InnerText;
            textboxRest3.Text = list[2].InnerText;
            textboxRest4.Text = list[3].InnerText;
            textboxRest5.Text = list[4].InnerText;
        }
    }
}