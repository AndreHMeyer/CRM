﻿using Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Filters
{
    public class UserFilter : PaginationBase
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
    }
}
