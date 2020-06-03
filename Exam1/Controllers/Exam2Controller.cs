using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam1.Data;
using Exam1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exam1.Controllers
{
    public class Exam2Controller : Controller
    {

        private IServices motoservice;
        private List<Motobike> motobikes;

        public Exam2Controller(IServices _service)
        {
            motoservice = _service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetList()
        {
            motobikes = motoservice.List();
            return View(motobikes);
        }

        public IActionResult Detail(int? ID)
        {
            if (ID == null)
                return View();
            else
            {
                var moto = motoservice.Get(ID.Value);
                return View(moto);
            }
        }

        [HttpGet("{ID}" , Name = "FindOne")]
        public IActionResult Edit(int? ID)
        {
            var moto = motoservice.Get(ID.Value);
            return View(moto);
        }

        [HttpDelete("{ID}")]
        public ContentResult Update(int? ID, [Bind("ID,Name,Price,Description,imgSrc")] Motobike moto)
        {
            motoservice.Update(moto);
            return Content("Save");
        }

    }
}