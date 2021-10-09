using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface
{
    public interface IRepositoryBase<T> : IDisposable where T: class
    {
        IQueryable<T> QueryAll(Expression<Func<T, bool>> expression = null);
        Task CreateAsync(T entity);
        Task CreateRangeAsync(List<T> entity);
        Task Update(T entity);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        void Detach(T entity);
        Task UpdateRange(List<T> entryList);
        Task Delete(T entity);
        Task DeleteRange(List<T> entryList);
        Task<long> CountAsync(Expression<Func<T, bool>> expression = null);
    }
}
