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

        public LiteDB_Register(ILiteDBContext db)
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
                            ProductName = product.Name,
                            Price = product.Price,
                            Size = size.Name,
                            Gender = product.Gender == 1 ? "Male" : "Female"
                        }.ToExpando();


            //var serializer = new JavaScriptSerializer();
            //serializer.RegisterConverters(new JavaScriptConverter[] { new ExpandoJSONConverter() });
            //var json = serializer.Serialize(obj);

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
    }

}
