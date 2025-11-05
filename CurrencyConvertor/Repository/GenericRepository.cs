using CurrencyConvertor.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CurrencyConvertor.Repository
{
        public class GenericRepository<T> : IGenericRepository<T> where T : class
        {
            protected readonly AppDbContext _ctx;
            protected readonly DbSet<T> _dbSet;

            public GenericRepository(AppDbContext ctx)
            {
                _ctx = ctx;
                _dbSet = _ctx.Set<T>();
            }

            public virtual async Task<T> GetByIdAsync(int id)
            {
                return await _dbSet.FindAsync(id);
            }

            public virtual async Task<IEnumerable<T>> GetAllAsync()
            {
                // If entity inherits BaseEntity and uses IsDeleted, filter it out
                if (typeof(BaseEntity).IsAssignableFrom(typeof(T)))
                {
                    return await _dbSet
                        .AsQueryable()
                        .Cast<BaseEntity>()
                        .Where(e => !e.IsDeleted)
                        .Cast<T>()
                        .ToListAsync();
                }

                return await _dbSet.ToListAsync();
            }

            public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            {
                return await _dbSet.Where(predicate).ToListAsync();
            }

            public virtual async Task AddAsync(T entity)
            {
                await _dbSet.AddAsync(entity);
            }

            public virtual void Update(T entity)
            {
                _dbSet.Update(entity);
            }

            public virtual void Remove(T entity)
            {
                // Default behavior: if entity has IsDeleted -> soft delete, else physical delete
                if (entity is BaseEntity be)
                {
                    be.IsDeleted = true;
                    _dbSet.Update(entity);
                }
                else
                {
                    _dbSet.Remove(entity);
                }
            }

            public virtual async Task<int> SaveChangesAsync()
            {
                return await _ctx.SaveChangesAsync();
            }
        }
    }

