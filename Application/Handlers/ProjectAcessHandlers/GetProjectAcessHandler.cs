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
    public class GetProjectAcessHandler
    {
        private IProjectAcessRepository projectAcessRepository;

        public GetProjectAcessHandler(MySqlConnection mySqlConnection)
        {
            projectAcessRepository = new ProjectAcessRepository(mySqlConnection);
        }

        public List<ProjectAcess> Handle()
        {
            try
            {
                return projectAcessRepository.GetProjectsAcess().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
