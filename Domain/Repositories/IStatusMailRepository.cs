using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IStatusMailRepository
    {
        Task<List<StatusMail>> GetStatusMails();
        Task<long> CreateStatusMail(StatusMail statusMail);
        Task<StatusMail> UpdateStatusMail(StatusMail statusMail);
        Task<StatusMail> DeleteStatusMail(StatusMail statusMail);
    }
}
