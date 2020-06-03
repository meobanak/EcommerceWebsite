using Exam1.Extensions;
using Exam1.LiteDB.Data;
using Exam1.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam1.Data
{
    public class MotobikeService 
    {


        public List<Motobike> List()
        {
            List<Motobike> motobikes = new List<Motobike>();
            Motobike moto = new Motobike();
            moto.ID = 1;
            moto.Name = "Honda CB400SF";
            moto.Price = 8500;
            moto.Description = "inline four Smooth";
            moto.imgSrc = "https://lopxemay.vn/images/thumbs/catalogues/cb400-274.jpg";
            motobikes.Add(moto);

            Motobike moto1 = new Motobike();
            moto1.ID = 2;
            moto1.Name = "Benneli 302";
            moto1.Price = 7500;
            moto1.Description = "2 cyclinder, Cheap";
            moto1.imgSrc = "https://tayamotor.vn/wp-content/uploads/2017/11/1458913669_BN302-02.jpg";
            motobikes.Add(moto1);


            Motobike moto2 = new Motobike();
            moto2.ID = 3;
            moto2.Name = "Yamaha MT03";
            moto2.Price = 8000;
            moto2.Description = "2 cyclinder, Excited";
            moto2.imgSrc = "https://cms-i.autodaily.vn/du-lieu/2019/10/05/yamaha-mt-03-2020-3.jpg";
            motobikes.Add(moto2);

            return motobikes;
        }

        

        public Motobike Get(int ID)
        {
            return null;
        }


        public bool Insert(Motobike motobike)
        {
            return false;
        }

        public bool Update(Motobike motobike)
        {
            return false;
        }

        public int Delete(int ID)
        {
            return 0;
        }



    }

}

