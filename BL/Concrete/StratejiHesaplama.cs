using AKYSTRATEJI.ViewModals;
using BL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class StratejiHesaplama : IStratejiServis       
    {
        private int BirimId;
        private StratejiBilgileri Stratejibilgiler;
        private BirimBilgiler Birim;
        private int ToplamIsYuzdesi;       

        public StratejiHesaplama(int BirimId)
        {
            this.BirimId = BirimId;
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
