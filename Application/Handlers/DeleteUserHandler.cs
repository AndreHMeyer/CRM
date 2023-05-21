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
    public class DeleteUserHandler
    {
        private IUserRepository userRepository;

        public DeleteUserHandler(MySqlConnection mySqlConnection)
        {
            userRepository = new UserRepository(mySqlConnection);
        }
        public User Handle(User user)
        {
            try
            {
                return userRepository.DeleteUser(user).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
