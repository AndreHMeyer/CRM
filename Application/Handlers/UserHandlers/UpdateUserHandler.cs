using CrmAuth.Domain.Model;
using Domain.Entities;
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
    public class UpdateUserHandler
    {
        private IUserRepository userRepository;

        public UpdateUserHandler(MySqlConnection mySqlConnection)
        {
            userRepository = new UserRepository(mySqlConnection);
        }
        public ResultModel<User> Handle(User user)
        {
            try
            {
                var result = userRepository.UpdateUser(user).Result;
                return new Result<User>().CreateSucess(result);
            }
            catch (Exception ex)
            {
                return new Result<User>().CreateErro(ex.Message);
            }
        }
    }
}
