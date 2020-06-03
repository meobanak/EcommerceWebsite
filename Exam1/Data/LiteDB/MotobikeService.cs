using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam1.Extensions;
using Exam1.LiteDB.Data;
using Exam1.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace Exam1.Data.LiteDB
{
    public class MotobikeService : IServices
    {

        private LiteDatabase DB;

        public MotobikeService(ILiteDBContext liteDBContext)
        {
            DB = liteDBContext.Database;
        }

        private void InitDB()
        {
            Motobike moto = new Motobike();
            moto.ID = 1;
            moto.Name = "Honda CB400SF";
            moto.Price = 8500;
            moto.Description = "inline four Smooth";
            moto.imgSrc = "https://lopxemay.vn/images/thumbs/catalogues/cb400-274.jpg";
            DB.GetCollectionDBModel<Motobike>().Insert(moto);


            Motobike moto1 = new Motobike();
            moto1.ID = 2;
            moto1.Name = "Benneli 302";
            moto1.Price = 7500;
            moto1.Description = "2 cyclinder, Cheap";
            moto1.imgSrc = "https://tayamotor.vn/wp-content/uploads/2017/11/1458913669_BN302-02.jpg";
            DB.GetCollectionDBModel<Motobike>().Insert(moto1);


            Motobike moto2 = new Motobike();
            moto2.ID = 3;
            moto2.Name = "Yamaha MT03";
            moto2.Price = 8000;
            moto2.Description = "2 cyclinder, Excited";
            moto2.imgSrc = "https://cms-i.autodaily.vn/du-lieu/2019/10/05/yamaha-mt-03-2020-3.jpg";
            DB.GetCollectionDBModel<Motobike>().Insert(moto2);

        }

        [HttpGet]
        public List<Motobike> List()
        {
            List<Motobike> motobikes = DB.GetCollectionDBModel<Motobike>().FindAll().ToList();
            if (motobikes == null || motobikes.Any() == false)
            {
                InitDB();
                motobikes = DB.GetCollectionDBModel<Motobike>().FindAll().ToList();
            }

            return motobikes;
        }

        [HttpGet("{id}", Name = "FindOne")]
        public Motobike Get(int ID)
        {
            return DB.GetCollectionDBModel<Motobike>().FindOne(a => a.ID == ID);
        }

        [HttpPost]
        public bool Insert(Motobike motobike)
        {
            return DB.GetCollectionDBModel<Motobike>().Insert(motobike);
        }


        [HttpPut]
        public bool Update(Motobike motobike)
        {
            return DB.GetCollectionDBModel<Motobike>().Update(motobike);
        }

        [HttpDelete("{ID}")]
        public int Delete(int ID)
        {
            return DB.GetCollectionDBModel<Motobike>().DeleteMany(a => a.ID == ID);
        }
    }
}
