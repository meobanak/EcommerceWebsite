using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam1.Models
{
    public class ProductPrice
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Percent { get; set; }
    }
}
