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
                return true;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public List<StPerformanslar> PerformanslariListele(Expression<Func<StPerformanslar, bool>> filter = null, params Expression<Func<StPerformanslar, object>>[] includeProperties)
        {
            return GetList(filter,includeProperties);
        }

        public bool PerformansSil(StPerformanslar performans)
        {
            try
            {

                performans.Deleted = true;
                Guncelle(performans);
                return true;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public StPerformanslar TekPerformansGetir(int PerformansId)
        {
            return Get(performans => performans.Id == PerformansId && performans.Deleted != true,p=>p.Hedefler,prop=>prop.Hedefler.Amaclar);
        }

        public override void Validate(StPerformanslar entity)
        {
            //throw new NotImplementedException();
        }

        public int YeniPerformansEkle(StPerformanslar performans)
        {
            int counted = PerformanslariListele().Count + 1;
            int nextperformid = PerformanslariListele(obj=>obj.HedeflerId==performans.HedeflerId).Count + 1;
            performans.PerformanslarId = nextperformid;
            performans.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                Ekle(performans);
                return counted;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
