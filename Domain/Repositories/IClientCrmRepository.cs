using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IClientCrmRepository
    {
        Task<List<ClientCrm>> GetClientsCrm();
        Task<long> CreateClientCrm(ClientCrm clientCrm);
        Task<ClientCrm> UpdateClientCrm(ClientCrm clientCrm);
        Task<ClientCrm> DeleteClientCrm(ClientCrm clientCrm);
    }
}
