using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Common.Infrastructure.Repository
{
    public abstract class BaseRepository<T, TContext> : IBaseRepository<T>
        where TContext : DbContext where T : BaseEntity
    {
        protected readonly TContext Context;

        protected BaseRepository(TContext context)
        {
            Context = context;
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            return await Context.Set<T>().AsNoTracking().FirstOrDefaultAsync(t => t.Id.Equals(id)); ;
        }

        public async Task<T> GetTracking(Guid id)
        {
            return await Context.Set<T>().AsTracking().FirstOrDefaultAsync(t => t.Id.Equals(id));
        }

        public async Task AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }
        public void Add(T entity)
        {
            Context.Set<T>().AddAsync(entity);
        }

        public async Task AddRange(ICollection<T> entities)
        {
            await Context.Set<T>().AddRangeAsync(entities);
        }

        public void Update(T entity)
        {


         
            Context.Update(entity);
            Context.ChangeTracker.DetectChanges();

        }

        public async Task<int> Save()
        {

            return await Context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().AnyAsync(expression);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Any(expression);
        }

        public T Get(Guid id)
        {
            return Context.Set<T>().FirstOrDefault(t => t.Id.Equals(id));
        }

        public async Task<List<T>> GetAllAsyc()
        {
            return await Context.Set<T>().ToListAsync();
        }
    }
}