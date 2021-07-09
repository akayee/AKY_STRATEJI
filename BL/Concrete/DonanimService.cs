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
    public class DonanimService : ABBEntityServis<BrDonanimlar, AKYSTRATEJIContext>, IDonanimServices
    {
        private readonly ILogger<DonanimService> _logger;

        public DonanimService(ILogger<DonanimService> logger):base(logger)
        {
            _logger = logger;
        }

        public bool DonanimGuncelle(BrDonanimlar donanim)
        {
            try
            {

                base.Guncelle(donanim);
                throw new NotImplementedException("DonanimService/ Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public List<BrDonanimlar> DonanimListele(Expression<Func<BrDonanimlar, bool>> filter = null, params Expression<Func<BrDonanimlar, object>>[] includeProperties)
        {
            try
            {
                return DetayliListe(filter);
                throw new NotImplementedException("DonanimService/ Kayıt listeleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool DonanimSil(BrDonanimlar donanim)
        {
            try
            {

                donanim.Deleted = true;
                base.Guncelle(donanim);
                throw new NotImplementedException("DonanimService/ Kayıt silme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public BrDonanimlar TekDonanimGetir(int DonanimId)
        {
            try
            {

                return base.Getir(donanim => donanim.Id == DonanimId && donanim.Deleted != true);
                throw new NotImplementedException("DonanimService/ Tek Kayıt getirme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(BrDonanimlar entity)
        {
            throw new NotImplementedException();
        }

        public bool YeniDonanimEkle(BrDonanimlar donanim)
        {
            int counted = DonanimListele().Count + 1;
            donanim.DonanimId = counted;
            donanim.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                base.Ekle(donanim);
                throw new NotImplementedException("DonanimService/ Kayır Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
