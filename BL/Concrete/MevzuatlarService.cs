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
    public class MevzuatlarService : ABBEntityServis<BrMevzuatlar, AKYSTRATEJIContext>, IMervzuatlarServices
    {
        private readonly ILogger<MevzuatlarService> _logger;

        public MevzuatlarService(ILogger<MevzuatlarService> logger):base(logger)
        {
            _logger = logger;
        }

        public List<BrMevzuatlar> MevzuatlariListele(Expression<Func<BrMevzuatlar, bool>> filter = null, params Expression<Func<BrMevzuatlar, object>>[] includeProperties)
        {
            try
            {
                return base.DetayliListe(filter);
                throw new NotImplementedException("MevzuatlarService/ Kayıt listeleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekMevzuatSil(BrMevzuatlar Mevzuat)
        {
            try
            {

                Mevzuat.Deleted = true;
                base.Guncelle(Mevzuat);
                throw new NotImplementedException("MevzuatlarService/ Kayıt silme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public BrMevzuatlar TekmevzuatGetir(int MevzuatId)
        {
            try
            {

                return base.Getir(mevzuat => mevzuat.Id == MevzuatId && mevzuat.Deleted != true);
                throw new NotImplementedException("MevzuatlarService/ Tek Kayıt getirme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekmEvzuatGuncelle(BrMevzuatlar Mevzuat)
        {
            try
            {

                base.Guncelle(Mevzuat);
                throw new NotImplementedException("MevzuatlarService/ Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(BrMevzuatlar entity)
        {
            throw new NotImplementedException();
        }

        public bool YeniMevzuatEkle(BrMevzuatlar Mevzuat)
        {
            int counted = MevzuatlariListele().Count + 1;
            Mevzuat.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                base.Ekle(Mevzuat);
                throw new NotImplementedException("MevzuatlarService/ Kayır Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
