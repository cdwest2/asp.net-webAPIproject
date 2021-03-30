using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace phase3ElectiveService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string getCommute(string address1, string address2)
        {
            string apiKey = "Amvk0gzGHx0XTkp_XWRI86V1ALrN0Frml0G2CQwZMtEd61yDXEdzA1nqoU0jKw5B";
            string url = "http://dev.virtualearth.net/REST/V1/Routes/Driving?o=json&wp.0=" + address1 + "&wp.1=" + address2 + "&key=" + apiKey;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            RootObject root = JsonConvert.DeserializeObject<RootObject>(responsereader);

            string commuteSec = root.resourceSets[0].resources[0].travelDuration;
            double commuteSecDouble = double.Parse(commuteSec);
            string commuteMin = Math.Round(commuteSecDouble/60).ToString();


            return commuteMin;
        }

        public string calculateRating(string address1, string address2)
        {
            int time = int.Parse(getCommute(address1,address2));
            if(time <= 10)
            {
                return "10";
            }
            else if(time > 10 && time <= 20)
            {
                return "8";
            }
            else if(time > 20 && time <= 30)
            {
                return "6";
            }
            else if(time > 30 && time <= 40)
            {
                return "4";
            }
            else if(time > 40 && time <= 50)
            {
                return "3";
            }
            else if(time > 50 && time <= 60)
            {
                return "2";
            }
            else
            {
                return "1";
            }
        }
    }
}
