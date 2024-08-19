﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static CaExam.Repositories.GenericDbRepo;
using CaExam.Interfaces.RepositoryInterfaces;

namespace CaExam.Repositories
{
    public class GenericDbRepo
    {
        public class GenericRepository<T> : IGenericRepository<T> where T : class
        {
            protected readonly DbContext _context;
            protected readonly DbSet<T> _dbSet;

            public GenericRepository(DbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
                _dbSet = _context.Set<T>();
            }

            public async Task<IEnumerable<T>> GetAllAsync()
            {
                return await _dbSet.ToListAsync();
            }

            public async Task<T> GetByIdAsync(Guid id)
            {
                return await _dbSet.FindAsync(id);
            }

            public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            {
                return await _dbSet.Where(predicate).ToListAsync();
            }

            public async Task AddAsync(T entity)
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                await _dbSet.AddAsync(entity);
            }

            public async Task AddRangeAsync(IEnumerable<T> entities)
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                await _dbSet.AddRangeAsync(entities);
            }

            public async Task UpdateAsync(T entity)
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }

            public async Task DeleteAsync(Guid id)
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity != null)
                    _dbSet.Remove(entity);
            }

            public async Task DeleteAsync(T entity)
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                _dbSet.Remove(entity);
            }

            public async Task<int> SaveChangesAsync()
            {
                return await _context.SaveChangesAsync();
            }
        }
    }
}
