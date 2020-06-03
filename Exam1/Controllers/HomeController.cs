using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Exam1.Models;
using Exam1.Data;
using Exam1.Data.Interface;
using Exam1.Data.LiteDB;

namespace Exam1.Controllers
{
    public class HomeController : Controller
    {
        private IProduct service;

        public HomeController(IProduct services)
        {
            service = services;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = service.List();
            return View(result);
        }
        [HttpGet("ID", Name ="GetOne")]
        public IActionResult Detail(int ID)
        {
            var result = service.Get(ID);
            return View(result);
        }
        [HttpPost]
        public IActionResult Insert(Product ID)
        {
            var result = service.Insert(ID);
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
