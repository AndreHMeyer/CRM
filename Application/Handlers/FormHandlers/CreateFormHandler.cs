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

namespace Application.Handlers.FormHandlers
{
    public class CreateFormHandler
    {
        private IFormTemplateRepository FormTemplateRepository { get; set; }
        private IMailMarketingListRepository MailRepository { get; set; }

        public CreateFormHandler(MySqlConnection con)
        {
            FormTemplateRepository = new FormTemplateRepository(con);
            MailRepository = new MailMarketingListRepository(con);
        }

        public ResultModel<long> Handle(long ProjectId)
        {
            try
            {
                FormTemplate template = new();
                template.IdMailMarketingList = MailRepository.GetMailMarketingListByIdProject(ProjectId).Result.Id;
                var r = FormTemplateRepository.Create(template).Result;
                return new Result<long>().CreateSucess(r);
            }
            catch(Exception ex)
            {
                return new Result<long>().CreateErro(ex.Message);
            }
        }
    }
}
