using EcommerceWebsite.Database;
using EcommerceWebsite.Service.Interface;
using EcommerceWebsite.Service.MongoDB.EcommerceFashionService;
using Exam1.Service.Interface;
using Exam1.Service.LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Service.MongoDB
{
    public class MongoDBDataProvider : IDataProvider
    {
        IDataContext datacontext;
        public MongoDBDataProvider(IDBInit init, IDataContext _data)
        {
            datacontext = _data;
            init.InitDB();
        }

        public IList<Dictionary<string, object>> QueryForList(string ServiceName, string action, Dictionary<string, object> param)
        {
            if (ServiceName == "Index")
            {
                MongoDB_Index IndexService = new MongoDB_Index(datacontext);
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
            return null;
        }
    }

}
