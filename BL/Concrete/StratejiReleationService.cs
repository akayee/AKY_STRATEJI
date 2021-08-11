using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using BL.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class StratejiReleationService : ABBEntityServis<StStratejireleation, AKYSTRATEJIContext>, IStratejiRelationServices
    {
        public readonly ILogger<StratejiReleationService> _logger;
        public StratejiReleationService(ILogger<StratejiReleationService> logger) : base(logger)
        {
            _logger = logger;
        }

        public List<StStratejireleation> StratejininYiliniListele(Expression<Func<StStratejireleation, bool>> filter = null, params Expression<Func<StStratejireleation, object>>[] includeProperties)
        {            
            return base.DetayliListe(filter);
        }

        public bool TekStratejiIliskiSil(StStratejireleation Iliski)
        {
            try
            {
                Iliski.Deleted = true;
                base.Guncelle(Iliski);
            }catch(Exception e)
            {
                _logger.LogCritical(e, "ABBEntityServis Beklenmeyen Hata");
                throw new Exception("Beklenmeyen Hata");
            }

            return true;
        }

        public StStratejireleation TekStratejiRelationGetir(int id)
        {
            return base.Getir(i=> i.Id==id);
        }

        public bool TopluStratejiIliskiEkle(List<StStratejireleation> StratejiIliskileri)
        {
            base.TopluEkle(StratejiIliskileri);
            return true;
        }

        public bool TopluStratejiIliskiSil(List<StStratejireleation> StratejiIliskileri)
        {
            for (int i = 0; i < StratejiIliskileri.Count; i++)
            {
                StratejiIliskileri[i].Deleted = true;
                base.Guncelle(StratejiIliskileri[i]);
            }
            return true;
        }

        public override void Validate(StStratejireleation entity)
        {
            
        }

        public bool YeniStratejiIliskiEkle(StStratejireleation Iliski)
        {
            try
            {
                base.Ekle(Iliski);
            } catch(Exception e)
            {
                return false;
            }
            return true;
            
        }
    }
}
