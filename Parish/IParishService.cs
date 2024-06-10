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
    /// <summary>
    /// Parish service interface
    /// </summary>
    [ServiceContract]
    public interface IParishService
    {
        /// <summary>
        /// Get all parishes endpoint
        /// </summary>
        /// <returns>List of Parishes</returns>
        [OperationContract]
        [WebGet(UriTemplate = "v1/parishes", RequestFormat = WebMessageFormat.Json)]
        List<ParishModel> GetParishes();

        /// <summary>
        /// Get a parish by id endpoint
        /// </summary>
        /// <param name="id">Id of searched Parish</param>
        /// <returns>Parish object</returns>
        [OperationContract]
        [WebGet(UriTemplate = "v1/parishes/{id}", RequestFormat = WebMessageFormat.Json)]
        ParishModel GetParish(string id);

        /// <summary>
        /// Post a new parish endpoint
        /// </summary>
        /// <param name="parish"></param>
        [OperationContract]
        [WebInvoke(UriTemplate = "v1/parishes", Method = "POST", RequestFormat = WebMessageFormat.Json)]
        void AddParish(ParishModel parish);
    }
}
