﻿using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IBirimServis : IABBEntityServis<BrBirimler>
    {
        BrBirimler TekBirimGetir(int BirimId);
        List<BrBirimler> BirimlerListele(Expression<Func<BrBirimler, bool>> filter = null,
            params Expression<Func<BrBirimler, object>>[] includeProperties);
        bool YeniBirimEkle(BrBirimler birim);
        bool BirimSil(BrBirimler birim);
        bool BirimGuncelle(BrBirimler birim);
    }
}