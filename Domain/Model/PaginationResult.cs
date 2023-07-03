using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class PaginationResult<T>
    {
        public List<T> Values { get; set; }
        public long Page { get; set; }
        public long RegistersPerPage { get; set; }
        public long Total { get; set; }
        public long TotalPages { get; set; }
    }
}
