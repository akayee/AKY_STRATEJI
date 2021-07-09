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
    public class AraclarService : ABBEntityServis<BrAraclar, AKYSTRATEJIContext>, IAraclarServices
    {
        private readonly ILogger<AraclarService> _logger;
        public AraclarService(ILogger<AraclarService> logger):base(logger)
        {
            _logger = logger;
        }
        public bool AracGuncelle(BrAraclar arac)
        {
            try
            {

                base.Guncelle(arac);
                throw new NotImplementedException("AraclarService/ Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }


        public List<BrAraclar> AracListele(Expression<Func<BrAraclar, bool>> filter = null, params Expression<Func<BrAraclar, object>>[] includeProperties)
        {
            try
            {
                return DetayliListe(filter);
                throw new NotImplementedException("AraclarService/ Kayıt listeleme başarılı");
            }
            catch(Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool AracSil(BrAraclar arac)
        {
            try
            {

                arac.Deleted = true;
                base.Guncelle(arac);
                throw new NotImplementedException("AraclarService/ Kayıt silme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public BrAraclar TekAracGetir(int AracId)
        {
            try
            {

                return base.Getir(arac => arac.Id == AracId && arac.Deleted != true);
                throw new NotImplementedException("AraclarService/ Tek Kayıt getirme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(BrAraclar entity)
        {
            throw new NotImplementedException();
        }

        public bool YeniAracEkle(BrAraclar arac)
        {
            int counted = AracListele().Count + 1;
            arac.AracId = counted;
            arac.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                base.Ekle(arac);
                throw new NotImplementedException("AraclarService/ Kayır Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
