using CrmAuth.Domain.Model;
using Domain.Entities;
using Domain.Filters;
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
    public class GetClientCrmHandler
    {
        private IClientCrmRepository clientCrmRepository;

        public GetClientCrmHandler(MySqlConnection mySqlConnection)
        {
            clientCrmRepository = new ClientCrmRepository(mySqlConnection);
        }
        public ResultModel<PaginationResult<ClientCrm>> Handle(ClientCrmFilter filter)
        {
            try
            {
                return clientCrmRepository.GetClientsCrm(filter).Result;
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }
        }

    }
}
