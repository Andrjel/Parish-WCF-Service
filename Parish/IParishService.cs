using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Parish
{
    [ServiceContract]
    public interface IParishService
    {
        [OperationContract]
        [WebGet(UriTemplate = "v1/parishes", RequestFormat = WebMessageFormat.Json)]
        List<Parish> GetParishes();

        [OperationContract]
        [WebGet(UriTemplate = "v1/parishes/{id}", RequestFormat = WebMessageFormat.Json)]
        Parish GetParish(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "v1/parishes", Method = "POST", RequestFormat = WebMessageFormat.Json)]
        void AddParish(Parish parish);
    }
}
