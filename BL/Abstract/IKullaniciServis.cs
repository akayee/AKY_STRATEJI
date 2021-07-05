using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using AKYSTRATEJI.ViewModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IKullaniciServis:IABBEntityServis<Kullanicilar>
    {
        VMKullanicilar KullaniciBilgileriniGetir();
        VMYetkilervYetkiGruplari YetkileriGetir();
        VMKullanicilar KullaniciOlustur();
        bool SifreDegistir();
    }
}
