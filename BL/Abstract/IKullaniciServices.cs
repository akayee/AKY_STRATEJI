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
    public interface IKullaniciServices:IABBEntityServis<Kullanicilar>
    {
        Kullanicilar TekKullaniciGetir(int KullaniciId);
        List<Kullanicilar> KullaniciListele(Expression<Func<Kullanicilar, bool>> filter = null,
            params Expression<Func<Kullanicilar, object>>[] includeProperties);
        bool YeniKullaniciEkle(Kullanicilar user);
        bool TekKullaniciSil(Kullanicilar user);
        bool TekKullaniciGuncelle(Kullanicilar user);
    }
}
