using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Service.DBOptions
{
    public class MongoDBOption
    {
        public const string MongoDBOptions = "MongoDBOptions";
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
