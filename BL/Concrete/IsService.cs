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
    public class IsService : ABBEntityServis<StIsler, AKYSTRATEJIContext>, IIslerServices
    {
        private readonly ILogger<IsService> _logger;

        //Servisin loglama işlemi
        public IsService(ILogger<IsService> logger) : base(logger)
        {
            _logger = logger;
        }
        //Islerin güncellenmesi işlemi
        public bool IsGuncelle(StIsler isler)
        {
            try
            {

                base.Guncelle(isler);
                throw new NotImplementedException("IsService Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
        //İslerin listelenme işlemi
        public List<StIsler> IsleriListele(Expression<Func<StIsler, bool>> filter = null, params Expression<Func<StIsturleri, object>>[] includeProperties)
        {
            try
            {
                return DetayliListe(filter);
                throw new NotImplementedException("IsService Kayıt listeleme başarılı");
            }
            catch(Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
            
        }
        //İşlerin silinme işlemi
        public bool IsSil(StIsler isler)
        {
            try
            {
                //Kayıt silmiyoruz sadece Deleted parametresini true yapıyoruz.
                isler.Deleted = true;
                Guncelle(isler);
                throw new NotImplementedException("IsServices Kayıt silme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
        //Tek iş görüntüleme/Çekme işlemi.
        public StIsler TekIsGetir(int IsId)
        {
            try
            {
                return Getir(isTuru => isTuru.Id == IsId && isTuru.Deleted != true);
                throw new NotImplementedException("IsServices tek kayıt listeleme başarılı");
            }
            catch(Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
        //Gelen veriyi doğrulama işlemi. Tüm servisler çekildikten sonra tekrar güncellenecek.
        public override void Validate(StIsler entity)
        {
            throw new NotImplementedException();
        }
        //Yeni is ekleme işlemi.
        public bool YeniIsEkle(StIsler isler)
        {
            int counted = IsleriListele().Count + 1;
            isler.IslerId = counted;
            isler.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                Ekle(isler);
                throw new NotImplementedException("IsServis Kayıt Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
