using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using AKYSTRATEJI.ViewModals;
using BL.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            guncellenece_amac.Deleted = true;
            Guncelle(guncellenece_amac);
            throw new NotImplementedException();
        }

        bool IAmaclarService.Ekle(StAmaclar amac)
        {

            amac.AmacId = Listele().Count+1;
            amac.Id= Listele().Count+1;
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

        StAmaclar IAmaclarService.Guncelle(StAmaclar amac)
        {
            System.Diagnostics.Debug.WriteLine(amac.Adi);
            System.Diagnostics.Debug.WriteLine(amac.Deleted);
            base.Guncelle(amac);
            throw new NotImplementedException();
        }
    }
}
