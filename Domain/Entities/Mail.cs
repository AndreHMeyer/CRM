using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Mail
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int IdMailTemplate { get; set; }
    }
}
