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
        [HttpGet]
        public JsonResult GetArac(int id)
        {
            //Tek Arac getirme.

            BrAraclar arac = _araclar.TekAracGetir(id);
            //Isturunun bağlı olduğu performans getirme.
            //StPerformanslar isturuPerformansi = stIsturleri.Performans;
            //VMPerformanslar vmperformans = new VMPerformanslar()
            //{
            //    Adi = isturuPerformansi.Adi,
            //    id = isturuPerformansi.Id,
            //    Deleted = (bool)isturuPerformansi.Deleted
            //};
            ////ViewModal Mapleme işlemi.
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
        [HttpGet("GetListofAraclar")]
        public JsonResult AraclariListele()
        {
            //Veritabanından BrAraclar tablosunun listesini almaişlemi.
            List<BrAraclar> araclar = _araclar.AracListele();
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
                    TahsisTuru = (AKYSTRATEJI.enums.TahsisTuru)arac.TahsisTuru
                });
            }
            return new JsonResult(vmListe);
        }
        [HttpPost]
        public IActionResult YeniAracEkle(VMAraclar eklenecek)
        {
            //Yeni veri id si service tarafından atanmaktadır.
            //VMAraclar to BrAraclar
            var model = new BrAraclar()
            {
                Adi = eklenecek.Adi,
                Deleted = (bool)eklenecek.Deleted,
                OlusturmaTarihi = eklenecek.OlusturmaTarihi,
                Cinsi = (decimal)eklenecek.AracCinsi,
                TahsisTuru = (decimal)eklenecek.TahsisTuru,
                BirimId=eklenecek.BirimId
                //-WRN- Birim eklenecek
            };
            try
            {
                _araclar.Ekle(model);
                return new ABBJsonResponse("AraclarController/ Araç Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut]
        public IActionResult AracGuncelle(VMAraclar guncellenecek)
        {
            var model = new BrAraclar()
            {
                Adi = guncellenecek.Adi,
                Deleted = guncellenecek.Deleted,
                OlusturmaTarihi = guncellenecek.OlusturmaTarihi,
                Cinsi= (decimal)guncellenecek.AracCinsi,
                TahsisTuru = (decimal)guncellenecek.TahsisTuru,
                BirimId = guncellenecek.BirimId
            };
            try
            {
                _araclar.Guncelle(model);
                return new ABBJsonResponse("AraclarController/ Araç Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("Delete")]
        public IActionResult AracSil(VMAraclar silinecek)
        {
            BrAraclar model = _araclar.Getir(arac => arac.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _araclar.Guncelle(model);
                return new ABBJsonResponse("AraclarController/ Araç Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }
    }
}
