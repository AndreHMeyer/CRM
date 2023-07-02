using CrmAuth.Domain.Model;
using Domain.Entities;
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
        private IClientCrmRepository clientCrmRepository;

        public UpdateClientCrmHandler(MySqlConnection mySqlConnection)
        {
            clientCrmRepository = new ClientCrmRepository(mySqlConnection);
        }

        public ResultModel<ClientCrm> Handle(ClientCrm clientCrm)
        {
            try
            {
                var result = clientCrmRepository.UpdateClientCrm(clientCrm).Result;
                return new Result<ClientCrm>().CreateSucess(result);
            }
            catch (Exception ex)
            {
                return new Result<ClientCrm>().CreateErro(ex.Message);
            }
        }
    }
}
