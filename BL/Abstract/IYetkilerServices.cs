using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IYetkilerServices : IABBEntityServis<YtYetkiler>
    {
        YtYetkiler TekYetkiGetir(int YetkiId);
        List<YtYetkiler> YetkileriListele(Expression<Func<YtYetkiler, bool>> filter = null,
            params Expression<Func<YtYetkiler, object>>[] includeProperties);
        bool YeniYetkiEkle(YtYetkiler yetki);
        bool TekYetkiSil(YtYetkiler yetki);
        bool TekYetkiGuncelle(YtYetkiler yetki);
    }
}
