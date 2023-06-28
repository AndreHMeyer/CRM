using Domain.Entities;
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
    public class DeleteClientCrmHandler
    {
        private IClientCrmRepository clientRepository;

        public DeleteClientCrmHandler(MySqlConnection mySqlConnection)
        {
            clientRepository = new ClientCrmRepository(mySqlConnection);
        }
        public ClientCrm Handle(ClientCrm client)
        {
            try
            {
                return clientRepository.DeleteClientCrm(client).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }
    }
}
