using Exam1.Models;
using LiteDB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Exam1.LiteDB.Data
{
    public class LiteDBContext : ILiteDBContext
    {
        public LiteDatabase Database { get; set; }

        public LiteDBContext(IOptions<LiteDBOptions> options)
        {
            Database = new LiteDatabase(options.Value.DatabaseLocation);
        }

       
    }
}
