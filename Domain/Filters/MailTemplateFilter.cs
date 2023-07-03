using Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Filters
{
    public class MailTemplateFilter : PaginationBase
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Data { get; set; }
        public long? IdProject { get; set; }
        public int? Status { get; set; }

    }
}
