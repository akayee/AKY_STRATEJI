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
    public class YetkiGorevTanimlariController:ControllerBase
    {
        private readonly ILogger<YetkiGorevTanimlariController> _logger;
        //Yazilim  İşlemlerinin yapıldığı Servis
        private readonly IYetkiGorevTanimlariServices _yetkiGorev;

        public YetkiGorevTanimlariController(ILogger<YetkiGorevTanimlariController> logger, IYetkiGorevTanimlariServices yetkiGorev)
        {
            _logger = logger;
            _yetkiGorev = yetkiGorev;
        }
        [HttpGet]
        public JsonResult YetkiGorevGetir(int id)
        {
            //Tek YetkiGorevTanim getirme.

            BrYetkiGorevTanimlari yetkiGorevTanim = _yetkiGorev.TekYetkiGorevTanimGetir(id);

            var model = new VMYetkiGorevTanimlari()
            {
                id = yetkiGorevTanim.Id,
                Deleted = (bool)yetkiGorevTanim.Deleted,
                Adi = yetkiGorevTanim.Adi,
                BirimId = yetkiGorevTanim.BirimId,
                OlusturmaTarihi = yetkiGorevTanim.OlusturmaTarihi,
                Kanun=yetkiGorevTanim.Kanun
            };
            return new JsonResult(model);
        }
        [HttpGet("GetListofYetkiGorevTanimlar")]
        public JsonResult yetkiGorevleriListele()
        {
            //Veritabanından BrYetkiGorevTanimlar tablosunun listesini almaişlemi.
            List<BrYetkiGorevTanimlari> yetkiGorevTanim = _yetkiGorev.YetkiGorevTanimlariListele();
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMYetkiGorevTanimlari> vmListe = new List<VMYetkiGorevTanimlari>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (BrYetkiGorevTanimlari yetkigorev in yetkiGorevTanim)
            {

                vmListe.Add(new VMYetkiGorevTanimlari()
                {
                    id = yetkigorev.Id,
                    Deleted = (bool)yetkigorev.Deleted,
                    Adi = yetkigorev.Adi,
                    BirimId = yetkigorev.BirimId,
                    OlusturmaTarihi = yetkigorev.OlusturmaTarihi,
                    Kanun=yetkigorev.Kanun
                });
            }
            return new JsonResult(vmListe);
        }
        [HttpPost]
        public IActionResult YeniYetkiGorevEkle(VMYetkiGorevTanimlari eklenecek)
        {
            //Yeni veri id si service tarafından atanmaktadır.
            //VMYetkiGorevTanimlari to BrYetkiGorevTanimlari
            var model = new BrYetkiGorevTanimlari()
            {
                Id = eklenecek.id,
                Deleted = (bool)eklenecek.Deleted,
                Adi = eklenecek.Adi,
                BirimId = eklenecek.BirimId,
                OlusturmaTarihi = eklenecek.OlusturmaTarihi,
                Kanun=eklenecek.Kanun,
                YetkiGorevId=eklenecek.id
            };
            try
            {
                _yetkiGorev.Ekle(model);
                return new ABBJsonResponse("YetkiGorevTanimlariController/ Kayıt Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut]
        public IActionResult YetkiGorevGuncelle(VMYetkiGorevTanimlari guncellenecek)
        {
            var model = new BrYetkiGorevTanimlari()
            {
                Id = guncellenecek.id,
                Deleted = (bool)guncellenecek.Deleted,
                Adi = guncellenecek.Adi,
                BirimId = guncellenecek.BirimId,
                OlusturmaTarihi = guncellenecek.OlusturmaTarihi,
                Kanun=guncellenecek.Kanun,
                YetkiGorevId=guncellenecek.id
            };
            try
            {
                _yetkiGorev.Guncelle(model);
                return new ABBJsonResponse("YetkiGorevTanimlariController/ Araç Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("Delete")]
        public IActionResult YetkiGorevSil(VMYetkiGorevTanimlari silinecek)
        {
            BrYetkiGorevTanimlari model = _yetkiGorev.Getir(yetkigorev => yetkigorev.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _yetkiGorev.Guncelle(model);
                return new ABBJsonResponse("YetkiGorevTanimlariController/ Araç Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }
    }
}
