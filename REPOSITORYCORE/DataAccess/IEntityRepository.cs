using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ABB.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, new()
    {
        T Get(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties);
        T GetWithLoad(Expression<Func<T, bool>> filter = null);

        List<T> GetList(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties);

        List<T> GetListWithDetails(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        List<T> GetListWithLoad(Expression<Func<T, bool>> filter = null);

        void Add(T entity);

        void AddMultiple(IEnumerable<T> entities);

        void Update(T entity);

        void Delete(T entity);

        DbContext GetContext();
    }
}