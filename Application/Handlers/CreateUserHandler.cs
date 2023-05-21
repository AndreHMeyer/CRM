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
    public class CreateUserHandler
    {
        private IUserRepository userRepository;

        public CreateUserHandler(MySqlConnection mySqlConnection)
        {
            userRepository = new UserRepository(mySqlConnection);
        }
        public long Handle(User user)
        {
            try
            {
                return userRepository.CreateUser(user).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
