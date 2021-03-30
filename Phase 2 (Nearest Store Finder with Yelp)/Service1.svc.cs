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

namespace phase2RESTService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string findNearestStore(string zip, string storeName)
        {
            double[] coord = zipToCoord(zip);
            double lat = coord[0];
            double lon = coord[1];

            string url = "https://api.yelp.com/v3/businesses/search?term=" + storeName + "&latitude=" + lat + "&longitude=" + lon + "&sort_by=distance";

            string apikey = "lEw9sOPzlrsf7mnc6e6azGGfqa87Rfx-cgb6Z0KxONLHG5WVWNG_5mVi7GhTB73cd3XmQJfJu5N9ILA8IGXp-OhsG6ZV3acn5SDYuqZVslV0RNjUA1tyiiblgdyEXnYx";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.PreAuthenticate = true;
            request.Headers.Add("Authorization", "Bearer " + apikey);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            RootYelp root = JsonConvert.DeserializeObject<RootYelp>(responsereader);

            if (root.businesses.Count > 0)
            {
                Business testBus = root.businesses.First();

                string name = testBus.name + " is the nearest store found, located at ";
                string address = testBus.location.display_address[0] + ", " + root.businesses[0].location.display_address[1];

                return name + address;
            }
            else
            {
                return "ERROR: NO BUSINESSES FOUND";
            }
        }

        public double[] zipToCoord(string zip)
        {
            string url = "https://public.opendatasoft.com/api/records/1.0/search/?dataset=us-zip-code-latitude-and-longitude&q=" + zip + "&facet=state&facet=timezone&facet=dst";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            RootCoord root = JsonConvert.DeserializeObject<RootCoord>(responsereader);

             //Coordinate coord = new Coordinate();
             double[] coords = { 0.0, 0.0 };
             coords[0] = root.records[0].fields.latitude;
             coords[1] = root.records[0].fields.longitude;

            return coords;
        }
    }
}
