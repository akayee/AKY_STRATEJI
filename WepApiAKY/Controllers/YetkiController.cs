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
    public class YetkiController : ControllerBase
    {
        private readonly ILogger<YetkiController> _logger;
        private readonly IYetkilerServices _yetkiservices;

        public YetkiController(ILogger<YetkiController> logger, IYetkilerServices yetkiservices)
        {
            _logger = logger;
            _yetkiservices = yetkiservices;
        }
        [HttpGet("YetkiGetir")]
        public JsonResult YetkiGetir(int id)
        {
            //Tek Yetki getirme.
            YtYetkiler getirelecekveri = _yetkiservices.TekYetkiGetir(id);


            if (!(getirelecekveri is null))
            {
                var model = new VMYetkiler()
                {
                    id = getirelecekveri.Id,
                    Deleted = (bool)getirelecekveri.Deleted,
                    Adi = getirelecekveri.Adi,
                    Yetki = getirelecekveri.Yetki
                };
                return new JsonResult(model);
            }
            else
            {

                return new JsonResult("Veri Bulunmuyor");
            }
        }
        [HttpGet("GetListofYetkiler")]
        public JsonResult KullanicilariListele()
        {
            //Veritabanından Kullanicilar tablosunun listesini almaişlemi.
            List<YtYetkiler> list = _yetkiservices.YetkileriListele();
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMYetkiler> vmListe = new List<VMYetkiler>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (YtYetkiler listmember in list)
            {

                vmListe.Add(new VMYetkiler()
                {
                    id = listmember.Id,
                    Deleted = (bool)listmember.Deleted,
                    Adi=listmember.Adi,
                    Yetki=listmember.Yetki
                });
            }
            return new JsonResult(vmListe);
        }
        [HttpPost("YeniYetkiEkle")]
        public IActionResult YeniYetkiEkle(VMYetkiler eklenecek)
        {
            //Yeni veri id si service tarafından atanmaktadır.
            //VMYetkiler to YtYetkiler
            var model = new YtYetkiler()
            {
                Id = eklenecek.id,
                Deleted = (bool)eklenecek.Deleted,
                Adi=eklenecek.Adi,
                Yetki=eklenecek.Yetki,
                YetkilerId=eklenecek.id
            };
            try
            {
                _yetkiservices.YeniYetkiEkle(model);
                return new ABBJsonResponse("YetkiController/ Kayıt Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("YetkiGuncelle")]
        public IActionResult YetkiGuncelle(VMYetkiler guncellenecek)
        {
            var model = new YtYetkiler()
            {
                Id = guncellenecek.id,
                Deleted = (bool)guncellenecek.Deleted,
                Adi = guncellenecek.Adi,
                Yetki = guncellenecek.Yetki,
                YetkilerId = guncellenecek.id
            };
            try
            {
                _yetkiservices.TekYetkiGuncelle(model);
                return new ABBJsonResponse("YetkiController/ Araç Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("YetkiSil")]
        public IActionResult YetkiSil(VMYetkiler silinecek)
        {
            YtYetkiler model = _yetkiservices.Getir(yetki => yetki.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _yetkiservices.TekYetkiGuncelle(model);
                return new ABBJsonResponse("YetkiController/ Araç Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }
    }
}
