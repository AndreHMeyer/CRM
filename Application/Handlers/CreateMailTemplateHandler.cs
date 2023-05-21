using Domain.Entities;
using Domain.Repositories;
using Infra.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class CreateMailTemplateHandler
    {
        private IMailTemplateRepository mailTemplateRepository;

        public CreateMailTemplateHandler(MySqlConnection mySqlConnection)
        {
            mailTemplateRepository = new MailTemplateRepository(mySqlConnection);
        }
        public long Handle(MailTemplate mailTemplate)
        {
            try
            {
                return mailTemplateRepository.CreateMailTemplates(mailTemplate).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
