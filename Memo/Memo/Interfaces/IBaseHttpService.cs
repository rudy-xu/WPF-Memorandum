using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo.Interfaces
{
    public interface IBaseHttpService<TEntity> where TEntity : class
    {
        Task<ApiRespones<TEntity>> AddAsync(TEntity entity);
        Task<ApiRespones<TEntity>> UpdateAsync(TEntity entity);
        Task<ApiRespones> DeleteAsync(int id);
        Task<ApiRespones<TEntity>> GetFirstOfDefaultAsync(int id);
        Task<ApiRespones> GetAllAsync(QueryParameter parameter);
    }
}
