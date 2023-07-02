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

namespace Application.Handlers.ProjectAcessHandlers
{
    public class CreateProjectAcessHandler
    {
        private IProjectAcessRepository projectAcessRepository;

        public CreateProjectAcessHandler(MySqlConnection mySqlConnection)
        {
            projectAcessRepository = new ProjectAcessRepository(mySqlConnection);
        }

        public ResultModel<long> Handle(ProjectAcess projectAcess)
        {
            try
            {
                var result = projectAcessRepository.CreateProjectAcess(projectAcess).Result;
                return new Result<long>().CreateSucess(result);
            }
            catch (Exception ex)
            {
                return new Result<long>().CreateErro(ex.Message);
            }
        }
    }
}
