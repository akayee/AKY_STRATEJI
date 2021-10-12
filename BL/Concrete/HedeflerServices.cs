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
    public class HedeflerServices : ABBEntityServis<StHedefler, AKYSTRATEJIContext>, IHedeflerServices
    {
        private readonly ILogger<HedeflerServices> _logger;

        public HedeflerServices(ILogger<HedeflerServices> logger) : base(logger)
        {
            _logger = logger;
        }
        public StHedefler TekHedefGetir(int HedefId, params Expression<Func<StHedefler, object>>[] includeProperties)
        {
            return Getir(hedef => hedef.Id == HedefId && hedef.Deleted != true, includeProperties);
        }

        public List<StHedefler> HedefleriListele()
        {
            return DetayliListe(hedefler => hedefler.Deleted != true);
        }

        public override void Validate(StHedefler entity)
        {
            // veri eklemedeki "The method or operation is not implemented." hatası validate yüzünden geliyor.
            throw new NotImplementedException();
        }

        public bool YeniHedefEkle(StHedefler hedef)
        {
            int counted = HedefleriListele().Count + 1;
            hedef.HedeflerId = counted;
            hedef.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                Ekle(hedef);
                throw new NotImplementedException("Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool HedefSil(StHedefler hedef)
        {
            try
            {

                hedef.Deleted = true;
                Guncelle(hedef);
                throw new NotImplementedException("Kayıt silme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool HedefGuncelle(StHedefler hedef)
        {
            try
            {

                base.Guncelle(hedef);
                throw new NotImplementedException("Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
