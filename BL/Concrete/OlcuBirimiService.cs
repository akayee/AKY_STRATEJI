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
    public class OlcuBirimiService : ABBEntityServis<GnOlcubirimi, AKYSTRATEJIContext>, IOlcuBirimiServices
    {
        private readonly ILogger<OlcuBirimiService> _logger;

        public OlcuBirimiService(ILogger<OlcuBirimiService> logger):base(logger)
        {
            _logger = logger;
        }

        public List<GnOlcubirimi> OlcuBirimiListele(Expression<Func<GnOlcubirimi, bool>> filter = null, params Expression<Func<GnOlcubirimi, object>>[] includeProperties)
        {
            try
            {
                return base.DetayliListe(filter);
                throw new NotImplementedException("OlcuBirimiService/ Kayıt listeleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public GnOlcubirimi TekOlcuBirimiGetir(int OlcuBirimiId)
        {
            try
            {

                return base.Getir(olcubirimi => olcubirimi.Id == OlcuBirimiId && olcubirimi.Deleted != true);
                throw new NotImplementedException("OlcuBirimiService/ Tek Kayıt getirme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekOlcuBirimiGuncelle(GnOlcubirimi OlcuBirimi)
        {
            try
            {

                base.Guncelle(OlcuBirimi);
                throw new NotImplementedException("OlcuBirimiService/ Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekOlcuBirimiSil(GnOlcubirimi OlcuBirimi)
        {
            try
            {

                OlcuBirimi.Deleted = true;
                base.Guncelle(OlcuBirimi);
                throw new NotImplementedException("OlcuBirimiService/ Kayıt silme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(GnOlcubirimi entity)
        {
            throw new NotImplementedException();
        }

        public bool YeniOlcuBirimiEkle(GnOlcubirimi OlcuBirimi)
        {
            int counted = OlcuBirimiListele().Count + 1;
            OlcuBirimi.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                base.Ekle(OlcuBirimi);
                throw new NotImplementedException("OlcuBirimiService/ Kayır Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
