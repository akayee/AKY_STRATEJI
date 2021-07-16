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
    public class YetkiService : ABBEntityServis<YtYetkiler, AKYSTRATEJIContext>, IYetkilerServices
    {
        private readonly ILogger<YetkiService> _logger;

        public YetkiService(ILogger<YetkiService> logger):base(logger)
        {
            _logger = logger;
        }

        public YtYetkiler TekYetkiGetir(int YetkiId)
        {
            try
            {

                return base.Getir(yetki => yetki.Id == YetkiId && yetki.Deleted != true);
                throw new NotImplementedException("YetkiService/ Tek Kayıt getirme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekYetkiGuncelle(YtYetkiler yetki)
        {
            try
            {

                base.Guncelle(yetki);
                throw new NotImplementedException("YetkiService/ Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekYetkiSil(YtYetkiler yetki)
        {
            try
            {

                yetki.Deleted = true;
                base.Guncelle(yetki);
                throw new NotImplementedException("YetkiService/ Kayıt silme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(YtYetkiler entity)
        {
            throw new NotImplementedException();
        }

        public bool YeniYetkiEkle(YtYetkiler yetki)
        {
            int counted = YetkileriListele().Count + 1;
            yetki.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                base.Ekle(yetki);
                throw new NotImplementedException("YetkiService/ Kayır Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public List<YtYetkiler> YetkileriListele(Expression<Func<YtYetkiler, bool>> filter = null, params Expression<Func<YtYetkiler, object>>[] includeProperties)
        {
            try
            {
                return base.DetayliListe(filter);
                throw new NotImplementedException("YetkiService/ Kayıt listeleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
