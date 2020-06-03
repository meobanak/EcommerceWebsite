using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam1.Extensions
{
    public static class LiteDBExtension
    {
        public static ILiteCollection<T> GetCollectionDBModel<T>(this LiteDatabase db)
        {
            ILiteCollection<T> model;
            model = db.GetCollection<T>(typeof(T).Name.ToString());
            return model;
        }
    }
}
