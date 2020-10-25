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
    public class MongoDB_Register
    {
        private IMongoDatabase DB;

        public MongoDB_Register(IDataContext db)
        {
            DB = db.GetDatabase<IMongoDatabase>();
        }

        public void InsertUser(Dictionary<string, object> param)
        {
            User model = param.DictionaryToObject<User>();
            DB.GetCollection<User>().InsertOne(model);
        }

        public void UpdateUser(Dictionary<string, object> param)
        {
            var filter = Builders<User>.Filter.Eq(x => x.ID, Convert.ToInt32(param["ID"]));
            DB.GetCollection<User>().UpdateOneExtend(filter, param);
        }

        public User GetUser(Dictionary<string, object> param)
        {
            var filter = Builders<User>.Filter.Eq(x => x.ID, Convert.ToInt32(param["ID"]));
            return DB.GetCollection<User>().Find(filter).FirstOrDefault();
        }

        public IList<Dictionary<string, object>> ListUser()
        {
            return (IList<Dictionary<string, object>>)DB.GetCollection<User>().Find(new BsonDocument());
        }

        public IEnumerable<dynamic> ListProduct()
        {
            List<Product> products = DB.GetCollection<Product>().Find(new BsonDocument()).ToList();
            List<Category> categories = DB.GetCollection<Category>().Find(new BsonDocument()).ToList();
            List<FSize> sizes = DB.GetCollection<FSize>().Find(new BsonDocument()).ToList();

            var query = from product in products
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
                        }.ToExpando();

            return query;
        }

        public object GetProduct(Dictionary<string, object> _product)
        {
            var ob = _product.JsonObjectToDictionary();
            var productID = Convert.ToInt32(ob.FirstOrDefault(a => a.Key == "productID").Value);

            List<Product> products = DB.GetCollection<Product>().Find(new BsonDocument()).ToList();
            List<Category> categories = DB.GetCollection<Category>().Find(new BsonDocument()).ToList();
            List<FSize> sizes = DB.GetCollection<FSize>().Find(new BsonDocument()).ToList();

            var query = from product in products
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
                        }.ToExpando();

            return query;
        }


        public IList<FSize> SizeList()
        {
            return DB.GetCollection<FSize>().Find(new BsonDocument()).ToList();
        }

        public IList<Category> CategoriesList()
        {
            return DB.GetCollection<Category>().Find(new BsonDocument()).ToList();
        }

        public IList<FColor> ColorList()
        {
            return DB.GetCollection<FColor>().Find(new BsonDocument()).ToList();
        }

        public void InsertProduct(Dictionary<string, object> param)
        {
            Product product = param.DictionaryToObject<Product>();
            DB.GetCollection<Product>().InsertOne(product);
        }

        public void UpdateProduct(Dictionary<string, object> param)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.ID, Convert.ToInt32(param["ID"]));
            DB.GetCollection<Product>().UpdateOneExtend(filter, param);
        }
    }
}
