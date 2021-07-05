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
    public class IsTuruService : ABBEntityServis<StIsturleri, AKYSTRATEJIContext>, IIsturleriServices
    {
        private readonly ILogger<IsTuruService> _logger;
        public IsTuruService(ILogger<IsTuruService> logger) : base(logger)
        {
            _logger = logger;
        }

        public bool IsTuruGuncelle(StIsturleri IsTuru)
        {
            try
            {

                base.Guncelle(IsTuru);
                throw new NotImplementedException("Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public List<StIsturleri> IsTuruListele(Expression<Func<StIsturleri, bool>> filter = null, params Expression<Func<StIsturleri, object>>[] includeProperties)
        {
            return DetayliListe(filter);
        }

        public bool IsTuruSil(StIsturleri isTuru)
        {
            try
            {

                isTuru.Deleted = true;
                Guncelle(isTuru);
                throw new NotImplementedException("Kayıt silme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public StIsturleri TekIsTuruGetir(int IsturuId)
        {
            return Getir(isTuru => isTuru.Id == IsturuId && isTuru.Deleted != true);
        }

        public override void Validate(StIsturleri entity)
        {
            throw new NotImplementedException();
        }

        public bool YeniIsTuruEkle(StIsturleri isTuru)
        {
            int counted = IsTuruListele().Count + 1;
            isTuru.IsTurleriId = counted;
            isTuru.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                Ekle(isTuru);
                throw new NotImplementedException("Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
