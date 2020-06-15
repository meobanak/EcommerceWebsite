using Exam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Service.Interface
{
    public interface IRegister
    {
        bool Insert(User model);
        bool Update(User model);
        User GetUser(int ID);
        List<User> ListUser();
        IEnumerable<dynamic> ListProduct();
        List<FSize> SizeList();
        List<Category> CategoriesList();
    }
}
