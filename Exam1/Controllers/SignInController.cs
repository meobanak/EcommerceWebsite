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
        private IRegister iregister;
        

        public SignInController(IRegister service)
        {
            iregister = service;
        }


        public IActionResult Login([Bind("ID,Email,FirstName,LastName,Password")] User model)
        {
            List<User> users = iregister.ListUser();
            IEnumerable<dynamic> products = iregister.ListProduct();
            ViewBag.Categories = iregister.CategoriesList();
            ViewBag.Size = iregister.SizeList();

            foreach (User user in users)
            {
                if (user.Email == model.Email && user.Password == model.Password)
                {
                    return View("~/Views/Admin/Maintenance.cshtml", products);
                }
            }
            return View(null);
        }
    }
}
