﻿using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam1.Service.LiteDB
{
    public interface DataContext
    {
        LiteDatabase Database { get; set; }
    }
}