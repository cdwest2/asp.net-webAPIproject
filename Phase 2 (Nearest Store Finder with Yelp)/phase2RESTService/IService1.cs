using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace phase2RESTService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet (UriTemplate = "/store/{zip}/{storeName}")]
        string findNearestStore(string zip, string storeName);

        [OperationContract]
        double[] zipToCoord(string zip);



        // TODO: Add your service operations here
    }

    [DataContract]
    public class RootCoord
    {
        [DataMember]
        public List<Records> records = new List<Records>();
    }

    [DataContract]
    public class Records
    {
        [DataMember]
        public Fields fields { get; set; }
    }

    [DataContract]
    public class Fields
    {
        [DataMember]
        public double latitude { get; set; }

        [DataMember]
        public double longitude { get; set; }
    }

    [DataContract]
    public class RootYelp
    {
        [DataMember]
        public List<Business> businesses = new List<Business>();
    }

    [DataContract]
    public class Business
    {
       [DataMember]
       public string name { get; set; }
       [DataMember]
       public Location location { get; set; }
    }

    [DataContract]
    public class Location
    {
        [DataMember]
        public List<String> display_address = new List<String>();
    }

}
