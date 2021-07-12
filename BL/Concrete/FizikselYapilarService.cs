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
    public class FizikselYapilarService : ABBEntityServis<BrFizikselYapilar, AKYSTRATEJIContext>, IFizikselYapilarServices
    {
        private readonly ILogger<FizikselYapilarService> _logger;

        public FizikselYapilarService(ILogger<FizikselYapilarService> logger):base(logger)
        {
            _logger = logger;
        }

        public List<BrFizikselYapilar> FizikselYapilariListele(Expression<Func<BrFizikselYapilar, bool>> filter = null, params Expression<Func<BrFizikselYapilar, object>>[] includeProperties)
        {
            try
            {
                return base.DetayliListe(filter);
                throw new NotImplementedException("FizikselYapilarService/ Kayıt listeleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public BrFizikselYapilar TekFizikselYapiGetir(int FizikselYapiId)
        {
            try
            {

                return base.Getir(fizikselyapi => fizikselyapi.Id == FizikselYapiId && fizikselyapi.Deleted != true);
                throw new NotImplementedException("FizikselYapilarService/ Tek Kayıt getirme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekFizikselYapiGuncelle(BrFizikselYapilar FizikselYapi)
        {
            try
            {

                base.Guncelle(FizikselYapi);
                throw new NotImplementedException("FizikselYapilarService/ Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekFizikselYapiSil(BrFizikselYapilar FizikselYapi)
        {
            try
            {

                FizikselYapi.Deleted = true;
                base.Guncelle(FizikselYapi);
                throw new NotImplementedException("FizikselYapilarService/ Kayıt silme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(BrFizikselYapilar entity)
        {
            throw new NotImplementedException();
        }

        public bool YeniFizikselYapiEkle(BrFizikselYapilar FizikselYapi)
        {
            int counted = FizikselYapilariListele().Count + 1;
            FizikselYapi.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                base.Ekle(FizikselYapi);
                throw new NotImplementedException("FizikselYapilarService/ Kayır Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
