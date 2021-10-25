using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using AKYSTRATEJI.ViewModals;
using BL.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class FaaliyetTuruService : ABBEntityServis<StFaaliyetler, AKYSTRATEJIContext>, IFaaliyetTurleriServices
    {
        private readonly ILogger<FaaliyetTuruService> _logger;
        private readonly IFaaliyetServices _faaliyetservices;
        private readonly IYillikHedefServices _yillikhedefler;

        public FaaliyetTuruService(ILogger<FaaliyetTuruService> logger, IFaaliyetServices faaliyetservices, IYillikHedefServices yillikhedefler):base(logger)
        {
            _logger = logger;
            _faaliyetservices = faaliyetservices;
            _yillikhedefler = yillikhedefler;
        }

        public List<StFaaliyetler> FaaliyetTurleriListele(Expression<Func<StFaaliyetler, bool>> filter = null, params Expression<Func<StFaaliyetler, object>>[] includeProperties)
        {
            return DetayliListe(filter);
        }

        public StFaaliyetler FaaliyetTuruGetir(int FaaliyetId)
        {
            return base.Getir(isTuru => isTuru.Id == FaaliyetId && isTuru.Deleted != true);
        }

        public bool TekFaaliyetTuruGuncelle(StFaaliyetler FaaliyetTuru)
        {
            try
            {

                base.Guncelle(FaaliyetTuru);
                throw new NotImplementedException("FaaliyetTuruService// Kayıt güncelleme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool TekFaaliyetTuruSil(StFaaliyetler FaaliyetTuru)
        {
            try
            {

                FaaliyetTuru.Deleted = true;
                base.Guncelle(FaaliyetTuru);
                throw new NotImplementedException("FaaliyetTuruService// Kayıt silme başarılı");
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(StFaaliyetler entity)
        {
            //throw new NotImplementedException();
        }

        public int YeniFaaliyetTuruEkle(StFaaliyetler FaaliyetTuru)
        {
            int counted = FaaliyetTurleriListele().Count + 1;
            int nextfaaliyetId = DetayliListe(obj=>obj.PerformansId==FaaliyetTuru.PerformansId).Count + 1;
            FaaliyetTuru.FaaliyetlerId = nextfaaliyetId;
            FaaliyetTuru.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                Ekle(FaaliyetTuru);
                return nextfaaliyetId;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public List<VMFaaliyetTurleri> StratejiBilgileriHesapla(int birimid)
        {
            List<VMFaaliyetTurleri> vmisturu = new List<VMFaaliyetTurleri>();
            List<StFaaliyetler> isturleri = FaaliyetTurleriListele(i => i.BirimId == birimid && i.Deleted!=true);
            int toplamdeger = 0;
            int firstpart = 0;
            int secondpart = 0;
            int thirdpart = 0;
            int lastpart = 0;
            foreach (StFaaliyetler isturu in isturleri)
            {

                List<StFaaliyet> islistesi = _faaliyetservices.FaaliyetListele(isler => isler.FaaliyetlerId == isturu.Id && isler.Deleted!=true);
                foreach (StFaaliyet hesaplanacak in islistesi)
                {
                    if(isturu.Maaliyet is not null)
                    {
                        toplamdeger+=(hesaplanacak.Deger * (int)isturu.Maaliyet);
                        if (hesaplanacak.OlusturmaTarihi.Month < 5)
                        {
                            firstpart += (hesaplanacak.Deger * (int)isturu.Maaliyet);
                        }
                        else if (hesaplanacak.OlusturmaTarihi.Month > 4 && hesaplanacak.OlusturmaTarihi.Month < 9)
                        {
                            secondpart += (hesaplanacak.Deger * (int)isturu.Maaliyet);
                        }
                        else if (hesaplanacak.OlusturmaTarihi.Month > 8 && hesaplanacak.OlusturmaTarihi.Month < 13)
                        {
                            thirdpart += (hesaplanacak.Deger * (int)isturu.Maaliyet);
                        }
                        else
                        {
                            lastpart += (hesaplanacak.Deger * (int)isturu.Maaliyet);
                        }
                    }
                    else
                    {
                        toplamdeger += hesaplanacak.Deger;
                        if (hesaplanacak.OlusturmaTarihi.Month < 5)
                        {
                            firstpart += hesaplanacak.Deger;
                        }
                        else if (hesaplanacak.OlusturmaTarihi.Month > 4 && hesaplanacak.OlusturmaTarihi.Month < 9)
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
                    
                }
                var yillikhedef = _yillikhedefler.YillikHedefleriListele(i => i.Yil == DateTime.Today.Year && i.FaaliyetId == isturu.Id && i.Deleted!=true).FirstOrDefault();
                VMFaaliyetTurleri vmis = new VMFaaliyetTurleri()
                {
                    Aciklama = isturu.Aciklama,
                    Adi = isturu.Adi,
                    BirimId = isturu.BirimId,
                    Deleted = (bool)isturu.Deleted,
                    id = isturu.Id,
                    PerformansId = isturu.PerformansId,
                    OlcuBirimiId = isturu.OlcuBirimi,
                    YillikHedef = yillikhedef.Hedef,
                    ToplamDeger = toplamdeger,
                    FirstPart = firstpart,
                    SecondPart = secondpart,
                    ThirdPart = thirdpart,
                    LastPart = lastpart,
                    IsturleriId=(int)isturu.IsTuruId,
                    OlusturmaTarihi=isturu.OlusturmaTarihi,
                    FaaliyetlerId=isturu.FaaliyetlerId

                };
                vmisturu.Add(vmis);
            }

            return vmisturu;
        }


    }
}
