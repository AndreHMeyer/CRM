using Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Filters
{
    public class FormFilter : PaginationBase
    {
        public long Id { get; set; }
        public long IdProject { get; set; }
    }
}
