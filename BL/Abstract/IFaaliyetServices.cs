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
    public interface IFaaliyetServices : IABBEntityServis<StFaaliyet>
    {
        StFaaliyet TekFaaliyetGetir(int FaaliyetId);
        List<StFaaliyet> FaaliyetListele(Expression<Func<StFaaliyet, bool>> filter = null,
            params Expression<Func<StFaaliyet, object>>[] includeProperties);
        int YeniFaaliyetEkle(StFaaliyet faaliyet);
        bool TekFaaliyetSil(StFaaliyet faaliyet);
        bool TekFaaliyetGuncelle(StFaaliyet faaliyet);
    }
}
