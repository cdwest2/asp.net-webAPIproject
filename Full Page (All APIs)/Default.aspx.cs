using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Net;
using System.IO;

namespace phase3CombinedTryIt
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (textboxHomeZip.Text != "" && textboxWorkZip.Text != "")
            {
                //user inputs
                string homeZip = textboxHomeZip.Text;
                string homeAddress = textboxHomeStreet.Text + textboxHomeCity.Text + ", " + textboxHomeState.Text + homeZip;
                string workZip = textboxWorkZip.Text;
                string workAddress = textboxWorkStreet.Text + textboxWorkCity.Text + ", " + textboxWorkState.Text + workZip;
                string pref1 = textboxPref1.Text;
                string pref2 = textboxPref2.Text;
                string storeName = textboxStoreName.Text;

                //top five restaurants process
                string urlTop = "http://localhost:51398/Service1.svc/restaurants/" + pref1 + "/" + pref2 + "/" + homeZip;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlTop);
                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(responseStream);

                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                XmlNodeList list = doc.GetElementsByTagName("string");

                string topFive = "";
                for(int i = 0; i < list.Count; i++)
                {
                    if (i < list.Count - 1)
                    {
                        topFive += list[i].InnerText + ", ";
                    }
                    else
                    {
                        topFive += list[i].InnerText;
                    }
                }

                textboxResultTop5.Text = topFive;

                //commute process
                
                string urlCom = "http://localhost:54845/Service1.svc/commute/" + homeAddress + "/" + workAddress;

                HttpWebRequest requestCom = (HttpWebRequest)WebRequest.Create(urlCom);
                WebResponse responseCom = requestCom.GetResponse();
                Stream responseStreamCom = responseCom.GetResponseStream();

                StreamReader readerCom = new StreamReader(responseStreamCom);
                string resultCom = readerCom.ReadToEnd();
                clean(resultCom);

                textboxResultCommute.Text = clean(resultCom) + " minutes";

                //commute rating process

                string urlRat = "http://localhost:54845/Service1.svc/commuteRating/" + homeAddress + "/" + workAddress;

                HttpWebRequest requestRat = (HttpWebRequest)WebRequest.Create(urlRat);
                WebResponse responseRat = requestRat.GetResponse();
                Stream responseStreamRat = responseRat.GetResponseStream();

                StreamReader readerRat = new StreamReader(responseStreamRat);
                string resultRat = readerRat.ReadToEnd();

                textboxResultCommuteRating.Text = clean(resultRat) + "/10";

                //nearest store process

                string urlStore = "http://localhost:50692/Service1.svc/store/" + homeZip + "/" + storeName;

                HttpWebRequest requestStore = (HttpWebRequest)WebRequest.Create(urlStore);
                WebResponse responseStore = requestStore.GetResponse();
                Stream responseStreamStore = responseStore.GetResponseStream();

                StreamReader readerStore = new StreamReader(responseStreamStore);
                string resultStore = readerStore.ReadToEnd();

                textboxResultStore.Text = clean(resultStore);

            }
            else
            {
                Label1.Text = "ERROR: NO ZIP ENTERED";
            }
        }

        public string clean(string str)
        {
            str = str.Replace("<string xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\">", "");
            str = str.Replace("</string>", "");
            return str;
        }
    }
}