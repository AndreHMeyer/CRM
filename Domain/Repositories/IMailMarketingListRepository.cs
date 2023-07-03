using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IMailMarketingListRepository
    {
        Task<MailMarketingList> GetMailMarketingListByIdForm(long IdForm);
        Task<MailMarketingList> GetMailMarketingListByIdProject(long IdProject);
        Task<long> CreateMailMarketingList(MailMarketingList mail);
    }
}
