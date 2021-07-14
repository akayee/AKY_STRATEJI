using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IYetkiGruplariServices : IABBEntityServis<YtYetkigruplari>
    {
        YtYetkigruplari TekYetkiGrubuGetir(int yetkigId);
        List<YtYetkigruplari> YetkiGruplariListele(Expression<Func<YtYetkigruplari, bool>> filter = null,
            params Expression<Func<YtYetkigruplari, object>>[] includeProperties);
        bool YeniYetkiGrubuEkle(YtYetkigruplari yetkig);
        bool TekYetkiGrubuSil(YtYetkigruplari yetkig);
        bool TekYetkiGrubuGuncelle(YtYetkigruplari yetkig);
    }
}
