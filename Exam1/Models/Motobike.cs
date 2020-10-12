using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam1.Models
{
    public class Motobike
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string imgSrc { get; set; }
    }


}
