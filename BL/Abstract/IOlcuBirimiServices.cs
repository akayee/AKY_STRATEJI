using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IOlcuBirimiServices : IABBEntityServis<GnOlcubirimi>
    {
        GnOlcubirimi TekOlcuBirimiGetir(int OlcuBirimiId);
        List<GnOlcubirimi> OlcuBirimiListele(Expression<Func<GnOlcubirimi, bool>> filter = null,
            params Expression<Func<GnOlcubirimi, object>>[] includeProperties);
        int YeniOlcuBirimiEkle(GnOlcubirimi OlcuBirimi);
        bool TekOlcuBirimiSil(GnOlcubirimi OlcuBirimi);
        bool TekOlcuBirimiGuncelle(GnOlcubirimi OlcuBirimi);
    }
}
