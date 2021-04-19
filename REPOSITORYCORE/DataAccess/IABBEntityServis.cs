using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace ABB.Core.DataAccess
{
    public interface IABBEntityServis<T> where T : class, new()
    {
        void Ekle(T entity);

        void TopluEkle(IEnumerable<T> entity);

        void Guncelle(T entity);

        T Getir(Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] includeProperties);

        List<T> Liste(Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] includeProperties);

        List<T> DetayliListe(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        void ThrowError(string mesaj);
    }
}