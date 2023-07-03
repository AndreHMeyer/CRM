using CrmAuth.Domain.Model;
using Domain.Entities;
using Domain.Filters;
using Domain.Model;
using Domain.Repositories;
using Infra.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.MailTemplateHandlers
{
    public class GetMailTemplateHandler
    {
        private IMailTemplateRepository mailTemplateRepository;

        public GetMailTemplateHandler(MySqlConnection mySqlConnection)
        {
            mailTemplateRepository = new MailTemplateRepository(mySqlConnection);
        }
        public ResultModel<PaginationResult<MailTemplate>> Handle(MailTemplateFilter filter)
        {
            try
            {
                return mailTemplateRepository.GetMailTemplates(filter).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
