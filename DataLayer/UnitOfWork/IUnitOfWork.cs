using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;

namespace DataLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
