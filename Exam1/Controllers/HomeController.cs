using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Exam1.Models;
using EcommerceWebsite.Service.Interface;

namespace Exam1.Controllers
{
    public class HomeController : Controller
    {
        private IDataProvider service;


        public HomeController(IDataProvider _service)
        {
            service = _service;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = service.QueryForList("LiteDB_Index", "List",null);
            return View(result);
        }

        [HttpGet("ID", Name ="GetOne")]
        public IActionResult Detail(int ID)
        {
            //var result = service.Get(ID);
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["ID"] = ID;
            var result = service.QueryForObject("LiteDB_Index", "Get",param);

            ViewBag.FSize = service.QueryForList("LiteDB_Index", "SizeList",null);
            return View("~/Views/Home/Detail.cshtml", result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { 
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
            });
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View("~/Views/Register/SignIn.cshtml");
        }
    }
}
