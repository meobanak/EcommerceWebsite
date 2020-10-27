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
        private ILiteDatabase DB;

        //public LiteDB_Index(DataContext data, IDBInit init)
        //{
        //    DB = data.Database;
        //    init.InitDB();
        //}

        public LiteDB_Index(IDataContext data)
        {
            DB = data.GetDatabase<ILiteDatabase>();
        }

        public List<Dictionary<string, object>> SizeList()
        {
            return (List<Dictionary<string, object>>)DB.GetCollectionDBModel<FSize>().FindAll();
        }

        public List<Dictionary<string, object>> CategoriesList()
        {
            return (List<Dictionary<string, object>>)DB.GetCollectionDBModel<Category>().FindAll();
        }

        public Product Get(IDictionary<string, object> param)
        {
            
            return DB.GetCollectionDBModel<Product>().FindOne(a => a.ID == Convert.ToInt32(param["ID"]));
        }

        public List<Dictionary<string, object>> List()
        {
            return (List<Dictionary<string, object>>)DB.GetCollectionDBModel<Product>().FindAll();
        }

        public int Delete(Dictionary<string, object> param)
        {
            return DB.GetCollectionDBModel<Product>().DeleteMany(a => a.ID == Convert.ToInt32(param["ID"]));
        }
    }
}
