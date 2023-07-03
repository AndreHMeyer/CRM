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

namespace Application.Handlers.FormHandlers
{
    public class GetFormHandler
    {
        private IFormTemplateRepository FormTemplateRepository { get; set; }

        public GetFormHandler(MySqlConnection con)
        {
            FormTemplateRepository = new FormTemplateRepository(con);
        }

        public ResultModel<PaginationResult<FormTemplate>> Handle(FormFilter filter)
        {
            try
            {
                return FormTemplateRepository.Get(filter).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
