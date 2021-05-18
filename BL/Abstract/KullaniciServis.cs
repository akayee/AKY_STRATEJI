using AKYSTRATEJI.ViewModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface KullaniciServis
    {
        VMKullanicilar KullaniciBilgileriniGetir();
        VMYetkilervYetkiGruplari YetjikeriGetir();
    }
}
