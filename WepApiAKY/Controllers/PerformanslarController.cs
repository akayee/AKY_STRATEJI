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
        [HttpGet]
        public JsonResult GetPerformans(int id)
        {
            //Tek Performans getirme.
            StPerformanslar performanslar = _performanslar.TekPerformansGetir(id);
            //Performansın bağlı olduğu hedef getirme.
            StHedefler performansinHedefi = _hedefler.TekHedefGetir(performanslar.HedeflerId);
            VMHedefler vmhedef = new VMHedefler()
            {
                Tanim = performansinHedefi.Tanim,
                id = performansinHedefi.Id,
                Deleted= (bool)performansinHedefi.Deleted
            };
            //ViewModal Mapleme işlemi.
            var model = new VMPerformanslar()
            {
                id = performanslar.Id,
                Adi = performanslar.Adi,
                OlusturmaTarihi = performanslar.OlusturmaTarihi,
                Deleted = (bool)performanslar.Deleted,
                HedeflerId = performanslar.HedeflerId,
                Hedefler = vmhedef
            };

            return new JsonResult(model);
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
                    Hedefler = vmhedef,
                    Deleted = (bool)performans.Deleted,
                    OlusturmaTarihi = performans.OlusturmaTarihi
                });
            }

            return new JsonResult(performanslar);
        }
        [HttpPost]
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
                _performanslar.Ekle(model);
                return new ABBJsonResponse("Stratejik Performans Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut]
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
                _performanslar.Guncelle(model);
                return new ABBJsonResponse("Stratejik Performans Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("Delete")]
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
                _performanslar.Guncelle(model);
                return new ABBJsonResponse("Stratejik Performans Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
    }
}
