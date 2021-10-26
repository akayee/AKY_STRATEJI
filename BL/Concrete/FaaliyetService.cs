using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using BL.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BL.Concrete
{
    public class FaaliyetService : ABBEntityServis<StFaaliyet, AKYSTRATEJIContext>, IFaaliyetServices
    {
        private readonly ILogger<FaaliyetService> _logger;

        public FaaliyetService(ILogger<FaaliyetService> logger):base(logger)
        {
            _logger = logger;
        }

        public List<StFaaliyet> FaaliyetListele(Expression<Func<StFaaliyet, bool>> filter = null, params Expression<Func<StFaaliyet, object>>[] includeProperties)
        {
            try
            {
                return base.DetayliListe(filter);
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public StFaaliyet TekFaaliyetGetir(int FaaliyetId)
        {
            try
            {

                return base.Getir(faaliyet => faaliyet.Id == FaaliyetId && faaliyet.Deleted != true);
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekFaaliyetGuncelle(StFaaliyet faaliyet)
        {
            try
            {

                base.Guncelle(faaliyet);
                return true;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekFaaliyetSil(StFaaliyet faaliyet)
        {
            try
            {

                faaliyet.Deleted = true;
                base.Guncelle(faaliyet);
                return true;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(StFaaliyet entity)
        {
            //throw new NotImplementedException();
        }

        public int YeniFaaliyetEkle(StFaaliyet faaliyet)
        {
            int counted = FaaliyetListele().Count + 1;
            int nextfaaliyetId = DetayliListe(obj=>obj.FaaliyetlerId==faaliyet.FaaliyetlerId).Count + 1;
            faaliyet.FaaliyetId = counted;
            faaliyet.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                base.Ekle(faaliyet);
                return counted;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
