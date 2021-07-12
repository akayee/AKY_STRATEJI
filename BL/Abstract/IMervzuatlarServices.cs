using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IMervzuatlarServices : IABBEntityServis<BrMevzuatlar>
    {
        BrMevzuatlar TekmevzuatGetir(int MevzuatId);
        List<BrMevzuatlar> MevzuatlariListele(Expression<Func<BrMevzuatlar, bool>> filter = null,
            params Expression<Func<BrMevzuatlar, object>>[] includeProperties);
        bool YeniMevzuatEkle(BrMevzuatlar Mevzuat);
        bool TekMevzuatSil(BrMevzuatlar Mevzuat);
        bool TekmEvzuatGuncelle(BrMevzuatlar Mevzuat);
    }
}
