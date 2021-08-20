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
    public class BirimlerService : ABBEntityServis<BrBirimler, AKYSTRATEJIContext>, IBirimServis
    {
        private readonly ILogger<BirimlerService> _logger;

        public BirimlerService(ILogger<BirimlerService> logger , IBirimTipleriServices birimtipi) : base(logger)
        {
            _logger = logger;
        }

        public bool BirimGuncelle(BrBirimler birim)
        {
            try
            {
                base.Guncelle(birim);
                return true;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public List<BrBirimler> BirimlerListele(Expression<Func<BrBirimler, bool>> filter = null, params Expression<Func<BrBirimler, object>>[] includeProperties)
        {
            try
            {
                return base.GetList(filter,birim=>birim.BirimTipi);
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool BirimSil(BrBirimler birim)
        {
            try
            {

                birim.Deleted = true;
                base.Guncelle(birim);
                return true;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public BrBirimler TekBirimGetir(int BirimId)
        {
            try
            {

                return base.Get(birim => birim.Id == BirimId && birim.Deleted != true,b=>b.BirimTipi);
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(BrBirimler entity)
        {
            //throw new NotImplementedException();
        }

        public int YeniBirimEkle(BrBirimler birim)
        {
            int counted = BirimlerListele().Count + 1;
            birim.BirimId = counted;
            birim.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                base.Ekle(birim);
                return (birim.Id);
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
        public int UstBirimGetir(int BirimId)
        {

            BrBirimler birim = base.Get(null, birim => birim.BirimTipi);
            if(birim.BirimTipi.Id !=4)
            {
                int ustbirimId = (int)birim.UstBirimId;
                UstBirimGetir((int)birim.UstBirimId);
                return ustbirimId;
            }
            else
            {

                return birim.Id;
            }

        }
    }
}
