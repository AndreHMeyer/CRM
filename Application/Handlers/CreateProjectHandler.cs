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
    public class CreateProjectHandler
    {
        private IProjectRepository projectRepository;

        public CreateProjectHandler(MySqlConnection mySqlConnection)
        {
            projectRepository = new ProjectRepository(mySqlConnection);
        }

        public long Handle(Project project)
        {
            try
            {
                return projectRepository.CreateProject(project).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
