using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Pagination
{
    public class PaginationBase
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
    }
}
