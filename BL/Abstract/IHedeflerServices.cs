using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IHedeflerServices: IABBEntityServis<StHedefler>
    {
        StHedefler TekHedefGetir(int HedefId);
        List<StHedefler> HedefleriListele();
        bool YeniHedefEkle(StHedefler hedef);
        bool HedefSil(StHedefler hedef);
        bool HedefGuncelle(StHedefler hedef);
    }
}
