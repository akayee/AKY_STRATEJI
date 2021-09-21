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
        [HttpGet("GetaYetkiGorevTanimi")]
        public JsonResult YetkiGorevGetir(int id)
        {
            //Tek YetkiGorevTanim getirme.

            BrYetkiGorevTanimlari yetkiGorevTanim = _yetkiGorev.TekYetkiGorevTanimGetir(id);



            if (!(yetkiGorevTanim is null))
            {

                var model = new VMYetkiGorevTanimlari()
                {
                    id = yetkiGorevTanim.Id,
                    Deleted = (bool)yetkiGorevTanim.Deleted,
                    Adi = yetkiGorevTanim.Adi,
                    BirimId = yetkiGorevTanim.BirimId,
                    OlusturmaTarihi = yetkiGorevTanim.OlusturmaTarihi,
                    Kanun = yetkiGorevTanim.Kanun
                };
                return new JsonResult(model);
            }
            else
            {

                return new JsonResult("Veri Bulunmuyor");
            }
        }
        [HttpGet("GetListofYetkiGorevTanimlar")]
        public JsonResult yetkiGorevleriListele(int BirimId)
        {
            //Veritabanından BrYetkiGorevTanimlar tablosunun listesini almaişlemi.
            List<BrYetkiGorevTanimlari> yetkiGorevTanim = _yetkiGorev.YetkiGorevTanimlariListele(y=> y.BirimId== BirimId&& y.Deleted!=true);
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
        [HttpPost("AddNewaYetkiGorevTanimi")]
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
                OlusturmaTarihi = DateTime.Now,
                Kanun=eklenecek.Kanun,
                YetkiGorevId=eklenecek.id
            };
            try
            {
                
                return new JsonResult(_yetkiGorev.YeniYetkiGorevTanimEkle(model));
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("UpdateaYetkiGorevTanimi")]
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
                
                return new JsonResult(_yetkiGorev.TekYetkiGorevTanimGuncelle(model));
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("DeleteaYetkiGorevTanimi")]
        public IActionResult YetkiGorevSil(VMYetkiGorevTanimlari silinecek)
        {
            BrYetkiGorevTanimlari model = _yetkiGorev.Getir(yetkigorev => yetkigorev.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                
                return new JsonResult(_yetkiGorev.TekYetkiGorevTanimGuncelle(model));
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }
    }
}
