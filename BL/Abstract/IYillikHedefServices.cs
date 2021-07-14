using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IYillikHedefServices : IABBEntityServis<StYillikhedef>
    {
        StYillikhedef TekYillikHedefGetir(int yehedefId);
        List<StYillikhedef> YillikHedefleriListele(Expression<Func<StYillikhedef, bool>> filter = null,
            params Expression<Func<StYillikhedef, object>>[] includeProperties);
        bool YeniYillikHedefEkle(StYillikhedef yhedef);
        bool TekYillikHedefSil(StYillikhedef yhedef);
        bool TekYillikHedefGuncelle(StYillikhedef yhedef);
    }
}
