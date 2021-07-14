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
    public class YetkiGruplariService : ABBEntityServis<YtYetkigruplari, AKYSTRATEJIContext>, IYetkiGruplariServices
    {
        private readonly ILogger<YetkiGruplariService> _logger;

        public YetkiGruplariService(ILogger<YetkiGruplariService> logger):base(logger)
        {
            _logger = logger;
        }

        public YtYetkigruplari TekYetkiGrubuGetir(int yetkigId)
        {
            try
            {

                return base.Getir(yetkig => yetkig.Id == yetkigId && yetkig.Deleted != true);
                throw new NotImplementedException("YetkiGruplariService/ Tek Kayıt getirme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekYetkiGrubuGuncelle(YtYetkigruplari yetkig)
        {
            try
            {

                base.Guncelle(yetkig);
                throw new NotImplementedException("YetkiGruplariService/ Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekYetkiGrubuSil(YtYetkigruplari yetkig)
        {
            try
            {

                yetkig.Deleted = true;
                base.Guncelle(yetkig);
                throw new NotImplementedException("YetkiGruplariService/ Kayıt silme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(YtYetkigruplari entity)
        {
            throw new NotImplementedException();
        }

        public bool YeniYetkiGrubuEkle(YtYetkigruplari yetkig)
        {
            int counted = YetkiGruplariListele().Count + 1;
            yetkig.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                base.Ekle(yetkig);
                throw new NotImplementedException("YetkiGruplariService/ Kayır Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public List<YtYetkigruplari> YetkiGruplariListele(Expression<Func<YtYetkigruplari, bool>> filter = null, params Expression<Func<YtYetkigruplari, object>>[] includeProperties)
        {
            try
            {
                return base.DetayliListe(filter);
                throw new NotImplementedException("YetkiGruplariService/ Kayıt listeleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
