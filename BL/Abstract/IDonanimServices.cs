using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IDonanimServices : IABBEntityServis<BrDonanimlar>
    {
        BrDonanimlar TekDonanimGetir(int DonanimId);
        List<BrDonanimlar> DonanimListele(Expression<Func<BrDonanimlar, bool>> filter = null,
            params Expression<Func<BrDonanimlar, object>>[] includeProperties);
        int YeniDonanimEkle(BrDonanimlar donanim);
        bool DonanimSil(BrDonanimlar donanim);
        bool DonanimGuncelle(BrDonanimlar donanim);
    }
}
