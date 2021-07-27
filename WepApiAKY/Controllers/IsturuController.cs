using ABB.WebMvcUI.Models;
using AKYSTRATEJI.Model;
using AKYSTRATEJI.ViewModals;
using BL.Abstract;
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
    public class IsturuController : ControllerBase
    {
        private readonly ILogger<IsturuController> _logger;
        //Stratejik Isler işlemlerini yaptığımız servis
        private readonly IIsturleriServices _isturleri;
        private readonly IPerformanslarServices _performanslar;
        public IsturuController(ILogger<IsturuController> logger, IIsturleriServices isturleri, IPerformanslarServices performanslar)
        {
            _logger = logger;
            _isturleri = isturleri;
            _performanslar = performanslar;
        }

        [HttpGet("GetIsTuru")]
        public JsonResult GetIsturu(int id)
        {
            //Tek Isturu getirme.

            StIsturleri stIsturleri = _isturleri.TekIsTuruGetir(id);
            //Isturunun bağlı olduğu performans getirme.
            StPerformanslar isturuPerformansi = stIsturleri.Performans;
            VMPerformanslar vmperformans = new VMPerformanslar()
            {
                Adi = isturuPerformansi.Adi,
                id = isturuPerformansi.Id,
                Deleted = (bool)isturuPerformansi.Deleted
            };
            //ViewModal Mapleme işlemi.
            var model = new VMIsturleri()
            {
                id = stIsturleri.Id,
                Adi = stIsturleri.Adi,
                OlusturmaTarihi = stIsturleri.OlusturmaTarihi,
                Deleted = (bool)stIsturleri.Deleted,
                PerformansId = stIsturleri.PerformansId,
                Performans = vmperformans,
                FaaliyetId= (int)stIsturleri.FaaliyetId

            };

            return new JsonResult(model);
        }
        [HttpGet("GetListofIsturleri")]
        public JsonResult PerformansListele()
        {
            //Veritabanından StIsturleri tablosunun listesini almaişlemi.
            List<StIsturleri> isTurleri = _isturleri.IsTuruListele();
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMIsturleri> vmListe = new List<VMIsturleri>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (StIsturleri isturu in isTurleri)
            {
                StPerformanslar isturuPerformansi = _performanslar.Getir(performans => performans.Id == isturu.PerformansId);
                VMPerformanslar vmperformans = new VMPerformanslar()
                {
                    Adi = isturuPerformansi.Adi,
                    id = isturuPerformansi.Id,
                    Deleted = (bool)isturuPerformansi.Deleted
                };
                vmListe.Add(new VMIsturleri()
                {
                    id = isturu.Id,
                    Adi = isturu.Adi,
                    PerformansId = isturu.PerformansId,
                    Performans = vmperformans,
                    Deleted = (bool)isturu.Deleted,
                    OlusturmaTarihi = isturu.OlusturmaTarihi,
                    FaaliyetId= (int)isturu.FaaliyetId
                });
            }

            return new JsonResult(vmListe);
        }
        [HttpPost("AddNewIsTuru")]
        public IActionResult YeniIsTuruEkle(VMIsturleri eklenecek)
        {

            //Yeni veri id si service tarafından atanmaktadır.
            //VMIsturleri to StIsturleri
            var model = new StIsturleri()
            {
                Adi = eklenecek.Adi,
                Aciklama = eklenecek.Aciklama,
                YillikHedefId = eklenecek.YillikHedefId,
                PerformansId = eklenecek.PerformansId,
                Deleted = eklenecek.Deleted,
                Maaliyet = eklenecek.Maaliyet,
                OlusturmaTarihi = DateTime.Now,
                FaaliyetId=eklenecek.FaaliyetId
                
            };
            try
            {
                _isturleri.Ekle(model);
                return new ABBJsonResponse("Stratejik Isturu Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("UpdateAnIsTuru")]
        public IActionResult IsturuGunceller(VMIsturleri guncellenecek)
        {
            var model = new StIsturleri()
            {
                Adi = guncellenecek.Adi,
                Aciklama = guncellenecek.Aciklama,
                YillikHedefId = guncellenecek.YillikHedefId,
                PerformansId = guncellenecek.PerformansId,
                Deleted = guncellenecek.Deleted,
                Maaliyet = guncellenecek.Maaliyet,
                OlusturmaTarihi = guncellenecek.OlusturmaTarihi,
                BirimId=guncellenecek.BirimId,
                FaaliyetId = guncellenecek.FaaliyetId
            };
            try
            {
                _isturleri.Guncelle(model);
                return new ABBJsonResponse("Stratejik Isturu Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("DeleteAnIsTuru")]
        public IActionResult IsturuSil(VMIsturleri silinecek)
        {
            StIsturleri model =_isturleri.Getir(isturu => isturu.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _isturleri.Guncelle(model);
                return new ABBJsonResponse("Stratejik Isturu Başarıyla Silindi");
            }
            catch(Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }


    }
}
