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
    public class StratejiYiliService : ABBEntityServis<StStratejiyili, AKYSTRATEJIContext>, IStratejiYiliServices
    {
        private readonly ILogger<StratejiYiliService> _logger;

        public StratejiYiliService(ILogger<StratejiYiliService> logger):base(logger)
        {
            _logger = logger;
        }

        public List<StStratejiyili> StratejiYiliListele(Expression<Func<StStratejiyili, bool>> filter = null, params Expression<Func<StStratejiyili, object>>[] includeProperties)
        {
            try
            {
                return base.DetayliListe(filter);
                throw new NotImplementedException("StratejiYiliService/ Kayıt listeleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public StStratejiyili TekStratejiYiliGetir(int StratjeiyiliId)
        {
            try
            {

                return base.Getir(yil => yil.Id == StratjeiyiliId && yil.Deleted != true);
                throw new NotImplementedException("StratejiYiliService/ Tek Kayıt getirme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekStratejiYiliGuncelle(StStratejiyili yil)
        {
            try
            {

                base.Guncelle(yil);
                throw new NotImplementedException("StratejiYiliService/ Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekStratejiYiliSil(StStratejiyili yil)
        {
            try
            {

                yil.Deleted = true;
                base.Guncelle(yil);
                throw new NotImplementedException("StratejiYiliService/ Kayıt silme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(StStratejiyili entity)
        {
            throw new NotImplementedException();
        }

        public bool YeniStratejiYiliEkle(StStratejiyili yil)
        {
            int counted = StratejiYiliListele().Count + 1;
            yil.Id = counted;
            try
            {
                base.Ekle(yil);
                throw new NotImplementedException("StratejiYiliService/ Kayır Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
