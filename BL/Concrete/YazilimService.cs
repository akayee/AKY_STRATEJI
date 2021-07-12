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
    public class YazilimService : ABBEntityServis<BrYazilimlar, AKYSTRATEJIContext>, IYazilimlarServices
    {
        private readonly ILogger<YazilimService> _logger;

        public YazilimService(ILogger<YazilimService> logger):base(logger)
        {
            _logger = logger;
        }

        public BrYazilimlar TekYazilimGetir(int YazilimId)
        {
            try
            {

                return base.Getir(yazilim => yazilim.Id == YazilimId && yazilim.Deleted != true);
                throw new NotImplementedException("YazilimService/ Tek Kayıt getirme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekYazilimGuncelle(BrYazilimlar Yazilim)
        {
            try
            {

                base.Guncelle(Yazilim);
                throw new NotImplementedException("YazilimService/ Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekYazilimSil(BrYazilimlar Yazilim)
        {
            try
            {

                Yazilim.Deleted = true;
                base.Guncelle(Yazilim);
                throw new NotImplementedException("YazilimService/ Kayıt silme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(BrYazilimlar entity)
        {
            throw new NotImplementedException();
        }

        public List<BrYazilimlar> YaizimlariListele(Expression<Func<BrYazilimlar, bool>> filter = null, params Expression<Func<BrYazilimlar, object>>[] includeProperties)
        {
            try
            {
                return base.DetayliListe(filter);
                throw new NotImplementedException("YazilimService/ Kayıt listeleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool YeniYazilimEkle(BrYazilimlar Yazilim)
        {
            int counted = YaizimlariListele().Count + 1;
            Yazilim.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                base.Ekle(Yazilim);
                throw new NotImplementedException("YazilimService/ Kayır Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
