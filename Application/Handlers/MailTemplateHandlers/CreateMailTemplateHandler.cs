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
    public class CreateMailTemplateHandler
    {
        private IMailTemplateRepository mailTemplateRepository;

        public CreateMailTemplateHandler(MySqlConnection mySqlConnection)
        {
            mailTemplateRepository = new MailTemplateRepository(mySqlConnection);
        }
        public ResultModel<long> Handle(MailTemplate mailTemplate)
        {
            try
            {
                var result = mailTemplateRepository.CreateMailTemplates(mailTemplate).Result;
                return new Result<long>().CreateSucess(result);
            }
            catch (Exception ex)
            {
                return new Result<long>().CreateErro(ex.Message);
            }
        }
    }
}
