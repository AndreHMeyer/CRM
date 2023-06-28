﻿using Domain.Entities;
using Domain.Repositories;
using Infra.Repositories;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.ClientHandlers
{
    public class UpdateClientCrmHandler
    {
        private IClientCrmRepository clientRepository;

        public UpdateClientCrmHandler(MySqlConnection mySqlConnection)
        {
            clientRepository = new ClientCrmRepository(mySqlConnection);
        }

        public ClientCrm Handle(ClientCrm client)
        {
            try
            {
                return clientRepository.UpdateClientCrm(client).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
