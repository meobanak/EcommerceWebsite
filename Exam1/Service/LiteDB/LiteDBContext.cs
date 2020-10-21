using EcommerceWebsite.Database;
using Exam1.Models;
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
        public LiteDatabase LiteDBDatabase { get; set; }
        public IMongoDatabase MongoDBDatabase { get; set; }
        public LiteDBContext(IOptions<LiteDBOption> options)
        {
            LiteDBDatabase = new LiteDatabase(options.Value.DatabaseLocation);
        }



       
    }
}
