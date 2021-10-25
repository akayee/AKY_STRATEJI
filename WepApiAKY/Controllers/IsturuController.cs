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
        public IsturuController(ILogger<IsturuController> logger, IIsturleriServices isturleri)
        {
            _logger = logger;
            _isturleri = isturleri;
        }

        [HttpGet("GetIsTuru")]
        public JsonResult GetIsturu(int id)
        {
            //Tek Isturu getirme.

            StIsturleri stIsturleri = _isturleri.TekIsTuruGetir(id);
            //Isturunun bağlı olduğu performans getirme.

            if (!(stIsturleri is null))
            {
                //ViewModal Mapleme işlemi.
                var model = new VMIsturleri()
                {
                    id = stIsturleri.Id,
                    Adi = stIsturleri.Adi,
                    OlusturmaTarihi = stIsturleri.OlusturmaTarihi,
                    Deleted = (bool)stIsturleri.Deleted,
                    OlcuBirimiId = stIsturleri.OlcuBirimi,
                    PerformansId = stIsturleri.PerformansId,
                    IsturleriId=stIsturleri.IsTurleriId

                };

                return new JsonResult(model);
            }
            else
            {

                return new JsonResult("Veri Bulunmuyor");
            }            
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
              
                vmListe.Add(new VMIsturleri()
                {
                    id = isturu.Id,
                    Adi = isturu.Adi,
                    PerformansId = isturu.PerformansId,
                    Deleted = (bool)isturu.Deleted,
                    OlcuBirimiId=isturu.OlcuBirimi,
                    OlusturmaTarihi = isturu.OlusturmaTarihi,
                    IsturleriId=isturu.IsTurleriId
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
                PerformansId = eklenecek.PerformansId,
                Deleted = eklenecek.Deleted,
                Maaliyet = eklenecek.Maaliyet,
                OlcuBirimi=eklenecek.OlcuBirimiId,
                OlusturmaTarihi = DateTime.Now
                
            };
            try
            {
                
                return new JsonResult(_isturleri.YeniIsTuruEkle(model));
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
                PerformansId = guncellenecek.PerformansId,
                Deleted = guncellenecek.Deleted,
                Maaliyet = guncellenecek.Maaliyet,
                OlcuBirimi=guncellenecek.OlcuBirimiId,
                OlusturmaTarihi = guncellenecek.OlusturmaTarihi,
                BirimId=guncellenecek.BirimId,
                IsTurleriId=guncellenecek.IsturleriId
            };
            try
            {
                _isturleri.IsTuruGuncelle(model);
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
                _isturleri.IsTuruGuncelle(model);
                return new ABBJsonResponse("Stratejik Isturu Başarıyla Silindi");
            }
            catch(Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }


    }
}
