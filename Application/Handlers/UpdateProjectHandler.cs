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
    public class UpdateProjectHandler
    {
        private IProjectRepository projectRepository;

        public UpdateProjectHandler(MySqlConnection mySqlConnection)
        {
            projectRepository = new ProjectRepository(mySqlConnection);
        }
        public Project Handle(Project project)
        {
            try
            {
                return projectRepository.UpdateProject(project).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
