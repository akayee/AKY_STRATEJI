using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using AKYSTRATEJI.ViewModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IAmaclarService:IABBEntityServis<StAmaclar>
    {
        StAmaclar AmacGetir(int AmacId);
        List<StAmaclar> Listele(Expression<Func<StAmaclar, bool>> filter = null, params Expression<Func<StAmaclar, object>>[] includeProperties);
        int AmacEkle(StAmaclar amac);
        bool Sil(StAmaclar amac);
        bool AmacGuncelle(StAmaclar amac);

    }
}
