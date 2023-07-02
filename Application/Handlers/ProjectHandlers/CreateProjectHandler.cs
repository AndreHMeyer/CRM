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

namespace Application.Handlers.ProjectHandlers
{
    public class CreateProjectHandler
    {
        private IProjectRepository projectRepository;

        public CreateProjectHandler(MySqlConnection mySqlConnection)
        {
            projectRepository = new ProjectRepository(mySqlConnection);
        }

        public ResultModel<long> Handle(Project project)
        {
            try
            {
                var result = projectRepository.CreateProject(project).Result;
                return new Result<long>().CreateSucess(result);
            }
            catch (Exception ex)
            {
                return new Result<long>().CreateErro(ex.Message);
            }
        }
    }
}
