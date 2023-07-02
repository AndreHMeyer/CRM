using Domain.Entities;
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
    public class DeleteClientCrmHandler
    {
        private IClientCrmRepository clientCrmRepository;

        public DeleteClientCrmHandler(MySqlConnection mySqlConnection)
        {
            clientCrmRepository = new ClientCrmRepository(mySqlConnection);
        }
        public ClientCrm Handle(ClientCrm client)
        {
            try
            {
                return clientCrmRepository.DeleteClientCrm(client).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
