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
    public class UpdateProjectAcessHandler
    {
        private IProjectAcessRepository projectAcessRepository;

        public UpdateProjectAcessHandler(MySqlConnection mySqlConnection)
        {
            projectAcessRepository = new ProjectAcessRepository(mySqlConnection);
        }
        public ResultModel<ProjectAcess> Handle(ProjectAcess projectAcess)
        {
            try
            {
                var result = projectAcessRepository.UpdateProjectAcess(projectAcess).Result;
                return new Result<ProjectAcess>().CreateSucess(result);
            }
            catch (Exception ex)
            {
                return new Result<ProjectAcess>().CreateErro(ex.Message);
            }
        }
    }
}
