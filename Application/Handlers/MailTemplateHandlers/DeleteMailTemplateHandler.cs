using CrmAuth.Domain.Model;
using Domain.Entities;
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
    public class DeleteMailTemplateHandler
    {
        private IMailTemplateRepository mailTemplateRepository;

        public DeleteMailTemplateHandler(MySqlConnection mySqlConnection)
        {
            mailTemplateRepository = new MailTemplateRepository(mySqlConnection);
        }
        public ResultModel<MailTemplate> Handle(MailTemplate mailTemplate)
        {
            try
            {
                var result = mailTemplateRepository.DeleteMailTemplates(mailTemplate).Result;
                return new Result<MailTemplate>().CreateSucess(result);
            }
            catch (Exception ex)
            {
                return new Result<MailTemplate>().CreateErro(ex.Message);
            }
        }
    }
}
