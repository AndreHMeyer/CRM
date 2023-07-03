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
    public class ClientProviderHandler
    {
        private IMailMarketingListRepository MailMarketingListRepository;
        private IClientCrmRepository crmRepository;
        public ClientProviderHandler(MySqlConnection con) 
        {
            MailMarketingListRepository = new MailMarketingListRepository(con);
            crmRepository = new ClientCrmRepository(con);
        }

        public ResultModel<long> Handle(long IdForm, ClientCrm client)
        {
            try
            {
                client.IdProject = MailMarketingListRepository.GetMailMarketingListByIdForm(IdForm).Result.IdProject;
                
                var r = crmRepository.CreateClientCrm(client).Result;

                return new Result<long>().CreateSucess(r);
            }
            catch (Exception ex)
            {
                return new Result<long>().CreateErro(ex.Message);
            }
        }
    }
}
