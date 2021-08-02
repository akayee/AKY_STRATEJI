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
    public class FizikselYapilarController:ControllerBase
    {
        private readonly ILogger<FizikselYapilarController> _logger;
        //Fiziksel Yapı İşlemlerinin yapıldığı Servis
        private readonly IFizikselYapilarServices _fizikselYapilarServices;

        public FizikselYapilarController(ILogger<FizikselYapilarController> logger, IFizikselYapilarServices fizikselYapilarServices)
        {
            _logger = logger;
           _fizikselYapilarServices = fizikselYapilarServices;
        }

        [HttpGet("GetFizikselYapi")]
        public JsonResult FizikselYapiGetir(int id)
        {
            //Tek Arac getirme.

            BrFizikselYapilar fizikselyapi = _fizikselYapilarServices.TekFizikselYapiGetir(id);

            if (!(fizikselyapi is null))
            {


                var model = new VMFizikselYapilar()
                {
                    id = fizikselyapi.Id,
                    Deleted = (bool)fizikselyapi.Deleted,
                    Adi = fizikselyapi.Adi,
                    BirimId = fizikselyapi.BirimId,
                    Konum = fizikselyapi.Konum,
                    MetreKare = fizikselyapi.MetreKare,
                    OlusturmaTarihi = fizikselyapi.OlusturmaTarihi

                };

                return new JsonResult(model);
            }
            else
            {

                return new JsonResult("Veri Bulunmuyor");
            }
        }
        [HttpGet("GetListofBirimTipleri")]
        public JsonResult FizikselYapilariListele()
        {
            //Veritabanından BrDonanimlar tablosunun listesini almaişlemi.
            List<BrFizikselYapilar> fizikselYapilars = _fizikselYapilarServices.FizikselYapilariListele();
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMFizikselYapilar> vmListe = new List<VMFizikselYapilar>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (BrFizikselYapilar fizikselyapi in fizikselYapilars)
            {

                vmListe.Add(new VMFizikselYapilar()
                {
                    id = fizikselyapi.Id,
                    Deleted = (bool)fizikselyapi.Deleted,
                    Adi = fizikselyapi.Adi,
                    BirimId = fizikselyapi.BirimId,
                    Konum = fizikselyapi.Konum,
                    MetreKare = fizikselyapi.MetreKare,
                    OlusturmaTarihi = fizikselyapi.OlusturmaTarihi
                });
            }
            return new JsonResult(vmListe);
        }
        [HttpPost("AddNewaFizikselYapi")]
        public IActionResult YeniFizikselYapiEkle(VMFizikselYapilar eklenecek)
        {
            //Yeni veri id si service tarafından atanmaktadır.
            //VMFizikselYapilar to BrBirimtipleri
            var model = new BrFizikselYapilar()
            {
                Id = eklenecek.id,
                Deleted = (bool)eklenecek.Deleted,
                Adi = eklenecek.Adi,
                BirimId = eklenecek.BirimId,
                Konum = eklenecek.Konum,
                MetreKare = eklenecek.MetreKare,
                OlusturmaTarihi = DateTime.Now
            };
            try
            {
                _fizikselYapilarServices.YeniFizikselYapiEkle(model);
                return new ABBJsonResponse("FizikselYapilarController/ Araç Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("UpdateaFizikselYapi")]
        public IActionResult FizikselYapiGuncelle(VMFizikselYapilar guncellenecek)
        {
            var model = new BrFizikselYapilar()
            {
                Id = guncellenecek.id,
                Deleted = (bool)guncellenecek.Deleted,
                Adi = guncellenecek.Adi,
                BirimId = guncellenecek.BirimId,
                Konum = guncellenecek.Konum,
                MetreKare = guncellenecek.MetreKare,
                OlusturmaTarihi = guncellenecek.OlusturmaTarihi
            };
            try
            {
                _fizikselYapilarServices.TekFizikselYapiGuncelle(model);
                return new ABBJsonResponse("FizikselYapilarController/ Araç Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("DeleteaFizikselYapi")]
        public IActionResult FizikselYapiSil(VMFizikselYapilar silinecek)
        {
            BrFizikselYapilar model = _fizikselYapilarServices.Getir(fizikselyapi => fizikselyapi.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _fizikselYapilarServices.TekFizikselYapiGuncelle(model);
                return new ABBJsonResponse("FizikselYapilarController/ Araç Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }
    }
}
