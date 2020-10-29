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
                MongoDB_Register RegisterService = new MongoDB_Register(datacontext);
                switch (action)
                {
                    case "ListUser":
                        return RegisterService.ListUser();
                        break;

                    case "ListProduct":
                        return RegisterService.ListProduct();
                        break;

                    case "SizeList":
                        return RegisterService.SizeList();
                        break;

                    case "CategoriesList":
                        return RegisterService.CategoriesList();
                        break;

                    case "ColorList":
                        return RegisterService.ColorList();
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


        public IDictionary<string, object> QueryForObject(string ServiceName, string action, Dictionary<string, object> param)
        {
            if (ServiceName == "Register")
            {
                MongoDB_Register RegisterService = new MongoDB_Register(datacontext);
                switch (action)
                {
                    case "InsertUser":
                        return RegisterService.InsertUser(param);
                        break;

                    case "UpdateUser":
                        return RegisterService.UpdateUser(param);
                        break;

                    case "GetUser":
                        return RegisterService.GetUser(param);
                        break;

                    case "GetProduct":
                        return RegisterService.GetProduct(param);
                        break;

                    case "InsertProduct":
                        return RegisterService.InsertProduct(param);
                        break;

                    case "UpdateProduct":
                        return RegisterService.UpdateProduct(param);
                        break;

                    default:
                        break;
                }
            }

            return null;
        }
    }

}
