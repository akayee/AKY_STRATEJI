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
    public class PerformanslarController : ControllerBase
    {
        private readonly ILogger<PerformanslarController> _logger;
        //Performanslar işlemlerini yaptığımız servis
        private readonly IHedeflerServices _hedefler;
        private readonly IPerformanslarServices _performanslar;

        public PerformanslarController(ILogger<PerformanslarController> logger, IHedeflerServices hedefler, IPerformanslarServices performanslar)
        {
            _logger = logger;
            _hedefler = hedefler;
            _performanslar = performanslar;
        }
        [HttpGet("GetaPerformance")]
        public JsonResult GetPerformans(int id)
        {
            //Tek Performans getirme.
            StPerformanslar performanslar = _performanslar.TekPerformansGetir(id);


            if (!(performanslar is null))
            {

                //ViewModal Mapleme işlemi.
                var model = new VMPerformanslar()
                {
                    id = performanslar.Id,
                    Adi = performanslar.Adi,
                    OlusturmaTarihi = performanslar.OlusturmaTarihi,
                    Deleted = (bool)performanslar.Deleted,
                    HedeflerId = performanslar.HedeflerId
                };

                return new JsonResult(model);
            }
            else
            {

                return new JsonResult("Veri Bulunmuyor");
            }
        }
        [HttpGet("GetListofPerformanslar")]
        public JsonResult PerformansListele()
        {
            //Veritabanından StPerformanslar tablosunun listesini almaişlemi.
            List<StPerformanslar> performanslar = _performanslar.PerformanslariListele();
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMPerformanslar> vmListe = new List<VMPerformanslar>();

            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (StPerformanslar performans in performanslar)
            {
                StHedefler performansinHedefi = _hedefler.Getir(hedef => hedef.Id == performans.HedeflerId);
                VMHedefler vmhedef = new VMHedefler()
                {
                    Tanim = performansinHedefi.Tanim,
                    id = performansinHedefi.Id,
                    Deleted = (bool)performansinHedefi.Deleted
                };

                vmListe.Add(new VMPerformanslar()
                {
                    id = performans.Id,
                    Adi = performans.Adi,
                    HedeflerId = performans.HedeflerId,
                    Deleted = (bool)performans.Deleted,
                    OlusturmaTarihi = performans.OlusturmaTarihi
                });
            }

            return new JsonResult(performanslar);
        }
        [HttpPost("AddNewPerformans")]
        public IActionResult YeniPerformansEkle(VMPerformanslar eklenecek)
        {

            //Yeni veri id si service tarafından atanmaktadır.
            //VMPerformanslar to StPerformanslar mapleme işlemi
            var model = new StPerformanslar()
            {
                Adi = eklenecek.Adi,
                OlusturmaTarihi = DateTime.Now,
                HedeflerId = eklenecek.HedeflerId,
                Hedefler = _hedefler.Getir(hedef => hedef.Id == eklenecek.HedeflerId),
                Deleted = false
            };
            try
            {
                //Veri tabanına ekleme işlemi.
                return new JsonResult(_performanslar.YeniPerformansEkle(model));
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("UpdateaPerformance")]
        public IActionResult PerformansGuncelle(VMPerformanslar guncellenecek)
        {

            var model = new StPerformanslar()
            {
                Adi = guncellenecek.Adi,
                OlusturmaTarihi = guncellenecek.OlusturmaTarihi,
                Id = guncellenecek.id,
                Deleted = guncellenecek.Deleted,
                HedeflerId = guncellenecek.HedeflerId,
                Hedefler=_hedefler.Getir(amac => amac.Id == guncellenecek.HedeflerId)
            };
            try
            {

                return new JsonResult(_performanslar.PerformansGuncelle(model));
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("DeleteaPerformans")]
        public IActionResult PerformansDelete(VMPerformanslar guncellenecek)
        {

            var model = new StPerformanslar()
            {
                Adi = guncellenecek.Adi,
                OlusturmaTarihi = guncellenecek.OlusturmaTarihi,
                Id = guncellenecek.id,
                Deleted = true,
                HedeflerId = guncellenecek.HedeflerId,
                Hedefler = _hedefler.Getir(hedef => hedef.Id == guncellenecek.HedeflerId)
            };
            try
            {
                _performanslar.PerformansGuncelle(model);
                return new ABBJsonResponse("Stratejik Performans Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
    }
}
