using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;

namespace ABB.Core.DataAccess
{
    public abstract class ABBEntityServis<TEntity, TContext> : EfEntityRepositoryBase<TEntity, TContext>, IABBEntityServis<TEntity> where TEntity : class, new() where TContext : DbContext, new()
    {
        private readonly ILogger<ABBEntityServis<TEntity, TContext>> _logger;

        protected ABBEntityServis(ILogger<ABBEntityServis<TEntity, TContext>> logger)
        {
            _logger = logger;
        }

        public abstract void Validate(TEntity entity);

        public void Ekle(TEntity entity)
        {
            _logger.LogInformation("entity added: {@entity}", entity);
            Validate(entity);
            try
            {
                base.Add(entity);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, "ABBEntityServis Beklenmeyen Hata");
                throw new Exception("Beklenmeyen Hata");
            }
        }

        public void TopluEkle(IEnumerable<TEntity> entities)
        {
            var enumerable = entities.ToList();
            foreach (var entity in enumerable)
            {
                Validate(entity);
            }
            try
            {
                base.AddMultiple(enumerable);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, "ABBEntityServis Beklenmeyen Hata");
                throw new Exception("Beklenmeyen Hata");
            }
        }

        public void Guncelle(TEntity entity)
        {
            Validate(entity);
            try
            {
                base.Update(entity);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, "ABBEntityServis Beklenmeyen Hata");
                throw new Exception("Beklenmeyen Hata");
            }
        }

        public virtual TEntity Getir(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return base.Get(filter, includeProperties);
        }

        public virtual List<TEntity> Liste(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return base.GetList(filter, includeProperties);
        }

        public List<TEntity> DetayliListe(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            return base.GetListWithDetails(filter, include);
        }

        public void ThrowError(string mesaj)
        {
            _logger.LogError(mesaj);
            throw new Exception(mesaj);
        }
    }
}