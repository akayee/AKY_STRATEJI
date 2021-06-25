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
            return Getir(amac => amac.Id == AmacId);
        }

        public List<StAmaclar> Listele()
        {
            return DetayliListe();
        }

        public override void Validate(StAmaclar entity)
        {
            throw new NotImplementedException();
        }

        public bool Sil(StAmaclar guncellenece_amac)
        {
            Guncelle(guncellenece_amac);
            throw new NotImplementedException();
        }

        bool IAmaclarService.Ekle(StAmaclar amac)
        {

            amac.AmacId = Listele().Count;
            amac.Id= Listele().Count;
            amac.StHedeflers =null;
            amac.StratejiyiliAmaclars = null;
            Ekle(amac);
            Console.WriteLine("Amaclar Servisi");
          throw new NotImplementedException("Servisde hata");

        }

        StAmaclar IAmaclarService.Guncelle(StAmaclar amac)
        {
            Guncelle(amac);
            throw new NotImplementedException();
        }
    }
}
