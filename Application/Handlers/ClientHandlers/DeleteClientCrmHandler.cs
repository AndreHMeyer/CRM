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

namespace Application.Handlers.ClientHandlers
{
    public class DeleteClientCrmHandler
    {
        private IClientCrmRepository clientCrmRepository;

        public DeleteClientCrmHandler(MySqlConnection mySqlConnection)
        {
            clientCrmRepository = new ClientCrmRepository(mySqlConnection);
        }
        public ResultModel<ClientCrm> Handle(ClientCrm client)
        {
            try
            {
                var result = clientCrmRepository.DeleteClientCrm(client).Result;
                return new Result<ClientCrm>().CreateSucess(result);
            }
            catch (Exception ex)
            {
                return new Result<ClientCrm>().CreateErro(ex.Message);
            }
        }
    }
}
