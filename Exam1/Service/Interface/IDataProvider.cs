using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Service.Interface
{
    public interface IDataProvider
    {
        IList<T> QueryForList<T>();
        T QueryForObject<T>(IDictionary<string,object> param);
    }
}
