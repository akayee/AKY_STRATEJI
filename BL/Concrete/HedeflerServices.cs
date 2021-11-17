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
    public class HedeflerServices : ABBEntityServis<StHedefler, AKYSTRATEJIContext>, IHedeflerServices
    {
        private readonly ILogger<HedeflerServices> _logger;

        public HedeflerServices(ILogger<HedeflerServices> logger) : base(logger)
        {
            _logger = logger;
        }
        public StHedefler TekHedefGetir(int HedefId, params Expression<Func<StHedefler, object>>[] includeProperties)
        {
            return Getir(hedef => hedef.Id == HedefId && hedef.Deleted != true, includeProperties);
        }

        public List<StHedefler> HedefleriListele(Expression<Func<StIsturleri, bool>> filter = null, params Expression<Func<StIsturleri, object>>[] includeProperties)
        {
            return DetayliListe();
        }

        public override void Validate(StHedefler entity)
        {
            // veri eklemedeki "The method or operation is not implemented." hatası validate yüzünden geliyor.
            //throw new NotImplementedException();
        }

        public int YeniHedefEkle(StHedefler hedef)
        {
            int counted = HedefleriListele().Count + 1;
            int nexthedefid = DetayliListe(obj=>obj.AmaclarId==hedef.AmaclarId).Count + 1;
            hedef.HedeflerId = nexthedefid;
            hedef.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                Ekle(hedef);
                return counted;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool HedefSil(StHedefler hedef)
        {
            try
            {

                hedef.Deleted = true;
                Guncelle(hedef);
                return true;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool HedefGuncelle(StHedefler hedef)
        {
            try
            {

                base.Guncelle(hedef);
                return true;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
