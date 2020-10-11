using EcommerceWebsite.Extensions;
using EcommerceWebsite.Service.Interface;
using Exam1.Extensions;
using Exam1.Models;
using Exam1.Service.LiteDB;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Service.LiteDB.EcomerceFashionService
{
    public class LiteDB_Register
    {
        private LiteDatabase DB;

        public LiteDB_Register(DataContext db)
        {
            DB = db.Database;
        }

        public bool InsertUser(Dictionary<string, object> param)
        {
            User model = param.DictionaryToObject<User>();
            return DB.GetCollectionDBModel<User>().Insert(model);
        }

        public bool UpdateUser(Dictionary<string, object> param)
        {
            User model = param.DictionaryToObject<User>();
            return DB.GetCollectionDBModel<User>().Update(model);
        }

        public User GetUser(Dictionary<string,object> param)
        {
            return DB.GetCollectionDBModel<User>().FindOne(a => a.ID == Convert.ToInt32(param["ID"]));
        }

        public IList<User> ListUser()
        {
            return DB.GetCollectionDBModel<User>().FindAll().ToList();
        }

        public IEnumerable<dynamic> ListProduct()
        {
            List<Product> products = DB.GetCollectionDBModel<Product>().FindAll().ToList();
            List<Category> categories = DB.GetCollectionDBModel<Category>().FindAll().ToList();
            List<FSize> sizes = DB.GetCollectionDBModel<FSize>().FindAll().ToList();

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

        public object GetProduct(Dictionary<string,object> _product)
        {
            var ob = _product.JsonObjectToDictionary();
            var productID = Convert.ToInt32(ob.FirstOrDefault(a => a.Key == "productID").Value);

            List <Product> products = DB.GetCollectionDBModel<Product>().FindAll().ToList();
            List<Category> categories = DB.GetCollectionDBModel<Category>().FindAll().ToList();
            List<FSize> sizes = DB.GetCollectionDBModel<FSize>().FindAll().ToList();

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
            return DB.GetCollectionDBModel<FSize>().FindAll().ToList();
        }

        public IList<Category> CategoriesList()
        {
            return DB.GetCollectionDBModel<Category>().FindAll().ToList();
        }

        public IList<FColor> ColorList()
        {
            return DB.GetCollectionDBModel<FColor>().FindAll().ToList();
        }

        public bool InsertProduct(Dictionary<string, object> param)
        {
            Product product = param.DictionaryToObject<Product>();
            return DB.GetCollectionDBModel<Product>().Insert(product);
        }

        public bool UpdateProduct(Dictionary<string, object> param)
        {
            Product result = param.DictionaryToObject<Product>();
            return DB.GetCollectionDBModel<Product>().Update(result);
        }
    }

}
