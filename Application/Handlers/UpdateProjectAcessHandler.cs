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
    public class UpdateProjectAcessHandler
    {
        private IProjectAcessRepository projectAcessRepository;

        public UpdateProjectAcessHandler(MySqlConnection mySqlConnection)
        {
            projectAcessRepository = new ProjectAcessRepository(mySqlConnection);
        }
        public ProjectAcess Handle(ProjectAcess projectAcess)
        {
            try
            {
                return projectAcessRepository.UpdateProjectAcess(projectAcess).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
