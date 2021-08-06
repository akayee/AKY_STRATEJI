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
    public interface IFaaliyetTurleriServices : IABBEntityServis<StFaaliyetler>
    {
        StFaaliyetler FaaliyetTuruGetir(int FaaliyetId);
        List<StFaaliyetler> FaaliyetTurleriListele(Expression<Func<StFaaliyetler, bool>> filter = null,
            params Expression<Func<StFaaliyetler, object>>[] includeProperties);
        bool YeniFaaliyetTuruEkle(StFaaliyetler FaaliyetTuru);
        bool TekFaaliyetTuruSil(StFaaliyetler FaaliyetTuru);
        bool TekFaaliyetTuruGuncelle(StFaaliyetler FaaliyetTuru);

        public List<VMFaaliyetTurleri> StratejiBilgileriHesapla(int birimid);
    }
}
