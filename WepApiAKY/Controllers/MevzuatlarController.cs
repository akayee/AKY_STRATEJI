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
    public class MevzuatlarController:ControllerBase
    {
        private readonly ILogger<MevzuatlarController> _logger;
        //Mevzuatlar  İşlemlerinin yapıldığı Servis
        private readonly IMervzuatlarServices _mevzuatlarServices;

        public MevzuatlarController(ILogger<MevzuatlarController> logger, IMervzuatlarServices mevzuatlarServices)
        {
            _logger = logger;
            _mevzuatlarServices = mevzuatlarServices;
        }
        [HttpGet("GetaMevzuat")]
        public JsonResult MevzuatGetir(int id)
        {
            //Tek Mevzuat getirme.

            BrMevzuatlar mevzuat = _mevzuatlarServices.TekmevzuatGetir(id);


            if (!(mevzuat is null))
            {

                var model = new VMMevzuatlar()
                {
                    id = mevzuat.Id,
                    Deleted = (bool)mevzuat.Deleted,
                    Adi = mevzuat.Adi,
                    BirimId = mevzuat.BirimId,
                    Yonetmelik = mevzuat.Yonetmelik,
                    OlusturmaTarihi = mevzuat.OlusturmaTarihi

                };

                return new JsonResult(model);
            }
            else
            {

                return new JsonResult("Veri Bulunmuyor");
            }
        }
        [HttpGet("GetListofMevzuatlar")]
        public JsonResult MevzuatlariListele(int BirimId)
        {
            //Veritabanından BrMevzuatlar tablosunun listesini almaişlemi.
            List<BrMevzuatlar> mevzuatlar = _mevzuatlarServices.MevzuatlariListele(obj=> obj.BirimId== BirimId && obj.Deleted!=true);
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMMevzuatlar> vmListe = new List<VMMevzuatlar>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (BrMevzuatlar mevzuat in mevzuatlar)
            {

                vmListe.Add(new VMMevzuatlar()
                {
                    id = mevzuat.Id,
                    Deleted = (bool)mevzuat.Deleted,
                    Adi = mevzuat.Adi,
                    BirimId = mevzuat.BirimId,
                    Yonetmelik = mevzuat.Yonetmelik,
                    OlusturmaTarihi = mevzuat.OlusturmaTarihi
                });
            }
            return new JsonResult(vmListe);
        }
        [HttpPost("AddNewMevzuat")]
        public IActionResult YeniMevzuatEkle(VMMevzuatlar eklenecek)
        {
            //Yeni veri id si service tarafından atanmaktadır.
            //VMMevzuatlar to BrMevzuatlar
            var model = new BrMevzuatlar()
            {
                Id = eklenecek.id,
                Deleted = (bool)eklenecek.Deleted,
                Adi = eklenecek.Adi,
                BirimId = eklenecek.BirimId,
                Yonetmelik = eklenecek.Yonetmelik,
                OlusturmaTarihi = DateTime.Now
            };
            try
            {
                return new JsonResult(_mevzuatlarServices.YeniMevzuatEkle(model));
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("UpdateaMevzuat")]
        public IActionResult MevzuatGuncelle(VMMevzuatlar guncellenecek)
        {
            var model = new BrMevzuatlar()
            {
                Id = guncellenecek.id,
                Deleted = (bool)guncellenecek.Deleted,
                Adi = guncellenecek.Adi,
                BirimId = guncellenecek.BirimId,
                Yonetmelik = guncellenecek.Yonetmelik,
                OlusturmaTarihi = guncellenecek.OlusturmaTarihi
            };
            try
            {
                return new JsonResult(_mevzuatlarServices.TekmEvzuatGuncelle(model));
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("DeleteaMevzuat")]
        public IActionResult MevzuatSil(VMMevzuatlar silinecek)
        {
            BrMevzuatlar model = _mevzuatlarServices.Getir(mevzuat => mevzuat.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                return new JsonResult(_mevzuatlarServices.TekmEvzuatGuncelle(model));
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }

    }
}
