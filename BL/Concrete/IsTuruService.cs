using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using AKYSTRATEJI.ViewModals;
using BL.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class IsTuruService : ABBEntityServis<StIsturleri, AKYSTRATEJIContext>, IIsturleriServices
    {
        private readonly ILogger<IsTuruService> _logger;
        public IsTuruService(ILogger<IsTuruService> logger) : base(logger)
        {
            _logger = logger;
        }

        public bool IsTuruGuncelle(StIsturleri IsTuru)
        {
            try
            {

                base.Guncelle(IsTuru);
                return true;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public List<StIsturleri> IsTuruListele(Expression<Func<StIsturleri, bool>> filter = null, params Expression<Func<StIsturleri, object>>[] includeProperties)
        {
            return GetList(filter,includeProperties);
        }

        public bool IsTuruSil(StIsturleri isTuru)
        {
            try
            {

                isTuru.Deleted = true;
                base.Guncelle(isTuru);
                return true;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public StIsturleri TekIsTuruGetir(int IsturuId)
        {
            return Getir(isTuru => isTuru.Id == IsturuId && isTuru.Deleted != true,isturu=>isturu.Performans);
        }

        public override void Validate(StIsturleri entity)
        {
            //throw new NotImplementedException();
        }

        public int YeniIsTuruEkle(StIsturleri isTuru)
        {
            int counted = IsTuruListele().Count + 1;
            int nextisturuId = DetayliListe(obj=>obj.PerformansId==isTuru.PerformansId).Count + 1;
            isTuru.IsTurleriId = nextisturuId;
            isTuru.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                Ekle(isTuru);
                return counted;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
        public List<VMIsturleri> StratejiBilgileriHesapla(int birimid)
        {
            List<VMIsturleri> vmisturu = new List<VMIsturleri>();
            List<StIsturleri> isturleri = IsTuruListele(i => i.BirimId == birimid && i.Deleted!=true,i=>i.StIslers,isturleri=>isturleri.StYillikhedefs);
            int toplamdeger = 0;
            int firstpart = 0;
            int secondpart = 0;
            int thirdpart = 0;
            int lastpart = 0;
            foreach (StIsturleri isturu in isturleri)
            {

                List<StIsler> islistesi = isturu.StIslers.ToList();
                foreach(StIsler hesaplanacak in islistesi)
                {
                    toplamdeger += hesaplanacak.Deger;
                    if(hesaplanacak.OlusturmaTarihi.Month<5)
                    {
                        firstpart += hesaplanacak.Deger;
                    }else if(hesaplanacak.OlusturmaTarihi.Month > 4 && hesaplanacak.OlusturmaTarihi.Month < 9)
                    {
                        secondpart += hesaplanacak.Deger;
                    }
                    else if (hesaplanacak.OlusturmaTarihi.Month > 8 && hesaplanacak.OlusturmaTarihi.Month < 13)
                    {
                        thirdpart += hesaplanacak.Deger;
                    }
                    else
                    {
                        lastpart += hesaplanacak.Deger;
                    }
                }
                var yillikhedef = isturu.StYillikhedefs.Where(i => i.Yil == DateTime.Today.Year && i.IsTuruId == isturu.Id && i.Deleted != true).FirstOrDefault();
                VMIsturleri vmis = new VMIsturleri()
                {
                    Aciklama = isturu.Aciklama,
                    Adi=isturu.Adi,
                    BirimId=isturu.BirimId,
                    Deleted= (bool)isturu.Deleted,
                    id=isturu.Id,
                    PerformansId=isturu.PerformansId,
                    OlcuBirimi=isturu.OlcuBirimi,
                    YillikHedef=yillikhedef==null? 0:yillikhedef.Hedef,
                    ToplamDeger=toplamdeger,
                    FirstPart=firstpart,
                    SecondPart=secondpart,
                    ThirdPart=thirdpart,
                    LastPart=lastpart
 
                };
                vmisturu.Add(vmis);
            }

            return vmisturu;
        }
    }
}
