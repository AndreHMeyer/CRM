using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IMailTemplateRepository
    {
        Task<List<MailTemplate>> GetMailTemplates();
        Task<long> CreateMailTemplates(MailTemplate mailTemplate);
        Task<MailTemplate> UpdateMailTemplates(MailTemplate mailTemplate);
        Task<MailTemplate> DeleteMailTemplates(MailTemplate mailTemplate);
    }
}
