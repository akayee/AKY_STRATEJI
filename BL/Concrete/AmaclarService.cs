using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using BL.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BL.Concrete
{
    public class AmaclarService : ABBEntityServis<StAmaclar, AKYSTRATEJIContext>, IAmaclarService
    {
        private readonly ILogger<AmaclarService> _logger;

        public AmaclarService(ILogger<AmaclarService> logger) : base(logger)
        {
            _logger = logger;
        }

        public StAmaclar AmacGetir(int AmacId)
        {

            return Getir(amac => amac.Id == AmacId && amac.Deleted != true);
        }

        public List<StAmaclar> Listele(Expression<Func<StAmaclar, bool>> filter = null, params Expression<Func<StAmaclar, object>>[] includeProperties)
        {
            return GetList(filter,includeProperties);
        }

        public override void Validate(StAmaclar entity)
        {
            //throw new NotImplementedException();
        }

        public bool Sil(StAmaclar guncellenece_amac)
        {
            try
            {

                guncellenece_amac.Deleted = true;
                Guncelle(guncellenece_amac);
                return true;
            }
            catch(Exception e)
            {
                throw new NotImplementedException(e.Message);
            }

            
        }

        public int AmacEkle(StAmaclar amac)
        {
            int counted = Listele().Count + 1;
            amac.AmacId = counted;
            amac.Id= counted;
            amac.Deleted = false;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                Ekle(amac);
                return (counted);
            }
            catch(Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
          

        }

        public bool AmacGuncelle(StAmaclar amac)
        {
            try
            {

                base.Guncelle(amac);
                return true;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            } 
        }
    }
}
