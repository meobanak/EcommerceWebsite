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
    public class LiteDB_Index 
    {
        private LiteDatabase DB;

        //public LiteDB_Index(DataContext data, IDBInit init)
        //{
        //    DB = data.Database;
        //    init.InitDB();
        //}

        public LiteDB_Index(IDataContext data)
        {
            DB = data.Database;
        }

        public IList<Dictionary<string, object>> SizeList()
        {
            return (IList<Dictionary<string, object>>)DB.GetCollectionDBModel<FSize>().FindAll();
        }

        public IList<Dictionary<string, object>> CategoriesList()
        {
            return (IList<Dictionary<string, object>>)DB.GetCollectionDBModel<Category>().FindAll();
        }

        public Product Get(IDictionary<string, object> param)
        {
            
            return DB.GetCollectionDBModel<Product>().FindOne(a => a.ID == Convert.ToInt32(param["ID"]));
        }

        public IList<Dictionary<string, object>> List()
        {
            return (IList<Dictionary<string, object>>)DB.GetCollectionDBModel<Product>().FindAll();
        }

        public int Delete(IDictionary<string, object> param)
        {
            return DB.GetCollectionDBModel<Product>().DeleteMany(a => a.ID == Convert.ToInt32(param["ID"]));
        }
    }
}
