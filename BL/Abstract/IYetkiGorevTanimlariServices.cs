using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IYetkiGorevTanimlariServices : IABBEntityServis<BrYetkiGorevTanimlari>
    {
        BrYetkiGorevTanimlari TekYetkiGorevTanimGetir(int YetkiGorevId);
        List<BrYetkiGorevTanimlari> YetkiGorevTanimlariListele(Expression<Func<BrYetkiGorevTanimlari, bool>> filter = null,
            params Expression<Func<BrYetkiGorevTanimlari, object>>[] includeProperties);
        int YeniYetkiGorevTanimEkle(BrYetkiGorevTanimlari YetkiGorevTanim);
        bool TekYetkiGorevTanimSil(BrYetkiGorevTanimlari YetkiGorevTanim);
        bool TekYetkiGorevTanimGuncelle(BrYetkiGorevTanimlari YetkiGorevTanim);
    }
}
