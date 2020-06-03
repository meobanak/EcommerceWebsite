using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Exam1.Controllers
{
    public class Exam1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetInformation()
        {

            return View();
        }
    } 
}