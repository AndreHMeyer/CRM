using CrmAuth.Domain.Model;
using Domain.Entities;
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
    public class CreateUserHandler
    {
        private IUserRepository userRepository;

        public CreateUserHandler(MySqlConnection mySqlConnection)
        {
            userRepository = new UserRepository(mySqlConnection);
        }
        public ResultModel<long> Handle(User user)
        {
            try
            {
                ResultModel<long> ResultUser = new();

                ResultUser.Model = userRepository.CreateUser(user).Result;

                ResultUser.Success = true;

                return ResultUser;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
