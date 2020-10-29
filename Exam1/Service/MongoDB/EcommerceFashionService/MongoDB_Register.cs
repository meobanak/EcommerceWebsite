using EcommerceWebsite.Extensions;
using Exam1.Models;
using Exam1.Service.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using Nancy.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Service.MongoDB.EcommerceFashionService
{
    public class MongoDB_Register
    {
        private IMongoDatabase DB;

        public MongoDB_Register(IDataContext db)
        {
            DB = db.GetDatabase<IMongoDatabase>();
        }

        public Dictionary<string,object> InsertUser(Dictionary<string, object> param)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            bool rs = true;
            try
            {
                User model = param.DictionaryToObject<User>();
                DB.GetCollection<User>().InsertOne(model);
                rs = true;
                result["Result"] = rs;
            }
            catch (MongoWriteException e)
            {
                Console.WriteLine(e.Message);
                rs = false;
                result["Result"] = rs;
            }
            return result;
        }

        public Dictionary<string, object> UpdateUser(Dictionary<string, object> param)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            var filter = Builders<User>.Filter.Eq(x => x.ID, Convert.ToInt32(param["ID"]));
            ReplaceOneResult rs = DB.GetCollection<User>().ReplaceOne(filter, param.DictionaryToObject<User>());
            result["Result"] = rs.IsAcknowledged;
            return result;
        }

        public Dictionary<string, object> GetUser(Dictionary<string, object> param)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Email, param["email"].ToString());
            return DB.GetCollection<User>().Find(filter).FirstOrDefault().ObjectToDictionary();
        }

        public IList<Dictionary<string, object>> ListUser()
        {
            var filter = Builders<User>.Filter.Empty;
            return DB.GetCollection<User>().Find(filter).ToList().ToListDictionary();
        }

        public IList<Dictionary<string,object>> ListProduct()
        {
            IList<Product> products = DB.GetCollection<Product>().Find(new BsonDocument()).ToList();
            IList<Category> categories = DB.GetCollection<Category>().Find(new BsonDocument()).ToList();
            IList<FSize> sizes = DB.GetCollection<FSize>().Find(new BsonDocument()).ToList();

            var query = (from product in products
                         join category in categories on product.CategoryID equals category.ID
                         join size in sizes on product.SizeID equals size.ID
                         select new
                         {
                             ID = product.ID,
                             CategoryName = category.Name,
                             CategoryID = category.ID,
                             ProductName = product.Name,
                             Price = product.Price,
                             Size = size.Name,
                             SizeID = size.ID,
                             Gender = product.Gender == 1 ? "Male" : "Female"
                         }).ToList();


            return query.ToListDictionary();
        }

        public Dictionary<string,object> GetProduct(Dictionary<string, object> _product)
        {
            var ob = _product.JsonObjectToDictionary();
            var productID = Convert.ToInt32(ob.FirstOrDefault(a => a.Key == "productID").Value);

            List<Product> products = DB.GetCollection<Product>().Find(new BsonDocument()).ToList();
            List<Category> categories = DB.GetCollection<Category>().Find(new BsonDocument()).ToList();
            List<FSize> sizes = DB.GetCollection<FSize>().Find(new BsonDocument()).ToList();

            var query = (from product in products
                         join category in categories on product.CategoryID equals category.ID
                         join size in sizes on product.SizeID equals size.ID
                         where product.ID == productID
                         select new
                         {
                             ID = product.ID,
                             Code = product.Code,
                             CategoryID = product.CategoryID,
                             Color = product.ColorID,
                             ProductName = product.Name,
                             Price = product.Price,
                             Description = product.Description,
                             IsActive = product.IsActive,
                             Gender = product.Gender,
                             SizeID = product.SizeID,
                             imageSrc = product.imageSrc
                         }).FirstOrDefault();

            return query.ObjectToDictionary();
        }


        public IList<Dictionary<string,object>> SizeList()
        {
            var filter = Builders<FSize>.Filter.Empty;
            return DB.GetCollection<FSize>().Find(filter).ToList().ToListDictionary();
        }

        public IList<Dictionary<string,object>> CategoriesList()
        {
            var filter = Builders<Category>.Filter.Empty;
            return DB.GetCollection<Category>().Find(filter).ToList().ToListDictionary();
        }

        public IList<Dictionary<string, object>> ColorList()
        {
            var filter = Builders<FColor>.Filter.Empty;
            return DB.GetCollection<FColor>().Find(filter).ToList().ToListDictionary() ;
        }

        public Dictionary<string,object> InsertProduct(Dictionary<string, object> param)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            Product product = param.DictionaryToObject<Product>();
            bool rs = true;
            try
            {
                DB.GetCollection<Product>().InsertOne(product);
                result["Result"] = rs;
            }
            catch(MongoException ex)
            {
                rs = false;
                result["Result"] = rs;
                Console.WriteLine(ex);
            }

            return result;
        }

        public Dictionary<string, object> UpdateProduct(Dictionary<string, object> param)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            var filter = Builders<Product>.Filter.Eq(x => x.ID, Convert.ToInt32(param["ID"]));
            ReplaceOneResult rs =  DB.GetCollection<Product>().ReplaceOne(filter, param.DictionaryToObject<Product>());
            result["Result"] = rs.IsAcknowledged;
            return result;
        }
    }
}
