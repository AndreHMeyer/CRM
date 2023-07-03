/*using CrmAuth.Domain.Model;
using Domain.Entities;
using Domain.Filters;
using Domain.Model;
using Domain.Repositories;
using Infra.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.ValidateUser
{
    public class ValidateUserAccess
    {
        private IUserRepository userRepository;
        private IProjectRepository projectRepository;

        public ValidateUserAccess(MySqlConnection mySqlConnection)
        {
            userRepository = new UserRepository(mySqlConnection);
            projectRepository = new ProjectRepository(mySqlConnection);
        }

        public async Task<ResultModel<PaginationResult<Project>>> GetProjectsByUser(ProjectFilter filter, long userId)
        {
            try
            {
                // Verifica se o usuário existe
                var userFilter = new UserFilter { Id = userId };
                var userResult = await userRepository.GetUsers(userFilter);
                if (userResult.Data.Count == 0)
                {
                    throw new Exception("Usuário não encontrado.");
                }

                // Adicionar o ID do usuário no filtro de projeto
                filter.idUserOwner = userId;

                // Obter os projetos associados ao usuário
                return await projectRepository.GetProjects(filter);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na validação do usuário: " + ex.Message);
            }
        }
    }
}*/
