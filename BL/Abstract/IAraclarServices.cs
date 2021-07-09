using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IAraclarServices : IABBEntityServis<BrAraclar>
    {
        BrAraclar TekAracGetir(int AracId);
        List<BrAraclar> AracListele(Expression<Func<BrAraclar, bool>> filter = null,
            params Expression<Func<BrAraclar, object>>[] includeProperties);
        bool YeniAracEkle(BrAraclar arac);
        bool AracSil(BrAraclar arac);
        bool AracGuncelle(BrAraclar arac);
    }
}
