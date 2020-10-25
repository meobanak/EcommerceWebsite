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

        public static void UpdateOneExtend<T>(this IMongoCollection<T> collectionName, FilterDefinition<T> filter, Dictionary<string, object> param)
        {
            foreach (var field in param)
            {
                var update = Builders<T>.Update.Set(param.Keys.ToString(), param.Values);
                collectionName.UpdateOne(filter, update);
            }
        }
    }
}
