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

namespace phase3Elective2Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string[] restaurants(string preference1, string preference2, string zip)
        {
            string url = "https://api.yelp.com/v3/businesses/search?categories=" + preference1 + "," + preference2 + "&location=" + zip + "&term=restaurant&sort_by=rating";

            string apikey = "lEw9sOPzlrsf7mnc6e6azGGfqa87Rfx-cgb6Z0KxONLHG5WVWNG_5mVi7GhTB73cd3XmQJfJu5N9ILA8IGXp-OhsG6ZV3acn5SDYuqZVslV0RNjUA1tyiiblgdyEXnYx";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.PreAuthenticate = true;
            request.Headers.Add("Authorization", "Bearer " + apikey);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            RootYelp yelp = JsonConvert.DeserializeObject<RootYelp>(responsereader);
            
            if (yelp.businesses.Count >= 5)
            {
                int t = yelp.total;
                //int t = int.Parse(total);
                if (t >= 5)
                {
                    t = 5;
                }
                List<string> topFive = new List<string>();
                topFive.Add(yelp.businesses[0].name);
                string found = "The top five business are: " + yelp.businesses[0].name;
                for(int i = 1; i < t; i++)
                {
                    found += ", " + yelp.businesses[i].name;
                    topFive.Add(yelp.businesses[i].name);
                }

                string[] arr = topFive.ToArray();
                return arr;
            }
            else
            {
                string[] arr = { "ERROR: NO BUSINESSES FOUND" };
                return arr;
            }

            //string[] arr = { yelp.businesses[0].name };
            //string[] arr = { "test" };
            //return arr;
        }
    }
}
