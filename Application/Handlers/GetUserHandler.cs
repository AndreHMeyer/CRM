﻿using Domain.Entities;
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
    public class GetUserHandler
    {
        private IUserRepository userRepository;

        public GetUserHandler(MySqlConnection mySqlConnection)
        {
            userRepository = new UserRepository(mySqlConnection);
        }
        public List<User> Handle()
        {
            try
            {
                return userRepository.GetUsers().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }

    }
}
