using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using BL.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class FaaliyetTuruService : ABBEntityServis<StFaaliyetler, AKYSTRATEJIContext>, IFaaliyetTurleriServices
    {
        private readonly ILogger<FaaliyetTuruService> _logger;

        public FaaliyetTuruService(ILogger<FaaliyetTuruService> logger):base(logger)
        {
            _logger = logger;
        }

        public List<StFaaliyetler> FaaliyetTurleriListele(Expression<Func<StFaaliyetler, bool>> filter = null, params Expression<Func<StFaaliyetler, object>>[] includeProperties)
        {
            return DetayliListe(filter);
        }

        public StFaaliyetler FaaliyetTuruGetir(int FaaliyetId)
        {
            return base.Getir(isTuru => isTuru.Id == FaaliyetId && isTuru.Deleted != true);
        }

        public bool TekFaaliyetTuruGuncelle(StFaaliyetler FaaliyetTuru)
        {
            try
            {

                base.Guncelle(FaaliyetTuru);
                throw new NotImplementedException("FaaliyetTuruService// Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekFaaliyetTuruSil(StFaaliyetler FaaliyetTuru)
        {
            try
            {

                FaaliyetTuru.Deleted = true;
                base.Guncelle(FaaliyetTuru);
                throw new NotImplementedException("FaaliyetTuruService// Kayıt silme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(StFaaliyetler entity)
        {
            throw new NotImplementedException();
        }

        public bool YeniFaaliyetTuruEkle(StFaaliyetler FaaliyetTuru)
        {
            int counted = FaaliyetTurleriListele().Count + 1;
            FaaliyetTuru.FaaliyetlerId = counted;
            FaaliyetTuru.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                Ekle(FaaliyetTuru);
                throw new NotImplementedException("FaaliyetTuruService// Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
