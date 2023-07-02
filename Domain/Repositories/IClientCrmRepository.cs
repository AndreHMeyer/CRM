using CrmAuth.Domain.Model;
using Domain.Entities;
using Domain.Filters;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IClientCrmRepository
    {
        Task<ResultModel<PaginationResult<ClientCrm>>> GetClientsCrm(ClientCrmFilter filter);
        Task<long> CreateClientCrm(ClientCrm clientCrm);
        Task<ClientCrm> UpdateClientCrm(ClientCrm clientCrm);
        Task<ClientCrm> DeleteClientCrm(ClientCrm clientCrm);
    }
}
