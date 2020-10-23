using EcommerceWebsite.Extensions;
using Exam1.Models;
using Exam1.Service.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Service.MongoDB.EcommerceFashionService
{
    public class MongoDB_Index
    {
        private IMongoDatabase DB;

        public MongoDB_Index(IDataContext data)
        {
            DB = data.GetDatabase<IMongoDatabase>();
        }

        public IList<Dictionary<string, object>> SizeList()
        {
            return (IList<Dictionary<string, object>>)DB.GetCollection<FSize>().Find(new BsonDocument());
        }

        public IList<Dictionary<string, object>> CategoriesList()
        {
            return (IList<Dictionary<string, object>>)DB.GetCollection<Category>().Find(new BsonDocument());
        }

        public Product Get(IDictionary<string, object> param)
        {

            return DB.GetCollection<Product>().FindOne(a => a.ID == Convert.ToInt32(param["ID"]));
        }

        public IList<Dictionary<string, object>> List()
        {
            return (IList<Dictionary<string, object>>)DB.GetCollection<Product>().Find(new BsonDocument());
        }

        public int Delete(IDictionary<string, object> param)
        {
            return DB.GetCollection<Product>().DeleteMany(
                a => a.ID == Convert.ToInt32(param["ID"])
                );
        }
    }
}
