using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProjectData
    {
        public int Id { get; set; }
        public double Revenue { get; set; }
        public int NumberOfClients { get; set; }
        public string ProjectName { get; set; }
        public int IdProject { get; set; }
    }
}
