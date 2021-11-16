using ABB.WebMvcUI.Models;
using AKYSTRATEJI.Model;
using AKYSTRATEJI.ViewModals;
using BL.Abstract;
using BL.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepApiAKY.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IslerController:ControllerBase
    {
        //Yapılan işlerin toplamı burada hesaplanacak
        private readonly ILogger<IslerController> _logger;
        private readonly IIslerServices _isler;
        private readonly IIsturleriServices _isTurleri;
        private readonly IPerformanslarServices _performanslarservices;
        private readonly IFaaliyetServices _faaliyetservices;
        private readonly IFaaliyetTurleriServices _faaliyetturleriservices;
        private readonly IBirimServis _birimler;
        private readonly IHedeflerServices _hedefler;

        public IslerController(ILogger<IslerController> logger, IIslerServices isler, IIsturleriServices isTurleri, IPerformanslarServices performanslarservices, IIsturleriServices isturleriservices, IFaaliyetServices faaliyetservices, IFaaliyetTurleriServices faaliyetturleriservices, IBirimServis birimler,IHedeflerServices hedefler)
        {
            _logger = logger;
            _isler = isler;
            _isTurleri = isTurleri;
            _performanslarservices = performanslarservices;
            _faaliyetservices = faaliyetservices;
            _faaliyetturleriservices = faaliyetturleriservices;
            _birimler = birimler;
            _hedefler = hedefler;
        }

        [HttpGet("GetAnIs")]
        public JsonResult GetIs(int id)
        {
            //Tek Is getirme.
            StIsler stIsler = _isler.TekIsGetir(id);
            if (!(stIsler is null))
            {
                var model = new VMIsler()
                {
                    id = stIsler.Id,
                    OlusturmaTarihi = stIsler.OlusturmaTarihi,
                    Deleted = (bool)stIsler.Deleted,
                    IsturuId = stIsler.IsTuruId,
                    BaslangicTarihi = stIsler.BaslangicTarihi,
                    BitisTarihi = stIsler.BitisTarihi,
                    Ilce = (AKYSTRATEJI.enums.Ilceler)stIsler.Ilce,
                    Mahalle = (AKYSTRATEJI.enums.Mahalleler)stIsler.Mahalle,
                    Deger = stIsler.Deger,

                };

                return new JsonResult(model);

            }
            else
            {

                return new JsonResult("Veri Bulunmuyor");
            }
            

            
            
            //İslere bağlı olduğu İstürü getirme.
            //ViewModal Mapleme işlemi.
            

            
        }
        [HttpGet("GetListofIsler")]
        public JsonResult IsleriListele()
        {
            //Veritabanından StIsler tablosunun listesini almaişlemi.
            List<StIsler> Isler = _isler.IsleriListele();
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMIsler> vmListe = new List<VMIsler>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (StIsler isturu in Isler)
            {
                
                vmListe.Add(new VMIsler()
                {
                    id = isturu.Id,
                    IsturuId = isturu.IsTuruId,
                    Deleted = (bool)isturu.Deleted,
                    OlusturmaTarihi = isturu.OlusturmaTarihi,
                    BaslangicTarihi = isturu.BaslangicTarihi,
                    BitisTarihi = isturu.BitisTarihi,
                    Ilce = (AKYSTRATEJI.enums.Ilceler)isturu.Ilce,
                    Mahalle = (AKYSTRATEJI.enums.Mahalleler)isturu.Mahalle,
                    Deger = isturu.Deger
                });
            }

            return new JsonResult(vmListe);
        }

        
        [HttpPost("AddNewIs")]
        public IActionResult YeniIsEkle(VMIsler eklenecek)
        {

            //Yeni veri id si service tarafından atanmaktadır.
            //VMIsler to StIsler
            var model = new StIsler()
            {
                BaslangicTarihi=eklenecek.BaslangicTarihi,
                BitisTarihi=eklenecek.BitisTarihi,
                Ilce= (int?)eklenecek.Ilce,
                Mahalle= (int?)eklenecek.Mahalle,
                Deger=eklenecek.Deger,
                IsTuruId = eklenecek.IsturuId,
                Deleted = eklenecek.Deleted,
                OlusturmaTarihi = DateTime.Now
            };
            try
            {
                
                return new JsonResult(_isler.YeniIsEkle(model));
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("UpdateAnIs")]
        public IActionResult IsGunceller(VMIsler guncellenecek)
        {
            var model = new StIsler()
            {
                BaslangicTarihi = guncellenecek.BaslangicTarihi,
                BitisTarihi = guncellenecek.BitisTarihi,
                Ilce = (int?)guncellenecek.Ilce,
                Mahalle = (int?)guncellenecek.Mahalle,
                Deger = guncellenecek.Deger,
                IsTuruId = _isTurleri.TekIsTuruGetir( guncellenecek.IsturuId).Id,
                Deleted = guncellenecek.Deleted,
                OlusturmaTarihi = DateTime.Now
            };
            try
            {
                _isler.IsGuncelle(model);
                return new ABBJsonResponse("IslerController Stratejik İş Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("DeleteAnIs")]
        public IActionResult IsSil(VMIsler silinecek)
        {
            StIsler model = _isler.Getir(isturu => isturu.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _isler.IsGuncelle(model);
                return new ABBJsonResponse("IslerController Stratejik İş Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }
        [HttpGet("GetListOfStrateji")]
        public JsonResult StratejiBilgileriGetir([FromQuery(Name = "Birimler")]  int[] BirimId)
        {
            //faaliyet türleri
            List<VMFaaliyetTurleri> vmfaaliyetturleri = new List<VMFaaliyetTurleri>();
            List<VMAmaclar> vMAmaclars = new List<VMAmaclar>();
            List<VMHedefler> vMHedeflers = new List<VMHedefler>();
            List<VMBirimler> vmBirimlers = new List<VMBirimler>();
            List<VMPerformanslar> vmperformanslar = new List<VMPerformanslar>();
            List<VMIsturleri> denemevm = new List<VMIsturleri>();


            //faaliyetler
            List<VMFaaliyet> vmfaaliyetler = new List<VMFaaliyet>();

            //İşler
            List<VMIsler> vmisler = new List<VMIsler>();
            foreach(int birim in BirimId)
            {

                //Strateji Bilgilerini Birimine göre tek tek çekerek vm ile eşleştiriyoruz.
                BrBirimler stbirim = _birimler.TekBirimGetir(birim);
                VMBirimler birimi = new VMBirimler()
                {
                    Adi = stbirim.Adi,
                    Deleted = (bool?)stbirim.Deleted,
                    id = stbirim.Id,
                    BirimTipiId = (int?)stbirim.BirimTipiId,
                    OlusturmaTarihi = stbirim.OlustumraTarihi,
                    UstBirimId = (int?)stbirim.UstBirimId,
                    BirimTipiAdi= stbirim.BirimTipi.BirimTipi,
                };
                vmBirimlers.Add(birimi);
                List<VMFaaliyetTurleri> denemefaaliyet = _faaliyetturleriservices.StratejiBilgileriHesapla(birim);
                vmfaaliyetturleri = denemefaaliyet;

                foreach (VMFaaliyetTurleri faaliyetimsi in denemefaaliyet)
                {

                    //Faaliyet işlemleri
                    List<StFaaliyet> stfaaliyet = _faaliyetservices.FaaliyetListele(faaliyet => faaliyet.FaaliyetlerId == faaliyetimsi.id);

                    foreach (StFaaliyet faaliyet in stfaaliyet)
                    {
                        VMFaaliyet vmfaal = new VMFaaliyet()
                        {
                            Deger = faaliyet.Deger,
                            Deleted = (bool)faaliyet.Deleted,
                            FaaliyetlerId = faaliyet.FaaliyetlerId,
                            id = faaliyet.Id,
                            OlusturmaTarihi = faaliyet.OlusturmaTarihi
                        };
                        vmfaaliyetler.Add(vmfaal);
                    }

                }

                foreach (VMIsturleri isturu in _isTurleri.StratejiBilgileriHesapla(birim))
                {
                    denemevm.Add(isturu);
                    //FaaliyetTurleri işlemleri
                    StFaaliyetler stfaaliyetturleri = _faaliyetturleriservices.Getir(faaliyetturu => faaliyetturu.IsTuruId == isturu.id);
                    List<StIsler> stisler = _isler.IsleriListele(isler => isler.IsTuruId == isturu.id);

                    foreach (StIsler stis in stisler)
                    {
                        VMIsler isgibi = new VMIsler()
                        {
                            BaslangicTarihi = stis.BaslangicTarihi,
                            BitisTarihi = stis.BitisTarihi,
                            Deger = stis.Deger,
                            Deleted = (bool)stis.Deleted,
                            id = stis.Id,
                            Ilce = (AKYSTRATEJI.enums.Ilceler)stis.Ilce,
                            IsturuId = stis.IsTuruId,
                            Mahalle = (AKYSTRATEJI.enums.Mahalleler)stis.Mahalle
                        };
                        vmisler.Add(isgibi);

                    }

                    


                    //Performans işlemleri
                    StPerformanslar performanslar = _performanslarservices.TekPerformansGetir(isturu.PerformansId);

                    VMPerformanslar vmperformans = new VMPerformanslar()
                    {
                        Adi = performanslar.Adi,
                        Deleted = (bool)performanslar.Deleted,
                        HedeflerId = performanslar.HedeflerId,
                        id = performanslar.Id,
                        OlusturmaTarihi = performanslar.OlusturmaTarihi,
                        HedefAdi = performanslar.Hedefler.Tanim,
                        AmaclarId = performanslar.Hedefler.AmaclarId,
                        AmacAdi = performanslar.Hedefler.Amaclar.Adi
                    };

                    //Eğer performans listede var ise eklemiyor
                    if (!vmperformanslar.Any(item=>item.id== vmperformans.id && item.Adi==vmperformans.Adi))
                    {
                        vmperformanslar.Add(vmperformans);
                    }

                    StHedefler hedefler = _hedefler.TekHedefGetir(performanslar.HedeflerId, obj => obj.Amaclar);
                    VMHedefler vmhedefler = new VMHedefler()
                    {
                        AmaclarId = hedefler.Amaclar.AmacId,
                        Deleted = (bool)hedefler.Deleted,
                        id = hedefler.Id,
                        OlusturmaTarihi = hedefler.OlusturmaTarihi,
                        Tanim = hedefler.Tanim
                    };
                    if (!vMHedeflers.Any(item => item.id == vmhedefler.id && item.Tanim == vmhedefler.Tanim))
                    {
                        vMHedeflers.Add(vmhedefler);
                    }
                    VMAmaclar vmamaclar = new VMAmaclar()
                    {
                        Adi = hedefler.Amaclar.Adi,
                        Deleted = (bool)hedefler.Amaclar.Deleted,
                        id = hedefler.Amaclar.Id,
                        OlusturmaTarihi = hedefler.Amaclar.OlusturmaTarihi
                    };
                    if (!vMAmaclars.Any(item => item.id == vmamaclar.id && item.Adi == vmamaclar.Adi))
                    {
                        vMAmaclars.Add(vmamaclar);
                    }
                }
            }


            StratejiBilgileri Stratejibilgileri = new StratejiBilgileri() {Hedefler=vMHedeflers,StratejikAmac=vMAmaclars, YetkiliBirimler = vmBirimlers,Isturleri= denemevm, Performanslar= vmperformanslar,Faaliyetler= vmfaaliyetler,VMFaaliyetTurleri= vmfaaliyetturleri,Isler= vmisler};
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı            

            return new JsonResult(Stratejibilgileri);
        }



    }
}
