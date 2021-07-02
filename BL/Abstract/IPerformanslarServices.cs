using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System.Collections.Generic;

namespace BL.Abstract
{
    public interface IPerformanslarServices : IABBEntityServis<StPerformanslar>
    {
        StPerformanslar TekPerformansGetir(int PerformansId);
        List<StPerformanslar> PerformanslariListele();
        bool YeniPerformansEkle(StPerformanslar performans);
        bool PerformansSil(StPerformanslar performans);
        bool PerformansGuncelle(StPerformanslar performans);

    }
}
