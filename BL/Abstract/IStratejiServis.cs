using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using AKYSTRATEJI.ViewModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IStratejiServis : IABBEntityServis<StratejiBilgileri>
    {
        // Yıl sonu devirleri bu serviste sağlanacak yani Performans Planları bu ekran sayesinde oluşacak.
        public BirimBilgiler BirimBilgileriGetir();
        public StratejiBilgileri StratejiBilgileriGetir();

        public int ToplamIslemYuzdesi();

    }
}
