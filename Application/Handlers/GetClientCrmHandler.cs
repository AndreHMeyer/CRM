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
    public class GetClientCrmHandler
    {
        private IClientCrmRepository clientCrmRepository;

        public GetClientCrmHandler(MySqlConnection mySqlConnection)
        {
            clientCrmRepository = new ClientCrmRepository(mySqlConnection);
        }
        public List<ClientCrm> Handle()
        {
            try
            {
                return clientCrmRepository.GetClientsCrm().Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }

    }
}
