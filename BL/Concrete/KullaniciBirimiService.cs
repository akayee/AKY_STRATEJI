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
    public class KullaniciBirimiService : ABBEntityServis<KullanicilarBirimler, AKYSTRATEJIContext>, IKullaniciBirimlerServices
    {
        private readonly ILogger<KullaniciBirimiService> _logger;

        public KullaniciBirimiService(ILogger<KullaniciBirimiService> logger):base(logger)
        {
            _logger = logger;
        }

        public List<KullanicilarBirimler> KullaniciBirimiListele(Expression<Func<KullanicilarBirimler, bool>> filter = null, params Expression<Func<KullanicilarBirimler, object>>[] includeProperties)
        {
            try
            {
                return base.DetayliListe(filter);
                throw new NotImplementedException("KullaniciBirimiService/ Kayıt listeleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public KullanicilarBirimler TekKullaniciBirimGetir(int KullaniciId, int birimId)
        {
            //Kullanici ve birim id beraber primary olduğu için iki değer ile çağırılabilmektedir. 
            try
            {
                return base.Getir(kullanici => kullanici.KullaniciId == KullaniciId && kullanici.BirimId==birimId && kullanici.Deleted != true);
                throw new NotImplementedException("KullaniciBirimiService/ Tek Kayıt getirme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekKullaniciBirimiGuncelle(KullanicilarBirimler kbirimi)
        {
            // -WRN- Burada sıkıntı var tekrar düşünülüp güncellenmesi lazım. Veri tablosuna id eklenmeli veya güncelle methodu değiştirilmeli
            try
            {
                base.Guncelle(kbirimi);
                throw new NotImplementedException("KullaniciBirimiService/ Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekKullaniciBirimiSil(KullanicilarBirimler kbirimi)
        {
            try
            {

                kbirimi.Deleted = true;
                base.Guncelle(kbirimi);
                throw new NotImplementedException("KullaniciBirimiService/ Kayıt silme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(KullanicilarBirimler entity)
        {
            throw new NotImplementedException();
        }

        public bool YeniKullaniciBirimiEkle(KullanicilarBirimler kbirimi)
        {
            // -WRN- Burada sıkıntı var tekrar düşünülüp güncellenmesi lazım. Veri tablosuna id eklenmeli veya YeniKullaniciBirimiEkle methodu değiştirilmeli
            try
            {

                base.Ekle(kbirimi);
                throw new NotImplementedException("KullaniciBirimiService/ Kayır Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
