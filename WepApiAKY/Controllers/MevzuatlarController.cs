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

            var model = new VMMevzuatlar()
            {
                id = mevzuat.Id,
                Deleted = (bool)mevzuat.Deleted,
                Adi = mevzuat.Adi,
                BirimId = mevzuat.BirimId,
                Yonetmelik= mevzuat.Yonetmelik,
                OlusturmaTarihi = mevzuat.OlusturmaTarihi

            };

            return new JsonResult(model);
        }
        [HttpGet("GetListofMevzuatlar")]
        public JsonResult MevzuatlariListele()
        {
            //Veritabanından BrMevzuatlar tablosunun listesini almaişlemi.
            List<BrMevzuatlar> mevzuatlar = _mevzuatlarServices.MevzuatlariListele();
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
                OlusturmaTarihi = eklenecek.OlusturmaTarihi
            };
            try
            {
                _mevzuatlarServices.Ekle(model);
                return new ABBJsonResponse("MevzuatlarController/ Araç Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("UpdateaMevzuat")]
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
                _mevzuatlarServices.Guncelle(model);
                return new ABBJsonResponse("MevzuatlarController/ Araç Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("DeleteaMevzuat")]
        public IActionResult MevzuatSil(VMMevzuatlar silinecek)
        {
            BrMevzuatlar model = _mevzuatlarServices.Getir(mevzuat => mevzuat.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _mevzuatlarServices.Guncelle(model);
                return new ABBJsonResponse("MevzuatlarController/ Araç Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }

    }
}
