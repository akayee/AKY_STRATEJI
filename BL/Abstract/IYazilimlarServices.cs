using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IYazilimlarServices : IABBEntityServis<BrYazilimlar>
    {
        BrYazilimlar TekYazilimGetir(int YazilimId);
        List<BrYazilimlar> YaizimlariListele(Expression<Func<BrYazilimlar, bool>> filter = null,
            params Expression<Func<BrYazilimlar, object>>[] includeProperties);
        bool YeniYazilimEkle(BrYazilimlar Yazilim);
        bool TekYazilimSil(BrYazilimlar Yazilim);
        bool TekYazilimGuncelle(BrYazilimlar Yazilim);
    }
}
