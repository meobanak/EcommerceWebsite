﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWebsite.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebsite.Controllers
{
    public class MaintenanceController : Controller
    {
        private IRegister iregister;

        public MaintenanceController(IRegister service)
        {
            iregister = service;
            GetList();
        }

        public IActionResult GetList()
        {
            var listproduct = iregister.ListProduct();
            return View(listproduct);
        }
    }
}