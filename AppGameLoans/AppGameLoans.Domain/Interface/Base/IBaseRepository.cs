using System;
using System.Collections.Generic;
using System.Linq;

namespace AppGameLoans.Domain.Interface.Base
{
    public interface IBaseRepository<TModel> where TModel : class
    {
        TModel Get(Guid id);
        IEnumerable<TModel> GetAll(Func<IQueryable<TModel>, IQueryable<TModel>> func = null);
        IEnumerable<TModel> GetAll();
        void Add(TModel entity);
        void AddRange(List<TModel> models);
        void Update(TModel entity);
        void RemoveById(Guid id);
        TModel GetById(Guid id);
    }
}
