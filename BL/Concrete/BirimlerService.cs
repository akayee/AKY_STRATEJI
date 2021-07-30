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
    public class BirimlerService : ABBEntityServis<BrBirimler, AKYSTRATEJIContext>, IBirimServis
    {
        private readonly ILogger<BirimlerService> _logger;

        public BirimlerService(ILogger<BirimlerService> logger) : base(logger)
        {
            _logger = logger;
        }

        public bool BirimGuncelle(BrBirimler birim)
        {
            try
            {
                base.Guncelle(birim);
                throw new NotImplementedException("BirimlerService/ Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public List<BrBirimler> BirimlerListele(Expression<Func<BrBirimler, bool>> filter = null, params Expression<Func<BrBirimler, object>>[] includeProperties)
        {
            try
            {
                return base.DetayliListe(filter);
                throw new NotImplementedException("BirimlerService/ Kayıt listeleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool BirimSil(BrBirimler birim)
        {
            try
            {

                birim.Deleted = true;
                base.Guncelle(birim);
                throw new NotImplementedException("BirimlerService/ Kayıt silme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public BrBirimler TekBirimGetir(int BirimId)
        {
            try
            {

                return base.Getir(birim => birim.Id == BirimId && birim.Deleted != true);
                throw new NotImplementedException("BirimlerService/ Tek Kayıt getirme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(BrBirimler entity)
        {
            throw new NotImplementedException();
        }

        public bool YeniBirimEkle(BrBirimler birim)
        {
            int counted = BirimlerListele().Count + 1;
            birim.BirimId = counted;
            birim.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                base.Ekle(birim);
                throw new NotImplementedException("BirimlerService/ Kayır Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}