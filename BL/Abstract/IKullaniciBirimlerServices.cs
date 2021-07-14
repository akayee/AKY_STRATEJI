using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IKullaniciBirimlerServices : IABBEntityServis<KullanicilarBirimler>
    {
        // -WRN- Bu servis gereksiz olabilir.
        KullanicilarBirimler TekKullaniciBirimGetir(int KullaniciId,int birimId);
        List<KullanicilarBirimler> KullaniciBirimiListele(Expression<Func<KullanicilarBirimler, bool>> filter = null,
            params Expression<Func<KullanicilarBirimler, object>>[] includeProperties);
        bool YeniKullaniciBirimiEkle(KullanicilarBirimler kbirimi);
        bool TekKullaniciBirimiSil(KullanicilarBirimler kbirimi);
        bool TekKullaniciBirimiGuncelle(KullanicilarBirimler kbirimi);
    }
}
