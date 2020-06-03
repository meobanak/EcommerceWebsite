using Exam1.Data.LiteDB;
using Exam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam1.Data
{
    public interface IServices
    {
        List<Motobike> List();
        Motobike Get(int ID);
        bool Insert(Motobike motobike);
        bool Update(Motobike motobike);
        int Delete(int ID);
    }
}
