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
    public interface IFormTemplateRepository
    {
        Task<ResultModel<PaginationResult<FormTemplate>>> Get(FormFilter filter);
        Task<long> Create(FormTemplate template);
        Task<long> Delete(long Id);
    }
}
