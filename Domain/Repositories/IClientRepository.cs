using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClients(int IdProject);
        Task<Client> GetClientById(int Id, int IdProject);

    }
}
