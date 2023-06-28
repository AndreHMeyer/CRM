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
    public class DeleteProjectAcessHandler
    {
        private IProjectAcessRepository projectAcessRepository;

        public DeleteProjectAcessHandler(MySqlConnection mySqlConnection)
        {
            projectAcessRepository = new ProjectAcessRepository(mySqlConnection);
        }

        public ProjectAcess Handle(ProjectAcess projectAcess)
        {
            try
            {
                return projectAcessRepository.DeleteProjectAcess(projectAcess).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
