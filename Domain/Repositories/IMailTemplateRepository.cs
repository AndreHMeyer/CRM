using CrmAuth.Domain.Model;
using Domain.Entities;
using Domain.Filters;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IMailTemplateRepository
    {
        Task<ResultModel<PaginationResult<MailTemplate>>> GetMailTemplates(MailTemplateFilter filter);
        Task<long> CreateMailTemplates(MailTemplate mailTemplate);
        Task<MailTemplate> UpdateMailTemplates(MailTemplate mailTemplate);
        Task<MailTemplate> DeleteMailTemplates(MailTemplate mailTemplate);
    }
}
