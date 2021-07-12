﻿using ABB.Core.DataAccess;
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
    public class BirimTipiService : ABBEntityServis<BrBirimtipleri, AKYSTRATEJIContext>, IBirimTipleriServices
    {
        private readonly ILogger<BirimTipiService> _logger;

        public BirimTipiService(ILogger<BirimTipiService> logger):base(logger)
        {
            _logger = logger;
        }

        public List<BrBirimtipleri> BirimTipleriListele(Expression<Func<BrBirimtipleri, bool>> filter = null, params Expression<Func<BrBirimtipleri, object>>[] includeProperties)
        {
            try
            {
                return base.DetayliListe(filter);
                throw new NotImplementedException("BrBirimtipleriService/ Kayıt listeleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public BrBirimtipleri TekBirimTipiGetir(int BirimTipiId)
        {
            try
            {

                return base.Getir(birimtipi => birimtipi.Id == BirimTipiId && birimtipi.Deleted != true);
                throw new NotImplementedException("BrBirimtipleriService/ Tek Kayıt getirme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekBirimTipiGuncelle(BrBirimtipleri BirimTipi)
        {
            try
            {

                base.Guncelle(BirimTipi);
                throw new NotImplementedException("BrBirimtipleriService/ Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekBirimTipiSil(BrBirimtipleri BirimTipi)
        {
            try
            {

                BirimTipi.Deleted = true;
                base.Guncelle(BirimTipi);
                throw new NotImplementedException("BrBirimtipleriService/ Kayıt silme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(BrBirimtipleri entity)
        {
            throw new NotImplementedException();
        }

        public bool YeniBirimTipiEkle(BrBirimtipleri BirimTipi)
        {
            int counted = BirimTipleriListele().Count + 1;
            BirimTipi.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                base.Ekle(BirimTipi);
                throw new NotImplementedException("BrBirimtipleriService/ Kayır Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
