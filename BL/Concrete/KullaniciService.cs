using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using BL.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class KullaniciService : ABBEntityServis<Kullanicilar, AKYSTRATEJIContext>, IKullaniciServices
    {
        private readonly ILogger<KullaniciService> _logger;

        public KullaniciService(ILogger<KullaniciService> logger):base(logger)
        {
            _logger = logger;
        }

        public List<Kullanicilar> KullaniciListele(Expression<Func<Kullanicilar, bool>> filter = null, params Expression<Func<Kullanicilar, object>>[] includeProperties)
        {
            try
            {
                return base.DetayliListe(filter);
                throw new NotImplementedException("KullaniciService/ Kayıt listeleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public Kullanicilar TekKullaniciGetir(int KullaniciId)
        {
            try
            {

                return base.Getir(kullanici => kullanici.Id == KullaniciId && kullanici.Deleted != true);
                throw new NotImplementedException("KullaniciService/ Tek Kayıt getirme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekKullaniciGuncelle(Kullanicilar user)
        {
            try
            {

                base.Guncelle(user);
                throw new NotImplementedException("KullaniciService/ Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekKullaniciSil(Kullanicilar user)
        {
            try
            {

                user.Deleted = true;
                base.Guncelle(user);
                throw new NotImplementedException("KullaniciService/ Kayıt silme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(Kullanicilar entity)
        {
            throw new NotImplementedException();
        }

        public bool YeniKullaniciEkle(Kullanicilar user)
        {
            int counted = KullaniciListele().Count + 1;
            user.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                base.Ekle(user);
                throw new NotImplementedException("KullaniciService/ Kayır Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
