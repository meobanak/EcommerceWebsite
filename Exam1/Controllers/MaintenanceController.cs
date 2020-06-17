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
        private IRegister iregister;

        public MaintenanceController(IRegister service)
        {
            iregister = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit([FromBody]object product)
        {
            var result = product.JsonObjectToDictionary();
            return Json(product);
        }


        public IActionResult Delete()
        {
            return View();
        }
    }
}