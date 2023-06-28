﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Evening.Data.Helprs
{
    public class DataResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
    public class DataResult<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }
    }
}
