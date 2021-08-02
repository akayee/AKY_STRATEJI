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
    public class YillikHedeflerController:ControllerBase
    {
        private readonly ILogger<YillikHedeflerController> _logger;

        private readonly IYillikHedefServices _yillikhedefService;

        public YillikHedeflerController(ILogger<YillikHedeflerController> logger, IYillikHedefServices yillikhedefService)
        {
            _logger = logger;
            _yillikhedefService = yillikhedefService;
        }

        [HttpGet("YillikHedefGetir")]
        public JsonResult YillikHedefGetir(int id)
        {
            //Tek yıllık hedef getirme.

            StYillikhedef getirelecekveri = _yillikhedefService.TekYillikHedefGetir(id);


            if (!(getirelecekveri is null))
            {
                var model = new VMYillikHedefler()
                {
                    id = getirelecekveri.Id,
                    Deleted = (bool)getirelecekveri.Deleted,
                    Hedef = getirelecekveri.Hedef,
                    HedefN = getirelecekveri.HedefN,
                    HedefNN = getirelecekveri.HedefNn,
                    OlusturmaTarihi = getirelecekveri.OlusturmaTarihi,
                    Yil = getirelecekveri.Yil,
                    IsturuId= (int)getirelecekveri.IsTuruId,
                    FaaliyetlerId= (int)getirelecekveri.FaaliyetId
                };
                return new JsonResult(model);
            }
            else
            {

                return new JsonResult("Veri Bulunmuyor");
            }

        }
        [HttpGet("GetListofYillikHedefler")]
        public JsonResult YillikHedefleriListele()
        {
            //Veritabanından Kullanicilar tablosunun listesini almaişlemi.
            List<StYillikhedef> list = _yillikhedefService.YillikHedefleriListele();
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMYillikHedefler> vmListe = new List<VMYillikHedefler>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (StYillikhedef listmember in list)
            {

                vmListe.Add(new VMYillikHedefler()
                {
                    id = listmember.Id,
                    Deleted = (bool)listmember.Deleted,
                    Hedef=listmember.Hedef,
                    HedefN=listmember.HedefN,
                    HedefNN=listmember.HedefNn,
                    OlusturmaTarihi=listmember.OlusturmaTarihi,
                    Yil=listmember.Yil,
                    IsturuId= (int?)listmember.IsTuruId,
                    FaaliyetlerId = (int?)listmember.FaaliyetId
                });
            }
            return new JsonResult(vmListe);
        }
        [HttpPost("YeniYillikHedefEkle")]
        public IActionResult YeniYillikHedefEkle(VMYillikHedefler eklenecek)
        {
            //Yeni veri id si service tarafından atanmaktadır.
            //VMYillikHedefler to StYillikhedef
            var model = new StYillikhedef()
            {
                Id = eklenecek.id,
                Deleted = (bool)eklenecek.Deleted,
                Yil=eklenecek.Yil,
                OlusturmaTarihi = DateTime.Now,
                HedefNn=eklenecek.HedefNN,
                HedefN=eklenecek.HedefN,
                Hedef=eklenecek.Hedef,
                YillikHedefId=eklenecek.id,
                IsTuruId=eklenecek.IsturuId,
                FaaliyetId=eklenecek.FaaliyetlerId
            };
            try
            {
                _yillikhedefService.YeniYillikHedefEkle(model);
                return new ABBJsonResponse("YillikHedeflerController/ Kayıt Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("YillikHedefGuncelle")]
        public IActionResult YillikHedefGuncelle(VMYillikHedefler guncellenecek)
        {
            var model = new StYillikhedef()
            {
                Id = guncellenecek.id,
                Deleted = (bool)guncellenecek.Deleted,
                Yil = guncellenecek.Yil,
                OlusturmaTarihi = guncellenecek.OlusturmaTarihi,
                HedefNn = guncellenecek.HedefNN,
                HedefN = guncellenecek.HedefN,
                Hedef = guncellenecek.Hedef,
                YillikHedefId = guncellenecek.id,
                IsTuruId=guncellenecek.IsturuId,
                FaaliyetId = guncellenecek.FaaliyetlerId
            };
            try
            {
                _yillikhedefService.TekYillikHedefGuncelle(model);
                return new ABBJsonResponse("YillikHedeflerController/ Araç Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("YillikHedefSil")]
        public IActionResult YillikHedefSil(VMYillikHedefler silinecek)
        {
            StYillikhedef model = _yillikhedefService.Getir(yillikhedef => yillikhedef.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _yillikhedefService.TekYillikHedefGuncelle(model);
                return new ABBJsonResponse("YillikHedeflerController/ Araç Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }
    }
}
