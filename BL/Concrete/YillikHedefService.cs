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
    public class YillikHedefService : ABBEntityServis<StYillikhedef, AKYSTRATEJIContext>, IYillikHedefServices
    {
        private readonly ILogger<YillikHedefService> _logger;

        public YillikHedefService(ILogger<YillikHedefService> logger):base(logger)
        {
            _logger = logger;
        }

        public StYillikhedef TekYillikHedefGetir(int yehedefId)
        {
            try
            {

                return base.Getir(yehdef => yehdef.Id == yehedefId && yehdef.Deleted != true);
                throw new NotImplementedException("YillikHedefService/ Tek Kayıt getirme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekYillikHedefGuncelle(StYillikhedef yhedef)
        {
            try
            {

                base.Guncelle(yhedef);
                throw new NotImplementedException("YillikHedefService/ Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekYillikHedefSil(StYillikhedef yhedef)
        {
            try
            {

                yhedef.Deleted = true;
                base.Guncelle(yhedef);
                throw new NotImplementedException("YillikHedefService/ Kayıt silme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(StYillikhedef entity)
        {
            //throw new NotImplementedException();
        }

        public bool YeniYillikHedefEkle(StYillikhedef yhedef)
        {
            int counted = YillikHedefleriListele().Count + 1;
            yhedef.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                base.Ekle(yhedef);
                throw new NotImplementedException("YillikHedefService/ Kayır Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public List<StYillikhedef> YillikHedefleriListele(Expression<Func<StYillikhedef, bool>> filter = null, params Expression<Func<StYillikhedef, object>>[] includeProperties)
        {
            try
            {
                return base.DetayliListe(filter);
                throw new NotImplementedException("YillikHedefService/ Kayıt listeleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
