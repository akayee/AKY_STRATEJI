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
    public class PersonelService : ABBEntityServis<BrPersoneller, AKYSTRATEJIContext>, IPersonellerServices
    {
        private readonly ILogger<PersonelService> _logger;

        public PersonelService(ILogger<PersonelService> logger):base(logger)
        {
            _logger = logger;
        }

        public List<BrPersoneller> PersonelleriListele(Expression<Func<BrPersoneller, bool>> filter = null, params Expression<Func<BrPersoneller, object>>[] includeProperties)
        {
            try
            {
                return base.GetList(filter,includeProperties);
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public BrPersoneller TekPersonelGetir(int PersonelId)
        {
            try
            {

                return base.Get(personel => personel.Id == PersonelId && personel.Deleted != true);
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekPersonelGuncelle(BrPersoneller Personel)
        {
            try
            {

                base.Guncelle(Personel);
                return (true);
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekPersonelSil(BrPersoneller Personel)
        {
            try
            {

                Personel.Deleted = true;
                base.Guncelle(Personel);
                return (true);
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(BrPersoneller entity)
        {
            //throw new NotImplementedException();
        }

        public int YeniPersonelEkle(BrPersoneller Personel)
        {
            int counted = PersonelleriListele().Count + 1;
            Personel.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                base.Ekle(Personel);
                return (counted);
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
