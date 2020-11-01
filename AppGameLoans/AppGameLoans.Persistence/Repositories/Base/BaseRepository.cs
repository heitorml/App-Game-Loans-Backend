using AppGameLoans.Domain.Interface.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AppGameLoans.Persistence.Repositories.Base
{
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class
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
    }
}
