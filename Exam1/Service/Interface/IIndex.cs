using Exam1.Service.Interface;
using Exam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam1.Service.Interface
{
    public interface IIndex
    {
        List<Product> List();
        Product Get(int ID);
        List<FSize> SizeList();
        bool Insert(Product motobike);
        bool Update(Product motobike);
        int Delete(int ID);
    }
}
