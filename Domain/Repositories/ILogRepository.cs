using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public  interface ILogRepository
    {
        Task<List<Log>> GetLogs();
        Task<long> CreateLog(Log log);
        Task<Log> UpdateLog(Log log);
        Task<Log> DeleteLog(Log log);
    }
}
