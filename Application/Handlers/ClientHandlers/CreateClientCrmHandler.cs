﻿using CrmAuth.Domain.Model;
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

namespace Application.Handlers.ClientHandlers
{
    public class CreateClientCrmHandler
    {
        private IClientCrmRepository clientCrmRepository;

        public CreateClientCrmHandler(MySqlConnection mySqlConnection)
        {
            clientCrmRepository = new ClientCrmRepository(mySqlConnection);
        }
        public ResultModel<long> Handle(ClientCrm client)
        {
            try
            {
                ResultModel<long> ResultClient = new();

                ResultClient.Model = clientCrmRepository.CreateClientCrm(client).Result;

                ResultClient.Success = true;

                return ResultClient;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
