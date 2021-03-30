using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace phase3Elective2Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(UriTemplate = "/restaurants/{preference1}/{preference2}/{zip}")]
        //[XmlSerializerFormat]
        string[] restaurants(string preference1, string preference2, string zip);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class RootYelp
    {
        [DataMember]
        public List<Business> businesses = new List<Business>();
        [DataMember]
        public int total { get; set; }
    }

    [DataContract]
    public class Business
    {
        [DataMember]
        public string name { get; set; }
    }
}
