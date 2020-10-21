using EcommerceWebsite.Database;
using EcommerceWebsite.Service.Interface;
using Exam1.Service.LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Service.MongoDB
{
    public class MongoDBDataProvider : IDataProvider
    {
        IDataContext datacontext;
        public MongoDBDataProvider(IDBInit init, IDataContext _data)
        {
            datacontext = _data;
            init.InitDB();
        }

        public IList<Dictionary<string, object>> QueryForList(string ServiceName, string action, Dictionary<string, object> param)
        {

            return null;
        }


        public Dictionary<string, object> QueryForObject(string ServiceName, string action, Dictionary<string, object> param)
        {
            return null;
        }
    }

}
