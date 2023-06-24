using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProjectAcess
    {
        public int Id { get; set; }
        public int UserType { get; set; }
        public int IdProject { get; set; }
        public int IdUser { get; set; } 
    }
}
