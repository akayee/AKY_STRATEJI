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
    public class YazilimlarController:ControllerBase
    {
        private readonly ILogger<YazilimlarController> _logger;
        //Yazilim  İşlemlerinin yapıldığı Servis
        private readonly IYazilimlarServices _yazilim;

        public YazilimlarController(ILogger<YazilimlarController> logger, IYazilimlarServices yazilim)
        {
            _logger = logger;
            _yazilim = yazilim;
        }
        [HttpGet("GetaYazilim")]
        public JsonResult YazilimGetir(int id)
        {
            //Tek Yazilim getirme.

            BrYazilimlar yazilim = _yazilim.TekYazilimGetir(id);


            if (!(yazilim is null))
            {
                var model = new VMYazilimlar()
                {
                    id = yazilim.Id,
                    Deleted = (bool)yazilim.Deleted,
                    Adi = yazilim.Adi,
                    BirimId = yazilim.BirimId,
                    OlusturmaTarihi = yazilim.OlusturmaTarihi

                };
                return new JsonResult(model);
            }
            else
            {

                return new JsonResult("Veri Bulunmuyor");
            }
        }
        [HttpGet("GetListofYazilimlar")]
        public JsonResult YazilimlariListele(int BirimId)
        {
            //Veritabanından BrYazilimlar tablosunun listesini almaişlemi.
            List<BrYazilimlar> yazilimlar = _yazilim.YaizimlariListele(obj => obj.BirimId == BirimId && obj.Deleted != true);
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMYazilimlar> vmListe = new List<VMYazilimlar>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (BrYazilimlar yazilim in yazilimlar)
            {

                vmListe.Add(new VMYazilimlar()
                {
                    id = yazilim.Id,
                    Deleted = (bool)yazilim.Deleted,
                    Adi = yazilim.Adi,
                    BirimId = yazilim.BirimId,
                    OlusturmaTarihi = yazilim.OlusturmaTarihi
                });
            }
            return new JsonResult(vmListe);
        }
        [HttpPost("AddNewaYazilim")]
        public IActionResult YeniYazilimEkle(VMYazilimlar eklenecek)
        {
            //Yeni veri id si service tarafından atanmaktadır.
            //VMYazilimlar to BrYazilimlar
            var model = new BrYazilimlar()
            {
                Id = eklenecek.id,
                Deleted = (bool)eklenecek.Deleted,
                Adi = eklenecek.Adi,
                BirimId = eklenecek.BirimId,
                OlusturmaTarihi = DateTime.Now
            };
            try
            {
                return new JsonResult(_yazilim.YeniYazilimEkle(model));
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("UpdateaYazilim")]
        public IActionResult YazilimGuncelle(VMYazilimlar guncellenecek)
        {
            var model = new BrYazilimlar()
            {
                Id = guncellenecek.id,
                Deleted = (bool)guncellenecek.Deleted,
                Adi = guncellenecek.Adi,
                BirimId = guncellenecek.BirimId,
                OlusturmaTarihi = guncellenecek.OlusturmaTarihi
            };
            try
            {
                _yazilim.TekYazilimGuncelle(model);
                return new ABBJsonResponse("YazilimlarController/ Araç Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("DeleteaYazilim")]
        public IActionResult YazilimSil(VMYazilimlar silinecek)
        {
            BrYazilimlar model = _yazilim.Getir(yazilim => yazilim.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _yazilim.TekYazilimGuncelle(model);
                return new ABBJsonResponse("YazilimlarController/ Araç Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }
    }
}
