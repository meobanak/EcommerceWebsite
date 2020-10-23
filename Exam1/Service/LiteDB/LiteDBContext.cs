using EcommerceWebsite.Database;
using EcommerceWebsite.Service.Interface;
using Exam1.Models;
using Exam1.Service.Interface;
using LiteDB;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Exam1.Service.LiteDB
{
    public class LiteDBContext : IDataContext 
    {
        private ILiteDatabase Database { get; set; }
        public LiteDBContext(IOptions<LiteDBOption> options)
        {
            Database = new LiteDatabase(options.Value.DatabaseLocation) ;
        }

        public T GetDatabase<T>()
        {
            return (T)Database;
        }    



    }
}
