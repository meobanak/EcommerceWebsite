using EcommerceWebsite.Database;
using EcommerceWebsite.Service.Interface;
using EcommerceWebsite.Service.LiteDB.EcomerceFashionService;
using Exam1.Service.Interface;
using Exam1.Service.LiteDB;
using Exam1.Service.LiteDB.EcomerceFashionService;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Service.LiteDB
{
    public class LiteDBDataProvider 
    {
        IDataContext datacontext;
        public LiteDBDataProvider(IDBInit init, IDataContext _data)
        {
            datacontext = _data;
            init.InitDB();
        }

        public List<Dictionary<string, object>> QueryForList(string ServiceName, string action, Dictionary<string, object> param)
        {
            if (ServiceName == "Index")
            {
                LiteDB_Index IndexService = new LiteDB_Index(datacontext);
                switch (action)
                {
                    case "SizeList":
                        return IndexService.SizeList();
                        break;

                    case "CategoriesList":
                        return IndexService.CategoriesList();
                        break;

                    case "List":
                        return IndexService.List();
                        break;

                    default:
                        break;
                }
            }

            if (ServiceName == "Register")
            {
                LiteDB_Register RegisterService = new LiteDB_Register(datacontext);
                switch (action)
                {
                    case "InsertUser":
                        RegisterService.InsertUser(param);
                        break;

                    case "UpdateUser":
                        RegisterService.UpdateUser(param);
                        break;

                    case "GetUser":
                        RegisterService.GetUser(param);
                        break;

                    case "ListUser":
                        RegisterService.ListUser();
                        break;

                    case "ListProduct":
                        RegisterService.ListProduct();
                        break;

                    case "GetProduct":
                        RegisterService.GetProduct(param);
                        break;

                    case "SizeList":
                        RegisterService.SizeList();
                        break;

                    case "CategoriesList":
                        RegisterService.CategoriesList();
                        break;

                    case "ColorList":
                        RegisterService.ColorList();
                        break;

                    case "InsertProduct":
                        RegisterService.InsertProduct(param);
                        break;

                    case "UpdateProduct":
                        RegisterService.UpdateProduct(param);
                        break;

                    default:
                        break;
                }
            }

            if (ServiceName == "Detail")
            {
                switch (action)
                {
                    default:
                        break;
                }
            }


            return null;
        }


        public Dictionary<string, object> QueryForObject(string ServiceName, string action, Dictionary<string, object> param)
        {
            if (ServiceName == "")
            {
                LiteDB_Index IndexService = new LiteDB_Index(datacontext);
                switch (action)
                {
                    case "Get":
                        IndexService.Get(param);
                        break;

                    case "Delete":
                        IndexService.Delete(param);
                        break;

                    default:
                        break;
                }
            }
            return null;
        }
    }
}
