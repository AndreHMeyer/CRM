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
    public class ExcluirFormHandler
    {
        private IFormTemplateRepository FormTemplateRepository { get; set; }

        public ExcluirFormHandler(MySqlConnection con)
        {
            FormTemplateRepository = new FormTemplateRepository(con);
        }

        public ResultModel<long> Handle(long Id)
        {
            try
            {
                var r = FormTemplateRepository.Delete(Id).Result;
                return new Result<long>().CreateSucess(r);
            }
            catch (Exception ex)
            {
                return new Result<long>().CreateErro(ex.Message);
            }
        }
    }
}
