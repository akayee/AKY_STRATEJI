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
                return true;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
        //İslerin listelenme işlemi
        public List<StIsler> IsleriListele(Expression<Func<StIsler, bool>> filter = null, params Expression<Func<StIsler, object>>[] includeProperties)
        {
            try
            {
                return base.DetayliListe(filter);
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
                base.Guncelle(isler);
                return true;
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
                return base.Getir(isTuru => isTuru.Id == IsId && isTuru.Deleted != true);
            }
            catch(Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
        //Gelen veriyi doğrulama işlemi. Tüm servisler çekildikten sonra tekrar güncellenecek.
        public override void Validate(StIsler entity)
        {
            //throw new NotImplementedException();
        }
        //Yeni is ekleme işlemi.
        public int YeniIsEkle(StIsler isler)
        {
            int counted = base.DetayliListe().Count + 1;
            int nextisId = base.DetayliListe(obj=>obj.IsTuruId==isler.IsTuruId).Count + 1;
            isler.IslerId = nextisId;
            isler.Id = counted;

            try
            {

                base.Ekle(isler);
                return counted;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
