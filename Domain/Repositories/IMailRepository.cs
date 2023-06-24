using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IMailRepository
    {
        Task<List<Mail>> GetMails();
        Task<long> CreateMail(Mail mail);
        Task<Mail> UpdateMail(Mail mail);
        Task<Mail> DeleteMail(Mail mail);
    }
}
