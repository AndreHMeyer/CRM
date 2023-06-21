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
        Task<List<MailMarketingList>> GetMailMarketingLists();
        Task<long> CreateMailMarketingList(MailMarketingList mailMarketingList);
        Task<MailMarketingList> UpdateMailMarketingList(MailMarketingList mailMarketingList);
        Task<MailMarketingList> DeleteMailMarketingList(MailMarketingList mailMarketingList);
    }
}
