using EcommerceWebsite.Database;
using Exam1.Extensions;
using Exam1.Service;
using Exam1.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam1.Service.Interface;

namespace Exam1.Service.LiteDB.EcomerceFashionService
{
    public class LiteDB_Index : IIndex
    {
        private LiteDatabase DB;

        public LiteDB_Index(ILiteDBContext data, IDBInit init)
        {
            DB = data.Database;
            init.InitDB();
        }

        public List<FSize> CategoryList()
        {
            return DB.GetCollectionDBModel<FSize>().FindAll().ToList();
        }

        public Product Get(int ID)
        {
            return DB.GetCollectionDBModel<Product>().FindOne(a => a.ID == ID);
        }

        public List<Product> List()
        {
            return DB.GetCollectionDBModel<Product>().FindAll().ToList();
        }

        public bool Insert(Product product)
        {
            return DB.GetCollectionDBModel<Product>().Insert(product);
        }

        public bool Update(Product product)
        {
            return DB.GetCollectionDBModel<Product>().Update(product);
        }

        public int Delete(int ID)
        {
            return DB.GetCollectionDBModel<Product>().DeleteMany(a => a.ID == ID);
        }
    }
}
