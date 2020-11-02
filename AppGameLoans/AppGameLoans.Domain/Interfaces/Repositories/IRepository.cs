using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppGameLoans.Domain.Interfaces.Repositories
{
    public interface IRepository<TModel> where TModel : class
    {

        TModel Get(Guid id);
        IEnumerable<TModel> GetAll(Func<IQueryable<TModel>, IQueryable<TModel>> func = null);
        IEnumerable<TModel> GetAll();
        void Add(TModel entity);
        void AddRange(List<TModel> models);
        void Update(TModel entity);
        void RemoveById(Guid id);
        TModel GetById(Guid id);
        System.Threading.Tasks.Task<TModel> GetAsync(Func<IQueryable<TModel>, IQueryable<TModel>> func = null);
        Task<IEnumerable<TModel>> GetAllAsync(Func<IQueryable<TModel>, IQueryable<TModel>> func = null);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task AddAsync(TModel entity);
        Task AddRangeAsync(List<TModel> models);
        Task UpdateAsync(TModel entity);
        Task RemoveByIdAsync(Guid id);
        Task<TModel> GetByIdAsync(Guid id);
        Task UpdateOldAsync(TModel entity);

    }
}
