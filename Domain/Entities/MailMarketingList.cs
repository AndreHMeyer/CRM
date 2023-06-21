using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MailMarketingList
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public bool Status { get; set; }
        public int IdProject { get; set; }
        public int IdMail { get; set; }
    }
}
