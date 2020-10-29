using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWebsite.Service.Interface;
using Exam1.Service.LiteDB;
using Exam1.Models;


namespace EcommerceWebsite.Controllers
{
    public class SignInController : Controller
    {
        private IDataProvider service;


        public SignInController(IDataProvider _service)
        {
            service = _service;
        }

        public IActionResult Login([Bind("ID,Email,FirstName,LastName,Password")] Dictionary<string, object> model)
        {
            ViewBag.Products = service.QueryForList("Register","ListProduct",null);
            ViewBag.Categories = service.QueryForList("Register", "CategoriesList", null);
            ViewBag.Size = service.QueryForList("Register", "SizeList",null);
            ViewBag.Colors = service.QueryForList("Register", "ColorList", null);

            if (CheckUserExist(model))
            {
                return View("~/Views/Admin/Maintenance.cshtml");
            }

            return View(null);
        }

        private bool CheckUserExist(Dictionary<string, object> param)
        {
            var user = service.QueryForObject("Register", "GetUser", param);
            if (user != null)
                return true;
            else
                return false;
        }
    }
}
