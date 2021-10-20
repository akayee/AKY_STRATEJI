using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IStratejiYiliServices : IABBEntityServis<StStratejiyili>
    {
        StStratejiyili TekStratejiYiliGetir(int StratjeiyiliId);
        List<StStratejiyili> StratejiYiliListele(Expression<Func<StStratejiyili, bool>> filter = null,
            params Expression<Func<StStratejiyili, object>>[] includeProperties);
        int YeniStratejiYiliEkle(StStratejiyili yil);
        bool TekStratejiYiliSil(StStratejiyili yil);
        bool TekStratejiYiliGuncelle(StStratejiyili yil);
    }
}
