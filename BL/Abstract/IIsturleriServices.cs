﻿using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
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
        bool YeniIsTuruEkle(StIsturleri isTuru);
        bool IsTuruSil(StIsturleri isTuru);
        bool IsTuruGuncelle(StIsturleri IsTuru);
        

    }
}
