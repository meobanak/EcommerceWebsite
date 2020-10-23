using EcommerceWebsite.Service.DBOptions;
using Exam1.Service.Interface;
using Exam1.Service.LiteDB;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Service.LiteDB
{
    public class MongoDBContext : IDataContext
    {
        private IMongoDatabase Database { get; set; }
        public MongoDBContext(IOptions<MongoDBOption> options)
        {
            var client = new MongoClient(options.Value.DatabaseLocation);
            Database = client.GetDatabase("FashionShop");
        }

        public T GetDatabase<T>()
        {
            return (T)Database;
        }
    }
}
