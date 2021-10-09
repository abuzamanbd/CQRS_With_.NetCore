using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.Interface;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T: class
    {
        private readonly ApplicationDBContext _context;

        protected RepositoryBase(ApplicationDBContext context)
        {
            _context = context;

        }
        public async Task<long> CountAsync(Expression<Func<T, bool>> expression = null)
        {
            if (expression != null)
                return await _context.Set<T>().CountAsync(expression);

            return await _context.Set<T>().CountAsync();
        }

        public virtual IQueryable<T> QueryAll(Expression<Func<T, bool>> expression)
        {
            return expression != null
                ? _context.Set<T>().AsQueryable().Where(expression)
                : _context.Set<T>().AsQueryable()
                    .AsNoTracking();
        }

        public virtual async Task CreateAsync(T entity)
        {

            await _context.Set<T>().AddAsync(entity);
        }

        public virtual async Task CreateRangeAsync(List<T> entity)
        {

            await _context.Set<T>().AddRangeAsync(entity);
        }

        public virtual async Task Update(T entity)
        {

            _context.Set<T>().Update(entity);
        }

        public async Task<T> FindSingleAsync(Expression<Func<T, bool>> expression, string itemName,
            bool isTracked = false)
        {
            return await _context.Set<T>().AsNoTracking().SingleAsync(expression);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public void Detach(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        public virtual async Task UpdateRange(List<T> entryList)
        {

            _context.Set<T>().UpdateRange(entryList);
        }

        public virtual async Task Delete(T entity)
        {

            _context.Set<T>().Remove(entity);
        }
        public async Task DeleteRange(List<T> entryList)
        {

            _context.Set<T>().RemoveRange(entryList);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
