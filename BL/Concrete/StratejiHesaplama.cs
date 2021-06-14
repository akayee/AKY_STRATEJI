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
    public class StratejiHesaplama : ABBEntityServis<StratejiBilgileri,AKYSTRATEJIContext>, IStratejiServis       
    {
        private int BirimId;
        private StratejiBilgileri Stratejibilgiler;
        private BirimBilgiler Birim;
        private int ToplamIsYuzdesi;
        private readonly ILogger<StratejiHesaplama> _logger;

        public StratejiHesaplama(ILogger<StratejiHesaplama> logger,int birimId, StratejiBilgileri stratejibilgiler, BirimBilgiler birim, int toplamIsYuzdesi): base(logger)
        {
            this.BirimId = birimId;
            this.Stratejibilgiler = stratejibilgiler ?? throw new ArgumentNullException(nameof(stratejibilgiler));
            this.Birim = birim ?? throw new ArgumentNullException(nameof(birim));
            this.ToplamIsYuzdesi = toplamIsYuzdesi;
            this._logger = logger;
        }

        public override void Validate(StratejiBilgileri entity)
        {
            throw new NotImplementedException();
        }

        BirimBilgiler IStratejiServis.BirimBilgileriGetir()
        {
            return Birim;
        }

        StratejiBilgileri IStratejiServis.StratejiBilgileriGetir()
        {
            return Stratejibilgiler;
        }

        int IStratejiServis.ToplamIslemYuzdesi()
        {
            return ToplamIsYuzdesi;


        }
    }
}
