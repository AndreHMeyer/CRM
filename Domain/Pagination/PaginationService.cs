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
            var t = result.Total;
            var tp = 0;
            while(t > 0)
            {
                if(t < pag.PageSize)
                {
                    t = 0;
                    tp++;
                }
                else
                {
                    t -= pag.PageSize;
                    tp++;
                }
            }
            result.TotalPages = tp;
            result.Values = data.Skip((pag.Page - 1)* pag.PageSize).Take(pag.PageSize).ToList();
            return new Result<PaginationResult<T>>().CreateSucess(result);
        }
    }
}
