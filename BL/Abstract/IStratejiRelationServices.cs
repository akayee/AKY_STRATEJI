using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IStratejiRelationServices : IABBEntityServis<StStratejireleation>
    {
        List<StStratejireleation> StratejininYiliniListele(Expression<Func<StStratejireleation, bool>> filter = null,
            params Expression<Func<StStratejireleation, object>>[] includeProperties);
        bool YeniStratejiIliskiEkle(StStratejireleation Iliski);
        StStratejireleation TekStratejiRelationGetir(int id);
        bool TekStratejiIliskiSil(StStratejireleation Iliski);
        bool TopluStratejiIliskiEkle(List<StStratejireleation> StratejiIliskileri);
        bool TopluStratejiIliskiSil(List<StStratejireleation> StratejiIliskileri);
    }
}
