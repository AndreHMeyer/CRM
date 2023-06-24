using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public string TableLog { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public int IdUser { get; set; }
    }
}
