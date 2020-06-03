using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam1.LiteDB.Data
{
    public interface ILiteDBContext
    {
        LiteDatabase Database { get; set; }
    }
}
