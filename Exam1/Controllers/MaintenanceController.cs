using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        public IActionResult Edit( string ob)
        {

            //iregister.Update(product);
            return View();
        }


        public IActionResult Delete()
        {
            return View();
        }
    }
}