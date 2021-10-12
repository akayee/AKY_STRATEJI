using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IHedeflerServices: IABBEntityServis<StHedefler>
    {
        StHedefler TekHedefGetir(int HedefId, params Expression<Func<StHedefler, object>>[] includeProperties);
        List<StHedefler> HedefleriListele();
        bool YeniHedefEkle(StHedefler hedef);
        bool HedefSil(StHedefler hedef);
        bool HedefGuncelle(StHedefler hedef);
    }
}
