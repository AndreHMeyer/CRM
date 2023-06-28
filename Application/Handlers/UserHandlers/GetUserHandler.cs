using CrmAuth.Domain.Model;
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

namespace Application.Handlers.UserHandlers
{
    public class GetUserHandler
    {
        private IUserRepository userRepository;

        public GetUserHandler(MySqlConnection mySqlConnection)
        {
            userRepository = new UserRepository(mySqlConnection);
        }
        public ResultModel<PaginationResult<User>> Handle(UserFilter filter)
        {
            try
            {
                return userRepository.GetUsers(filter).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }

    }
}
