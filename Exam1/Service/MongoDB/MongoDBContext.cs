using EcommerceWebsite.Service.DBOptions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Service.LiteDB
{
    public class MongoDBContext
    {
        public IMongoDatabase Database { get; set; }
        public MongoDBContext(IOptions<MongoDBOption> options)
        {
            var client = new MongoClient(options.Value.DatabaseLocation);
            Database = client.GetDatabase("FashionShop");
        }
    }
}
