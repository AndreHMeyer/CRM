using CrmAuth.Domain.Model;
using Domain.Model;

namespace Domain.Pagination
{
    public class PaginationService<T>
    {
        public ResultModel<PaginationResult<T>> ExecutePagination(List<T> data, PaginationBase pag)
        {
            PaginationResult<T> result = new();
            result.RegistersPerPage = pag.PageSize;
            result.Page = pag.Page;
            result.Total = data.Count();
            result.Values = data.Skip((pag.Page - 1)* pag.PageSize).Take(pag.PageSize).ToList();
            return new Result<PaginationResult<T>>().CreateSucess(result);
        }
    }
}
