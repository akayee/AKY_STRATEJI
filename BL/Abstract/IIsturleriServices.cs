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
    public interface IIsturleriServices : IABBEntityServis<StIsturleri>
    {
        StIsturleri TekIsTuruGetir(int IsturuId);
        List<StIsturleri> IsTuruListele(Expression<Func<StIsturleri, bool>> filter = null,
            params Expression<Func<StIsturleri, object>>[] includeProperties);
        int YeniIsTuruEkle(StIsturleri isTuru);
        bool IsTuruSil(StIsturleri isTuru);
        bool IsTuruGuncelle(StIsturleri IsTuru);
        public List<VMIsturleri> StratejiBilgileriHesapla(int birimid);
        public List<VMIsturleri> FaaliyetRaporuHesapla(int performansId);



    }
}
