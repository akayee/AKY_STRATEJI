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
    public class AraclarController: ControllerBase
    {
        private readonly ILogger<AraclarController> _logger;
        //Araclar İşlemlerinin yapıldığı Servis
        private readonly IAraclarServices _araclar;
        public AraclarController(ILogger<AraclarController> logger,IAraclarServices araclar)
        {
            _logger = logger;
            _araclar = araclar;
        }
        [HttpGet("GetAnArac")]
        public JsonResult GetArac(int id)
        {
            //Tek Arac getirme.

            BrAraclar arac = _araclar.TekAracGetir(id);
            if (!(arac is null))
            {
            var model = new VMAraclar()
                {
                    id = arac.Id,
                    Adi = arac.Adi,
                    OlusturmaTarihi = arac.OlusturmaTarihi,
                    Deleted = (bool)arac.Deleted,
                    AracCinsi= (AKYSTRATEJI.enums.AracCinsi)arac.Cinsi,
                    TahsisTuru= (AKYSTRATEJI.enums.TahsisTuru)arac.TahsisTuru
                    //-WRN- //Birimler eklenecek

                };

                return new JsonResult(model);
            }
            else
            {

                return new JsonResult("Veri Bulunmuyor");
            }
            //Isturunun bağlı olduğu performans getirme.
            //StPerformanslar isturuPerformansi = stIsturleri.Performans;
            //VMPerformanslar vmperformans = new VMPerformanslar()
            //{
            //    Adi = isturuPerformansi.Adi,
            //    id = isturuPerformansi.Id,
            //    Deleted = (bool)isturuPerformansi.Deleted
            //};
            ////ViewModal Mapleme işlemi.
            
        }
        [HttpGet("GetListofAraclar")]
        public JsonResult AraclariListele(int BirimId)
        {
            //Veritabanından BrAraclar tablosunun listesini almaişlemi.
            List<BrAraclar> araclar = _araclar.AracListele(obj => obj.BirimId == BirimId && obj.Deleted != true);
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMAraclar> vmListe = new List<VMAraclar>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (BrAraclar arac in araclar)
            {
                //-WRN- Birimler için alttaki satır düzenlenecek
                //StPerformanslar isturuPerformansi = _performanslar.Getir(performans => performans.Id == isturu.PerformansId);
                //VMPerformanslar vmperformans = new VMPerformanslar()
                //{
                //    Adi = isturuPerformansi.Adi,
                //    id = isturuPerformansi.Id,
                //    Deleted = (bool)isturuPerformansi.Deleted
                //};
                vmListe.Add(new VMAraclar()
                {
                    id = arac.Id,
                    Adi = arac.Adi,
                    //PerformansId = isturu.PerformansId,
                    //Performans = vmperformans,
                    Deleted = (bool)arac.Deleted,
                    OlusturmaTarihi = arac.OlusturmaTarihi,
                    AracCinsi = (AKYSTRATEJI.enums.AracCinsi)arac.Cinsi,
                    TahsisTuru = (AKYSTRATEJI.enums.TahsisTuru)arac.TahsisTuru,
                    BirimId=arac.BirimId
                });
            }
            return new JsonResult(vmListe);
        }
        [HttpPost("AddNewarac")]
        public IActionResult YeniAracEkle(VMAraclar eklenecek)
        {
            //Yeni veri id si service tarafından atanmaktadır.
            //VMAraclar to BrAraclar
            var model = new BrAraclar()
            {
                Adi = eklenecek.Adi,
                Deleted = (bool)eklenecek.Deleted,
                OlusturmaTarihi = DateTime.Now,
                Cinsi = (decimal)eklenecek.AracCinsi,
                TahsisTuru = (decimal)eklenecek.TahsisTuru,
                BirimId=eklenecek.BirimId
                //-WRN- Birim eklenecek
            };
            try
            {
                
                return new JsonResult(_araclar.YeniAracEkle(model));
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("UpdateanArac")]
        public IActionResult AracGuncelle(VMAraclar guncellenecek)
        {
            var model = new BrAraclar()
            {
                Id=guncellenecek.id,
                Adi = guncellenecek.Adi,
                Deleted = guncellenecek.Deleted,
                OlusturmaTarihi = guncellenecek.OlusturmaTarihi,
                Cinsi= (decimal)guncellenecek.AracCinsi,
                TahsisTuru = (decimal)guncellenecek.TahsisTuru,
                BirimId = guncellenecek.BirimId,
                AracId=guncellenecek.id
            };
            try
            {
                _araclar.AracGuncelle(model);
                return new ABBJsonResponse("AraclarController/ Araç Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("DeleteanArac")]
        public IActionResult AracSil(VMAraclar silinecek)
        {
            BrAraclar model = _araclar.Getir(arac => arac.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _araclar.AracGuncelle(model);
                return new ABBJsonResponse("AraclarController/ Araç Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }
    }
}
