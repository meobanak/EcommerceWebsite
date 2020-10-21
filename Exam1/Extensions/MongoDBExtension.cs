using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Extensions
{
    public static class MongoDBExtension
    {
        public static IMongoCollection<T> GetCollection<T>(this IMongoDatabase db)
        {

            //MongoClient dbClient = new MongoClient("");
            IMongoCollection<T> collection;
            collection = db.GetCollection<T>(typeof(T).Name.ToString());
            return collection;
        }
    }
}
