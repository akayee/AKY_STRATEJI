using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IFizikselYapilarServices : IABBEntityServis<BrFizikselYapilar>
    {
        BrFizikselYapilar TekFizikselYapiGetir(int FizikselYapiId);
        List<BrFizikselYapilar> FizikselYapilariListele(Expression<Func<BrFizikselYapilar, bool>> filter = null,
            params Expression<Func<BrFizikselYapilar, object>>[] includeProperties);
        int YeniFizikselYapiEkle(BrFizikselYapilar FizikselYapi);
        bool TekFizikselYapiSil(BrFizikselYapilar FizikselYapi);
        bool TekFizikselYapiGuncelle(BrFizikselYapilar FizikselYapi);
    }
}
