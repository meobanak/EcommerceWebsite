using EcommerceWebsite.Service.Interface;
using LiteDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam1.Service.Interface
{
    public interface IDataContext
    {
        T GetDatabase<T>();
    }
}
