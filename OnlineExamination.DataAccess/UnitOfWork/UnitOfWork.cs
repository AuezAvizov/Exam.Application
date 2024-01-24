using OnlineExamination.DataAccess.Data;
using OnlineExamination.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamination.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context = null;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            
        }
        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            IGenericRepository<T> repo = new GenericRepository<T>(_context);
            return repo;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
