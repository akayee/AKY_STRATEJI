using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BL.Abstract
{
    public interface IPerformanslarServices : IABBEntityServis<StPerformanslar>
    {
        StPerformanslar TekPerformansGetir(int PerformansId);
        List<StPerformanslar> PerformanslariListele(Expression<Func<StPerformanslar, bool>> filter = null, params Expression<Func<StPerformanslar, object>>[] includeProperties);
        int YeniPerformansEkle(StPerformanslar performans);
        bool PerformansSil(StPerformanslar performans);
        bool PerformansGuncelle(StPerformanslar performans);

    }
}
