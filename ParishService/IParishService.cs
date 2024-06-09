using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using Parish.Domain;
using System.Text;

namespace Parish
{
    [ServiceContract]
    public interface IParishService
    {
        [OperationContract]
        [WebGet(UriTemplate = "v1/parishes", RequestFormat = WebMessageFormat.Json)]
        List<ParishModel> GetParishes();

        [OperationContract]
        [WebGet(UriTemplate = "v1/parishes/{id}", RequestFormat = WebMessageFormat.Json)]
        ParishModel GetParish(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "v1/parishes", Method = "POST", RequestFormat = WebMessageFormat.Json)]
        void AddParish(ParishModel parish);
    }
}
