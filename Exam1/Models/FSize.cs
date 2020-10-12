using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam1.Models
{
    public class FSize
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int ID { get; set; }
        public string Name { get; set; }
        public int OrderIndex { get; set; }
    }
}
