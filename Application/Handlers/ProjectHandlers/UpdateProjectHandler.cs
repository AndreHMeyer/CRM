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
    public class UpdateProjectHandler
    {
        private IProjectRepository projectRepository;

        public UpdateProjectHandler(MySqlConnection mySqlConnection)
        {
            projectRepository = new ProjectRepository(mySqlConnection);
        }
        public ResultModel<Project> Handle(Project project)
        {
            try
            {
                var result = projectRepository.UpdateProject(project).Result;
                return new Result<Project>().CreateSucess(result);
            }
            catch (Exception ex)
            {
                return new Result<Project>().CreateErro(ex.Message);
            }
        }
    }
}
