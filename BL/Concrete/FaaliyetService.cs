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
                throw new NotImplementedException("FaaliyetService/ Kayıt listeleme başarılı");
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
                throw new NotImplementedException("FaaliyetService/ Tek Kayıt getirme başarılı");
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
                throw new NotImplementedException("FaaliyetService/ Kayıt güncelleme başarılı");
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
                throw new NotImplementedException("FaaliyetService/ Kayıt silme başarılı");
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

        public bool YeniFaaliyetEkle(StFaaliyet faaliyet)
        {
            int counted = FaaliyetListele().Count + 1;
            faaliyet.FaaliyetId = counted;
            faaliyet.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                base.Ekle(faaliyet);
                throw new NotImplementedException("FaaliyetService/ Kayır Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
