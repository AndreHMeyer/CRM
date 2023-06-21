using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StatusMail
    {
        public int Id { get; set; }
        public int SendStatus { get; set; }
        public int IdMail { get; set; }
    }
}
