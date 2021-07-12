using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IPersonellerServices : IABBEntityServis<BrPersoneller>
    {
        BrPersoneller TekPersonelGetir(int PersonelId);
        List<BrPersoneller> PersonelleriListele(Expression<Func<BrPersoneller, bool>> filter = null,
            params Expression<Func<BrPersoneller, object>>[] includeProperties);
        bool YeniPersonelEkle(BrPersoneller Personel);
        bool TekPersonelSil(BrPersoneller Personel);
        bool TekPersonelGuncelle(BrPersoneller Personel);
    }
}
