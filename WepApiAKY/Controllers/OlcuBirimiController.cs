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
    public class OlcuBirimiController:ControllerBase
    {
        private readonly ILogger<OlcuBirimiController> _logger;
        //Ölçü Birimi  İşlemlerinin yapıldığı Servis
        private readonly IOlcuBirimiServices _olcubirimi;

        public OlcuBirimiController(ILogger<OlcuBirimiController> logger, IOlcuBirimiServices olcubirimi)
        {
            _logger = logger;
            _olcubirimi = olcubirimi;
        }
        [HttpGet("GetanOlcuBirimi")]
        public JsonResult OlcuBirimiGetir(int id)
        {
            //Tek Ölçü Birimi getirme.

            GnOlcubirimi olcuBirimi = _olcubirimi.TekOlcuBirimiGetir(id);


            if (!(olcuBirimi is null))
            {

                var model = new VMOlcuBirimi()
                {
                    id = olcuBirimi.Id,
                    Deleted = (bool)olcuBirimi.Deleted,
                    Tanim = olcuBirimi.Tanim
                };
                return new JsonResult(model);
            }
            else
            {

                return new JsonResult("Veri Bulunmuyor");
            }
        }
        [HttpGet("GetListofOlcuBirimi")]
        public JsonResult OlcuBirimleriListele()
        {
            //Veritabanından GnOlcubirimi tablosunun listesini almaişlemi.
            List<GnOlcubirimi> olcubirimleri = _olcubirimi.OlcuBirimiListele(o=>o.Deleted!=true);
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMOlcuBirimi> vmListe = new List<VMOlcuBirimi>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (GnOlcubirimi olcubirimi in olcubirimleri)
            {

                vmListe.Add(new VMOlcuBirimi()
                {
                    id = olcubirimi.Id,
                    Deleted = (bool)olcubirimi.Deleted,
                    Tanim=olcubirimi.Tanim
                });
            }
            return new JsonResult(vmListe);
        }
        [HttpPost("AddNewOlcuBirimi")]
        public IActionResult YeniOlcuBirimiEkle(VMOlcuBirimi eklenecek)
        {
            //Yeni veri id si service tarafından atanmaktadır.
            //VMOlcuBirimi to GnOlcubirimi
            var model = new GnOlcubirimi()
            {
                Id = eklenecek.id,
                Deleted = (bool)eklenecek.Deleted,
                Tanim=eklenecek.Tanim
            };
            try
            {
                int id =_olcubirimi.YeniOlcuBirimiEkle(model);
                return new JsonResult(id);
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("UpdateanOlcuBirimi")]
        public IActionResult OlcuBirimiGuncelle(VMOlcuBirimi guncellenecek)
        {
            var model = new GnOlcubirimi()
            {
                Id = guncellenecek.id,
                Deleted = (bool)guncellenecek.Deleted,
                Tanim=guncellenecek.Tanim
            };
            try
            {
                _olcubirimi.TekOlcuBirimiGuncelle(model);
                ABBJsonResponse response = new ABBJsonResponse("OlcuBirimiController/ Araç Başarıyla Silindi");
                response.StatusCode = 200;
                return response;
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("DeleteanOlcuBirimi")]
        public IActionResult OlcuBirimiSil(VMOlcuBirimi silinecek)
        {
            GnOlcubirimi model = _olcubirimi.Getir(olcubirimi => olcubirimi.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _olcubirimi.TekOlcuBirimiGuncelle(model);
                ABBJsonResponse response = new ABBJsonResponse("OlcuBirimiController/ Araç Başarıyla Silindi");
                response.StatusCode = 200;
                return response;
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }
    }
}
