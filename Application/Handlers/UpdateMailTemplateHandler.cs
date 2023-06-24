using Domain.Entities;
using Domain.Repositories;
using Infra.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewFolder
{
    public class UpdateMailTemplateHandler
    {
        private IMailTemplateRepository mailTemplateRepository;

        public UpdateMailTemplateHandler(MySqlConnection mySqlConnection)
        {
            mailTemplateRepository = new MailTemplateRepository(mySqlConnection);
        }
        public MailTemplate Handle(MailTemplate mailTemplate)
        {
            try
            {
                return mailTemplateRepository.UpdateMailTemplates(mailTemplate).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
