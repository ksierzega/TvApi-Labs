﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TvApi_Lab.Models
{
    public class ReviewRequest
    {
        public string Comment { get; set; }
        public short Rate { get; set; }
    }
}