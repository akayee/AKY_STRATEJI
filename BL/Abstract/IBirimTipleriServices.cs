using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IBirimTipleriServices : IABBEntityServis<BrBirimtipleri>
    {
        BrBirimtipleri TekBirimTipiGetir(int BirimTipiId);
        List<BrBirimtipleri> BirimTipleriListele(Expression<Func<BrBirimtipleri, bool>> filter = null,
            params Expression<Func<BrBirimtipleri, object>>[] includeProperties);
        bool YeniBirimTipiEkle(BrBirimtipleri BirimTipi);
        bool TekBirimTipiSil(BrBirimtipleri BirimTipi);
        bool TekBirimTipiGuncelle(BrBirimtipleri BirimTipi);
    }
}
