﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnlineExamination.DataAccess.Data;

namespace OnlineExamination.DataAccess.Repository
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        internal DbSet<T> dbSet;
        private bool disposing;
        private ApplicationDbContext context;
        private readonly ApplicationDbContext _context = null;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }
        public GenericRepository(DbSet<T> dbSet, ApplicationDbContext context)
        {
            this.dbSet = dbSet;
            _context = context;
        }
        public async Task<T> DeleteAsync(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            return entityToDelete;
        }
        public IEnumerable<T> GetAll(Expression<Func<T,
            bool>> filter = null, Func<IQueryable<T>,
                IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public async Task<T> GetByAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }
        public T GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public Task<T> GetByName(object id)
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public async Task<T> AddAsync(T entity)
        {
            dbSet.Add(entity);
            return entity;
        }

        public void Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Remove(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public void Update(T entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public async Task<T> UpdateAsync(T entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            return entityToUpdate;
        }
        public void DeleteByID(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposing)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposing = true;
        }
        public async Task<T> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
