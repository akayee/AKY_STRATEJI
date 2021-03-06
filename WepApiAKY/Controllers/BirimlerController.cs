using ABB.WebMvcUI.Models;
using AKYSTRATEJI.Model;
using AKYSTRATEJI.ViewModals;
using BL.Abstract;
using Microsoft.AspNetCore.Cors;
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
                    UstBirimId = (int)birim.UstBirimId,
                    BirimTipiId=birim.BirimTipiId,
                    BirimTipiAdi=birim.BirimTipi.BirimTipi
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
            List<BrBirimler> birimler = _birim.BirimlerListele(birim=> birim.Deleted!=true);
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
                    OlusturmaTarihi = birim.OlustumraTarihi,
                    UstBirimId = birim.UstBirimId,
                    BirimTipiId=birim.BirimTipiId,
                    BirimTipiAdi=birim.BirimTipi.BirimTipi
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
                OlustumraTarihi = DateTime.Now,
                BirimTipiId = eklenecek.BirimTipiId,
                BirimId = eklenecek.id,
                UstBirimId = eklenecek.UstBirimId
            };
            try
            {
                int id=_birim.YeniBirimEkle(model);
                return new JsonResult(id);
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("UpdateaBirim")]
        public IActionResult BirimGuncelle(VMBirimler guncellenecek)
        {
            var model = new BrBirimler()
            {
                Adi = guncellenecek.Adi,
                Deleted = guncellenecek.Deleted,
                OlustumraTarihi = guncellenecek.OlusturmaTarihi,
                BirimId = guncellenecek.id,
                UstBirimId = (int)guncellenecek.UstBirimId,
                BirimTipiId=guncellenecek.BirimTipiId,
                Id=guncellenecek.id
            };
            try
            {
                _birim.BirimGuncelle(model);
                ABBJsonResponse response = new ABBJsonResponse("BirimlerController/ Birim Başarıyla Eklendi");
                response.StatusCode = 200;
                return response;
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("DeleteaBirim")]
        public IActionResult BirimSil(VMBirimler silinecek)
        {
            BrBirimler model = _birim.Getir(birim => birim.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _birim.BirimGuncelle(model);
                ABBJsonResponse response = new ABBJsonResponse("BirimlerController/ Birim Başarıyla Silindi");
                response.StatusCode = 200;
                return response;
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }

        [HttpGet("GetListofBirimBilgileri")]
        public JsonResult BirimBilgileriListele([FromQuery(Name = "Birimler")] int[] Birimler)
        {
            BirimBilgiler birimbilgileri = _birim.BirimBilgileriGetir(Birimler);
            return new JsonResult(birimbilgileri);
        }
    }
}
