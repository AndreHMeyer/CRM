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
    public class GetProjectHandler
    {
        private IProjectRepository projectRepository;

        public GetProjectHandler(MySqlConnection mySqlConnection)
        {
            projectRepository = new ProjectRepository(mySqlConnection);
        }

        public List<Project> Handle()
        {
            try
            {
                return projectRepository.GetProjects().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
