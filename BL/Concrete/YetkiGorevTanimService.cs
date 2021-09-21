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
    public class YetkiGorevTanimService : ABBEntityServis<BrYetkiGorevTanimlari, AKYSTRATEJIContext>, IYetkiGorevTanimlariServices
    {
        private readonly ILogger<YetkiGorevTanimService> _logger;

        public YetkiGorevTanimService(ILogger<YetkiGorevTanimService> logger):base(logger)
        {
            _logger = logger;
        }

        public BrYetkiGorevTanimlari TekYetkiGorevTanimGetir(int YetkiGorevId)
        {
            try
            {

                return base.Getir(yetkigorev => yetkigorev.Id == YetkiGorevId && yetkigorev.Deleted != true);
                
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekYetkiGorevTanimGuncelle(BrYetkiGorevTanimlari YetkiGorevTanim)
        {
            try
            {

                base.Guncelle(YetkiGorevTanim);
                return true;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekYetkiGorevTanimSil(BrYetkiGorevTanimlari YetkiGorevTanim)
        {
            try
            {

                YetkiGorevTanim.Deleted = true;
                base.Guncelle(YetkiGorevTanim);
                return true;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(BrYetkiGorevTanimlari entity)
        {
            //throw new NotImplementedException();
        }

        public int YeniYetkiGorevTanimEkle(BrYetkiGorevTanimlari YetkiGorevTanim)
        {
            int counted = YetkiGorevTanimlariListele().Count + 1;
            YetkiGorevTanim.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                base.Ekle(YetkiGorevTanim);
                return counted;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public List<BrYetkiGorevTanimlari> YetkiGorevTanimlariListele(Expression<Func<BrYetkiGorevTanimlari, bool>> filter = null, params Expression<Func<BrYetkiGorevTanimlari, object>>[] includeProperties)
        {
            try
            {
                return base.DetayliListe(filter);
               
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
