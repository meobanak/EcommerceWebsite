using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Service.Interface
{
    public interface IDataProvider
    {
        IList<Dictionary<string, object>> QueryForList(string ServiceName, string action, Dictionary<string, object> param);

        IDictionary<string, object> QueryForObject(string ServiceName, string action, Dictionary<string, object> param);
    }
}
