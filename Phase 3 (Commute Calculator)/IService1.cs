using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace phase3ElectiveService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(UriTemplate = "/commute/{address1}/{address2}")]
        string getCommute(string address1, string address2);

        [OperationContract]
        [WebGet(UriTemplate = "/commuteRating/{address1}/{address2}")]
        string calculateRating(string address1, string address2);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class RootObject
    {

        [DataMember]
        public List<ResourceSet> resourceSets = new List<ResourceSet>();

    }

    [DataContract]
    public class ResourceSet
    {
        [DataMember]
        public List<Resource> resources = new List<Resource>();    
    }

    [DataContract]
    public class Resource
    {
        [DataMember]
        public string travelDuration { get; set; }
    }

    [DataContract]
    public class Commute
    {
        [DataMember]
        public string routeTime { get; set; }
        [DataMember]
        public int rating { get; set; }
    }
}
