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
        private readonly IsService _isler;
        private readonly IIsturleriServices _isTurleri;
        private readonly IAmaclarService _amaclar;
        private readonly IHedeflerServices _hedeflerservices;
        private readonly IPerformanslarServices _performanslarservices;
        private readonly IIsturleriServices _isturleriservices;
        private readonly IFaaliyetServices _faaliyetservices;
        private readonly IFaaliyetTurleriServices _faaliyetturleriservices;
        private readonly IBirimServis _birimler;
        private readonly IBirimTipleriServices _birimtipleri;

        public IslerController(ILogger<IslerController> logger, IsService isler,IBirimTipleriServices birimTipleri, IIsturleriServices isTurleri, IAmaclarService amaclar, IHedeflerServices hedeflerservices, IPerformanslarServices performanslarservices, IIsturleriServices isturleriservices, IFaaliyetServices faaliyetservices, IFaaliyetTurleriServices faaliyetturleriservices, IBirimServis birimler)
        {
            _logger = logger;
            _isler = isler;
            _isTurleri = isTurleri;
            _amaclar = amaclar;
            _hedeflerservices = hedeflerservices;
            _performanslarservices = performanslarservices;
            _isturleriservices = isturleriservices;
            _faaliyetservices = faaliyetservices;
            _faaliyetturleriservices = faaliyetturleriservices;
            _birimler = birimler;
            _birimtipleri = birimTipleri;
        }

        [HttpGet("GetAnIs")]
        public JsonResult GetIs(int id)
        {
            //Tek Is getirme.

            StIsler stIsler = _isler.TekIsGetir(id);
            //İslere bağlı olduğu İstürü getirme.
            StIsturleri IsinIsturu = stIsler.IsTuru;
            VMIsturleri vmIsturu = new VMIsturleri()
            {
                Adi = IsinIsturu.Adi,
                id = IsinIsturu.Id,
                Deleted = (bool)IsinIsturu.Deleted
            };
            //ViewModal Mapleme işlemi.
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
        [HttpGet("GetListofIsler")]
        public JsonResult PerformansListele()
        {
            //Veritabanından StIsler tablosunun listesini almaişlemi.
            List<StIsler> Isler = _isler.IsleriListele();
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMIsler> vmListe = new List<VMIsler>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (StIsler isturu in Isler)
            {
                StIsturleri islerinIsturu = _isTurleri.Getir(performans => performans.Id == isturu.IsTuruId);
                VMIsturleri vmIsturleri = new VMIsturleri()
                {
                    Adi = islerinIsturu.Adi,
                    id = islerinIsturu.Id,
                    Deleted = (bool)islerinIsturu.Deleted
                };
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
                    Deger = isturu.Deger,
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
                _isler.Ekle(model);
                return new ABBJsonResponse("IslerController Stratejik Isler Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("UpdateAnIs")]
        public IActionResult IsGunceller(VMIsler guncellenecek)
        {
            var model = new StIsler()
            {
                BaslangicTarihi = guncellenecek.BaslangicTarihi,
                BitisTarihi = guncellenecek.BitisTarihi,
                Ilce = (int?)guncellenecek.Ilce,
                Mahalle = (int?)guncellenecek.Mahalle,
                Deger = guncellenecek.Deger,
                IsTuruId = guncellenecek.IsturuId,
                Deleted = guncellenecek.Deleted,
                OlusturmaTarihi = DateTime.Now
            };
            try
            {
                _isler.Guncelle(model);
                return new ABBJsonResponse("IslerController Stratejik İş Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("DeleteAnIs")]
        public IActionResult IsSil(VMIsler silinecek)
        {
            StIsler model = _isler.Getir(isturu => isturu.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _isler.Guncelle(model);
                return new ABBJsonResponse("IslerController Stratejik İş Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }
        [HttpGet("GetListOfStrateji")]
        public JsonResult StratejiBilgileriGetir(int BirimId)
        {
            //faaliyet türleri
            List<VMFaaliyetTurleri> vmfaaliyetturleri = new List<VMFaaliyetTurleri>();


            //faaliyetler
            List<VMFaaliyet> vmfaaliyetler = new List<VMFaaliyet>();

            //İşler
            List<VMIsler> vmisler = new List<VMIsler>();
            //Strateji Bilgilerini Birimine göre tek tek çekerek vm ile eşleştiriyoruz.
            BrBirimler stbirim = _birimler.Getir(birim => birim.Id == BirimId);
            VMBirimler birimi= new VMBirimler()
            {
                Adi=stbirim.Adi,
                Deleted= (bool)stbirim.Deleted,
                id=stbirim.Id,
                BirimTipiId= (int)stbirim.BirimTipiId
            };
            BrBirimtipleri stbirimtipleri = _birimtipleri.Getir(birimtipi => birimtipi.Id == birimi.BirimTipiId);
            VMBirimTipleri birimtipi = new VMBirimTipleri()
            {
                Id=stbirimtipleri.Id,
                Deleted=stbirimtipleri.Deleted
            };

            List<VMPerformanslar> vmperformanslar = new List<VMPerformanslar>();

            List<StIsturleri> Isturleri = _isTurleri.DetayliListe(isturu => isturu.BirimId == BirimId);
            List<VMIsturleri> VMIsturleri = new List<VMIsturleri>();
            foreach (StIsturleri isturu in Isturleri)
            {
                VMIsturleri vmsitur = new VMIsturleri()
                {
                    id = isturu.Id,
                    Aciklama = isturu.Aciklama,
                    Adi = isturu.Adi,
                    BirimId = isturu.BirimId,
                    Deleted = (bool)isturu.Deleted
                };
                //İş türü zaten varsa eklemiyor.
                if (!VMIsturleri.Contains(vmsitur))
                {
                    VMIsturleri.Add(vmsitur);
                }

                //FaaliyetTurleri işlemleri
                StFaaliyetler stfaaliyetturleri = _faaliyetturleriservices.Getir(faaliyetturu => faaliyetturu.Id == isturu.FaaliyetId);

                VMFaaliyetTurleri vmfaaliyetturu = new VMFaaliyetTurleri()
                {
                    id = stfaaliyetturleri.Id,
                    Aciklama= stfaaliyetturleri.Aciklama,
                    BirimId=stfaaliyetturleri.BirimId,
                    Deleted= (bool)stfaaliyetturleri.Deleted,
                    OlusturmaTarihi=stfaaliyetturleri.OlusturmaTarihi
                };
                vmfaaliyetturleri.Add(vmfaaliyetturu);

                //Faaliyet işlemleri
                List<StFaaliyet> stfaaliyet = _faaliyetservices.DetayliListe(faaliyet => faaliyet.FaaliyetlerId == isturu.FaaliyetId);

                foreach(StFaaliyet faaliyet in stfaaliyet)
                {
                    VMFaaliyet vmfaal = new VMFaaliyet()
                    {
                        Deger=faaliyet.Deger,
                        Deleted= (bool)faaliyet.Deleted,
                        FaaliyetlerId=faaliyet.FaaliyetlerId,
                        GelirGider=faaliyet.GelirGider,
                        id=faaliyet.Id,
                        OlusturmaTarihi=faaliyet.OlusturmaTarihi
                    };
                    vmfaaliyetler.Add(vmfaal);
                }

                //Performans işlemleri
                StPerformanslar performanslar = _performanslarservices.Getir(performans => performans.Id == isturu.PerformansId);

                VMPerformanslar vmperformans = new VMPerformanslar()
                {
                    Adi=performanslar.Adi,
                    Deleted= (bool)performanslar.Deleted,
                    HedeflerId=performanslar.HedeflerId,
                    id=performanslar.Id,
                    OlusturmaTarihi=performanslar.OlusturmaTarihi               
                };

                //Eğer performans listede var ise eklemiyor
                if(!vmperformanslar.Contains(vmperformans))
                {
                    vmperformanslar.Add(vmperformans);
                }

                //işlerin tamamını çekerek yazma
                List<StIsler> stislistesi = _isler.DetayliListe(stis => stis.Id == isturu.Id);
                foreach(StIsler stisler in stislistesi)
                {
                    VMIsler vmis = new VMIsler()
                    {
                        BaslangicTarihi = stisler.BaslangicTarihi,
                        BitisTarihi=stisler.BitisTarihi,
                        Deger=stisler.Deger,
                        Deleted= (bool)stisler.Deleted,
                        id=stisler.Id,
                        Ilce= (AKYSTRATEJI.enums.Ilceler)stisler.Ilce,
                        IsturuId=stisler.IsTuruId,
                        Mahalle= (AKYSTRATEJI.enums.Mahalleler)stisler.Mahalle,
                        OlusturmaTarihi=stisler.OlusturmaTarihi
                    };

                    vmisler.Add(vmis);
                }
            }

            //performansın hedef idsine göre hedefleri çekiyoruz.
            VMPerformanslar perfor= vmperformanslar.FirstOrDefault();
            StHedefler hedef = _hedeflerservices.Getir(hedef => hedef.Id == perfor.HedeflerId);
            VMHedefler vmhedef = new VMHedefler()
            {
                AmaclarId=hedef.AmaclarId,
                Deleted= (bool)hedef.Deleted,
                id=hedef.Id,
                Tanim=hedef.Tanim
            };

            StratejiBilgileri Stratejibilgileri = new StratejiBilgileri() { Birim = birimi , BirimTipi=birimtipi,Isturleri=VMIsturleri,Performanslar= vmperformanslar,Hedefler=vmhedef, Isler=vmisler ,Faaliyetler= vmfaaliyetler,VMFaaliyetTurleri= vmfaaliyetturleri };
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı



            

            return new JsonResult(Stratejibilgileri);
        }

    }
}
