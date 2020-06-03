using Exam1.Data.LiteDB;
using Exam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam1.Data.Interface
{
    public interface IProduct
    {
        List<Product> List();
        Product Get(int ID);
        bool Insert(Product motobike);
        bool Update(Product motobike);
        int Delete(int ID);
    }
}
