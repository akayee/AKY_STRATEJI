using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IIslerServices : IABBEntityServis<StIsler>
    {
        StIsler TekIsGetir(int IsId);
        List<StIsler> IsleriListele(Expression<Func<StIsler, bool>> filter = null,
            params Expression<Func<StIsler, object>>[] includeProperties);
        bool YeniIsEkle(StIsler isler);
        bool IsSil(StIsler isler);
        bool IsGuncelle(StIsler isler);
    }
}
