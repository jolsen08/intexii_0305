﻿using IntexII_0305.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexII_0305.Models.ViewModels
{
    public class RecordsViewModel
    {
        public IQueryable<Burialmain> burialmain { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}