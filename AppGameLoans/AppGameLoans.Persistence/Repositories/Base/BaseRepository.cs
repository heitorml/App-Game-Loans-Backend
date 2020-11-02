using AppGameLoans.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppGameLoans.Persistence.Repositories.Base
{
    public abstract class BaseRepository<TModel> : IRepository<TModel> where TModel : class
    {
        protected readonly DbContext DatabaseContext;

        public BaseRepository(DbContext context)
        {
            this.DatabaseContext = context;
        }
        public void Add(TModel entity)
        {
            DatabaseContext.Set<TModel>().Add(entity);
            DatabaseContext.SaveChanges();
        }

        public void AddRange(List<TModel> models)
        {
            DatabaseContext.Set<TModel>().AddRange(models);
            DatabaseContext.SaveChanges();
        }

        public TModel Get(Guid id)
        {
            return DatabaseContext.Set<TModel>().Find(id);
        }

        public void Update(TModel entity)
        {
            DatabaseContext.Set<TModel>().Update(entity);
            DatabaseContext.SaveChanges();
        }

        public IEnumerable<TModel> GetAll(Func<IQueryable<TModel>, IQueryable<TModel>> func = null)
        {
            var dbSet = DatabaseContext.Set<TModel>();
            if (func != null)
            {
                return func(dbSet).ToList();
            }
            return dbSet.ToList();
        }

        public IEnumerable<TModel> GetAll()
        {
            return DatabaseContext.Set<TModel>().ToList();
        }

        public void RemoveById(Guid id)
        {
            var existingEntity = DatabaseContext.Set<TModel>().Find(id);
            DatabaseContext.Remove(existingEntity);
            DatabaseContext.SaveChanges();
        }

        public TModel GetById(Guid id)
        {
            return DatabaseContext.Set<TModel>().Find(id);
        }
        public async Task<TModel> GetAsync(Guid id)
        {
            return await DatabaseContext.Set<TModel>().FindAsync(id);
        }

        public async Task<IEnumerable<TModel>> GetAllAsync(Func<IQueryable<TModel>, IQueryable<TModel>> func = null)
        {
            var dbSet = DatabaseContext.Set<TModel>();
            if (func != null)
            {
                return func(dbSet).ToList();
            }
            return await dbSet.ToListAsync();
        }

        public async Task AddAsync(TModel entity)
        {
            await DatabaseContext.Set<TModel>().AddAsync(entity);
            DatabaseContext.SaveChanges();
        }

        public async Task AddRangeAsync(List<TModel> models)
        {
            await DatabaseContext.Set<TModel>().AddRangeAsync(models);
            DatabaseContext.SaveChanges();
        }

        public async Task UpdateAsync(TModel entity)
        {
            DatabaseContext.Set<TModel>().Update(entity);
            await DatabaseContext.SaveChangesAsync();
        }


        public async Task UpdateOldAsync(TModel entity)
        {
            DatabaseContext.Set<TModel>().Update(entity);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task RemoveByIdAsync(Guid id)
        {
            var existingEntity = await DatabaseContext.Set<TModel>().FindAsync(id);
            DatabaseContext.Remove(existingEntity);
            DatabaseContext.SaveChanges();
        }

        public async Task<TModel> GetByIdAsync(Guid id)
        {
            return await DatabaseContext.Set<TModel>().FindAsync(id);
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return await DatabaseContext.Set<TModel>().ToListAsync();
        }

        public async Task<TModel> GetAsync(Func<IQueryable<TModel>, IQueryable<TModel>> func = null)
        {
            var dbSet = DatabaseContext.Set<TModel>();
            if (func != null)
            {
                return func(dbSet).FirstOrDefault();
            }
            return await dbSet.FirstOrDefaultAsync();
        }
    }
}
