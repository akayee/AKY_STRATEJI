using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using AKYSTRATEJI.ViewModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IAmaclarService:IABBEntityServis<StAmaclar>
    {
        StAmaclar AmacGetir(int AmacId);
        List<StAmaclar> Listele();
        bool Ekle(StAmaclar amac);
        bool Sil(StAmaclar amac);
        StAmaclar Guncelle(StAmaclar amac);

    }
}
