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
    public class LiteDB_Register : IRegister
    {
        private LiteDatabase DB;

        public LiteDB_Register(DataContext db)
        {
            DB = db.Database;
        }

        public bool Insert(User model)
        {
            return DB.GetCollectionDBModel<User>().Insert(model);
        }

        public bool Update(User model)
        {
            return DB.GetCollectionDBModel<User>().Update(model);
        }

        public User GetUser(int ID)
        {
            return DB.GetCollectionDBModel<User>().FindOne(a => a.ID == ID);
        }

        public List<User> ListUser()
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

        public object GetProduct(object _product)
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


        public List<FSize> SizeList()
        {
            return DB.GetCollectionDBModel<FSize>().FindAll().ToList();
        }

        public List<Category> CategoriesList()
        {
            return DB.GetCollectionDBModel<Category>().FindAll().ToList();
        }

        public List<FColor> ColorList()
        {
            return DB.GetCollectionDBModel<FColor>().FindAll().ToList();
        }

        public bool Insert(Product product)
        {
            return DB.GetCollectionDBModel<Product>().Insert(product);
        }

        public bool Update(string productjson)
        {
            Product result = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(productjson);
            return DB.GetCollectionDBModel<Product>().Update(result);
        }
    }

}
