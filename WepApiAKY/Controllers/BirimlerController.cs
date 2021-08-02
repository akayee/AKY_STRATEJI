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
    public class BirimlerController : ControllerBase
    {
        private readonly ILogger<BirimlerController> _logger;
        //Araclar İşlemlerinin yapıldığı Servis
        private readonly IBirimServis _birim;
        public BirimlerController(ILogger<BirimlerController> logger,IBirimServis birim)
        {
            _logger = logger;
            _birim = birim;
        }
        [HttpGet("GetaBirim")]
        public JsonResult GetBirim(int id)
        {
            //Tek Birim getirme.
            BrBirimler birim = _birim.TekBirimGetir(id);
            if (!(birim is null))
            {
                var model = new VMBirimler()
                {
                    id = birim.Id,
                    Adi = birim.Adi,
                    OlusturmaTarihi = birim.OlustumraTarihi,
                    Deleted = (bool)birim.Deleted,
                    UstBirimId = (int)birim.UstBirimId
                };

                return new JsonResult(model);
            }
            else
            {

                return new JsonResult("Veri Bulunmuyor");
            }           
           
        }

        [HttpGet("GetListofBirimler")]
        public JsonResult BirimleriListele()
        {
            //Veritabanından BrBirimler tablosunun listesini almaişlemi.
            List<BrBirimler> birimler = _birim.BirimlerListele();
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMBirimler> vmListe = new List<VMBirimler>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (BrBirimler birim in birimler)
            {
               
                vmListe.Add(new VMBirimler()
                {
                    id = birim.Id,
                    Adi = birim.Adi,
                    Deleted = (bool)birim.Deleted,
                    OlusturmaTarihi = DateTime.Now,
                    UstBirimId = (int?)birim.UstBirimId
                });
            }
            return new JsonResult(vmListe);
        }
        [HttpPost("AddNewBirim")]
        public IActionResult YeniBirimEkle(VMBirimler eklenecek)
        {

            //Yeni veri id si service tarafından atanmaktadır.
            //VMAraclar to BrAraclar
            var model = new BrBirimler()
            {
                Adi = eklenecek.Adi,
                Deleted = (bool)eklenecek.Deleted,
                OlustumraTarihi = eklenecek.OlusturmaTarihi,
                BirimId = eklenecek.id,
                UstBirimId = (int)eklenecek.UstBirimId
            };
            try
            {
                _birim.YeniBirimEkle(model);
                return new ABBJsonResponse("BirimlerController/ Birim Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("UpdateaBirim")]
        public IActionResult BirimGuncelle(VMBirimler guncellenecek)
        {
            var model = new BrBirimler()
            {
                Adi = guncellenecek.Adi,
                Deleted = guncellenecek.Deleted,
                OlustumraTarihi = guncellenecek.OlusturmaTarihi,
                BirimId = guncellenecek.id,
                UstBirimId = (int)guncellenecek.UstBirimId
                //-WRN- //VMAraclar eklenecek
                //-WRN- //VMDonanimlar eklenecek
                //-WRN- //VMMevzuatlar eklenecek
                //-WRN- //VMPersoneller eklenecek
                //-WRN- //VMYazilimlar eklenecek
                //-WRN- //VMYetkiGorevTanimlari eklenecek
                //-WRN- //VMFaaliyetTurleri eklenecek
                //-WRN- //VMKullanicilar eklenecek
                //-WRN- //VMMaliFaaliyetTurleri eklenecek
                //-WRN- //VMIsturleri eklenecek
            };
            try
            {
                _birim.BirimGuncelle(model);
                return new ABBJsonResponse("BirimlerController/ Birim Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("DeleteaBirim")]
        public IActionResult BirimSil(VMBirimler silinecek)
        {
            BrBirimler model = _birim.Getir(birim => birim.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _birim.BirimGuncelle(model);
                return new ABBJsonResponse("BirimlerController/ Birim Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }
    }
}
