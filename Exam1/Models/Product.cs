using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam1.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public int CategoryID { get; set; }
        public int ColorID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int Gender { get; set; }
        public int SizeID { get; set; }
        public string imageSrc { get; set; }
    }
}
