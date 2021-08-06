using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using BL.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BL.Concrete
{
    public class PerformansService : ABBEntityServis<StPerformanslar, AKYSTRATEJIContext>, IPerformanslarServices
    {
        private readonly ILogger<PerformansService> _logger;

        public PerformansService(ILogger<PerformansService> logger) : base(logger)
        {
            _logger = logger;
        }
        public bool PerformansGuncelle(StPerformanslar performans)
        {
            try
            {

                base.Guncelle(performans);
                throw new NotImplementedException("Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public List<StPerformanslar> PerformanslariListele(Expression<Func<StPerformanslar, bool>> filter = null, params Expression<Func<StPerformanslar, object>>[] includeProperties)
        {
            return DetayliListe(filter);
        }

        public bool PerformansSil(StPerformanslar performans)
        {
            try
            {

                performans.Deleted = true;
                Guncelle(performans);
                throw new NotImplementedException("Kayıt silme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public StPerformanslar TekPerformansGetir(int PerformansId)
        {
            return Getir(performans => performans.Id == PerformansId && performans.Deleted != true);
        }

        public override void Validate(StPerformanslar entity)
        {
            throw new NotImplementedException();
        }

        public bool YeniPerformansEkle(StPerformanslar performans)
        {
            int counted = PerformanslariListele().Count + 1;
            performans.HedeflerId = counted;
            performans.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                Ekle(performans);
                throw new NotImplementedException("Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
