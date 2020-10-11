using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EcommerceWebsite.Extensions;
using EcommerceWebsite.Service.Interface;
using Exam1.Models;
using Microsoft.AspNetCore.Mvc;


namespace EcommerceWebsite.Controllers
{
    public class MaintenanceController : Controller
    {
        private ILiteDBDataProvider service;

        public MaintenanceController(ILiteDBDataProvider _service)
        {
            service = _service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetProduct([FromBody]object product)
        {
            //var jsonresult = iregister.GetProduct(product);
            Dictionary<string, object> param = new Dictionary<string, object>();
            param = product.JsonObjectToDictionary();
            var jsonresult = service.QueryForObject("LiteDB_Register", "GetProduct", param);
            return Json(jsonresult);
        }

        [HttpPost]
        public IActionResult Edit([FromBody]object product)
        {
            //var _product = product.ToString();
            //iregister.Update(_product);
            Dictionary<string, object> param = new Dictionary<string, object>();
            param = product.JsonObjectToDictionary();
            var jsonresult = service.QueryForObject("LiteDB_Register", "UpdateProduct", param);
            return Json(jsonresult);
        }


        public IActionResult Delete()
        {
            return View();
        }
    }
}