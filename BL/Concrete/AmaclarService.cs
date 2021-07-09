using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using BL.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BL.Concrete
{
    public class AmaclarService : ABBEntityServis<StAmaclar, AKYSTRATEJIContext>, IAmaclarService
    {
        private readonly ILogger<AmaclarService> _logger;

        public AmaclarService(ILogger<AmaclarService> logger) : base(logger)
        {
            _logger = logger;
        }

        public StAmaclar AmacGetir(int AmacId)
        {

            return Getir(amac => amac.Id == AmacId && amac.Deleted != true);
        }

        public List<StAmaclar> Listele()
        {
            return DetayliListe(amaclar => amaclar.Deleted!=true);
        }

        public override void Validate(StAmaclar entity)
        {
            //throw new NotImplementedException();
        }

        public bool Sil(StAmaclar guncellenece_amac)
        {
            try
            {

                guncellenece_amac.Deleted = true;
                Guncelle(guncellenece_amac);
                throw new NotImplementedException("Kayıt silme başarılı");
            }
            catch(Exception e)
            {
                throw new NotImplementedException(e.Message);
            }

            
        }

        public bool AmacEkle(StAmaclar amac)
        {
            int counted = Listele().Count + 1;
            amac.AmacId = counted;
            amac.Id= counted;
            amac.Deleted = false;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                Ekle(amac);
                throw new NotImplementedException("Başarıyla Eklendi");
            }
            catch(Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
          

        }

        public bool AmacGuncelle(StAmaclar amac)
        {
            try
            {

                base.Guncelle(amac);
                throw new NotImplementedException("Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            } 
        }
    }
}
