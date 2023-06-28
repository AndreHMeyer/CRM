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

        public long Handle(ProjectAcess projectAcess)
        {
            try
            {
                return projectAcessRepository.CreateProjectAcess(projectAcess).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
