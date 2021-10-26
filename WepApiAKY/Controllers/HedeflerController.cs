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
    public class HedeflerController: ControllerBase
    {
        //loglama servisi
        private readonly ILogger<HedeflerController> _logger;
        //Stratejik Amaclar işlemlerini yaptığımız servis
        private readonly IHedeflerServices _hedefler;
        private readonly IAmaclarService _amaclar;

        public HedeflerController(ILogger<HedeflerController> logger, IHedeflerServices hedefler,IAmaclarService amaclar)
        {
            _logger = logger;
            _hedefler = hedefler;
            _amaclar = amaclar;
        }
        [HttpGet("GetHedef")]
        public JsonResult GetHedef(int id)
        {
            //Tek Hedef getirme.
            StHedefler hedefler = _hedefler.TekHedefGetir(id);

            if (!(hedefler is null))
            {
                //ViewModal Mapleme işlemi.
                var model = new VMHedefler()
                {
                    id = hedefler.Id,
                    Tanim = hedefler.Tanim,
                    OlusturmaTarihi = hedefler.OlusturmaTarihi,
                    Deleted = (bool)hedefler.Deleted,
                    AmaclarId = hedefler.AmaclarId,
                    HedeflerId=hedefler.HedeflerId
                };

                return new JsonResult(model);
            }
            else
            {

                return new JsonResult("Veri Bulunmuyor");
            }
            
        }

        [HttpGet("GetListofHedefler")]
        public JsonResult AmacListe()
        {
            //Veritabanından StAmaclar tablosunun listesini almaişlemi.
            List<StHedefler> hedefler = _hedefler.HedefleriListele();
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMHedefler> vmListe = new List<VMHedefler>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.

            foreach(StHedefler hedef in hedefler)
            {
                StAmaclar hedefinamaci = _amaclar.AmacGetir(hedef.AmaclarId);
                VMAmaclar vmamac = new VMAmaclar()
                {
                    Adi = hedefinamaci.Adi,
                    id = hedefinamaci.Id
                };
                vmListe.Add(new VMHedefler()
                {
                    id = hedef.Id,
                    Tanim=hedef.Tanim,
                    AmaclarId=hedef.AmaclarId,
                    Deleted= (bool)hedef.Deleted,
                    OlusturmaTarihi=hedef.OlusturmaTarihi,
                    HedeflerId=hedef.HedeflerId
                });
            }

            return new JsonResult(hedefler);
        }

        [HttpPost("AddNewHedef")]
        public IActionResult YeniHedefEkle(VMHedefler eklenecek)
        {

            //Yeni veri id si service tarafından atanmaktadır.
            //VMAmaclar to StAmaclar mapleme işlemi
            var model = new StHedefler()
            {
                Tanim = eklenecek.Tanim,
                OlusturmaTarihi = DateTime.Now,
                AmaclarId=eklenecek.AmaclarId,
                Deleted=false,
                
                
            };
            try
            {
                //Veri tabanına ekleme işlemi.
                return new JsonResult(_hedefler.YeniHedefEkle(model));
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }

        [HttpPost("UpdateaHedef")]
        public IActionResult HedefGuncelle(VMHedefler guncellenecek)
        {

            var model = new StHedefler()
            {
                Tanim = guncellenecek.Tanim,
                OlusturmaTarihi = guncellenecek.OlusturmaTarihi,
                Id = guncellenecek.id,
                Deleted = guncellenecek.Deleted,
                AmaclarId = guncellenecek.AmaclarId,
                Amaclar= _amaclar.Getir(amac => amac.Id == guncellenecek.AmaclarId),
                HedeflerId=guncellenecek.HedeflerId
            };
            try
            {
                _hedefler.HedefGuncelle(model);
                return new ABBJsonResponse("Stratejik Hedef Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }

        [HttpPost("DeleteaHedef")]
        public IActionResult HedefDelete(VMHedefler guncellenecek)
        {

            var model = new StHedefler()
            {
                Tanim = guncellenecek.Tanim,
                OlusturmaTarihi = guncellenecek.OlusturmaTarihi,
                Id = guncellenecek.id,
                Deleted = true,
                HedeflerId = guncellenecek.id,
                AmaclarId=guncellenecek.AmaclarId,
                Amaclar = _amaclar.Getir(amac => amac.Id == guncellenecek.AmaclarId)
            };
            try
            {
                _hedefler.HedefGuncelle(model);
                return new ABBJsonResponse("Stratejik Hedef Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
    }
}
