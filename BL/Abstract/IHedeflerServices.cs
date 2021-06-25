using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IHedeflerServices: IABBEntityServis<StHedefler>
    {
        StHedefler Getir(int hedefId);
        List<StHedefler> Listele();
    }
}
