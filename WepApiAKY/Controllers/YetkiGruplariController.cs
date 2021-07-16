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
    public class YetkiGruplariController:ControllerBase
    {
        private readonly ILogger<YetkiGruplariController> _logger;
        private readonly IYetkiGruplariServices _yetkigrupServices;

        public YetkiGruplariController(ILogger<YetkiGruplariController> logger, IYetkiGruplariServices yetkigrupServices)
        {
            _logger = logger;
            _yetkigrupServices = yetkigrupServices;
        }
        [HttpGet("YetkiGruplariGetir")]
        public JsonResult YetkiGruplariGetir(int id)
        {
            //Tek Yetki Grubu getirme.
            YtYetkigruplari getirelecekveri = _yetkigrupServices.TekYetkiGrubuGetir(id);
            var model = new VMYetkiGruplari()
            {
                id = getirelecekveri.Id,
                Deleted = (bool)getirelecekveri.Deleted,
                Adi=getirelecekveri.Adi,
                YetkilerId=getirelecekveri.YetkilerId
            };
            return new JsonResult(model);
        }
        [HttpGet("GetListofYetkiGruplari")]
        public JsonResult YetkiGruplariListele()
        {
            //Veritabanından YtYetkigruplari tablosunun listesini almaişlemi.
            List<YtYetkigruplari> list = _yetkigrupServices.YetkiGruplariListele();
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMYetkiGruplari> vmListe = new List<VMYetkiGruplari>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (YtYetkigruplari listmember in list)
            {

                vmListe.Add(new VMYetkiGruplari()
                {
                    id = listmember.Id,
                    Deleted = (bool)listmember.Deleted,
                    Adi=listmember.Adi,
                    YetkilerId=listmember.YetkilerId
                });
            }
            return new JsonResult(vmListe);
        }
        [HttpPost("YeniYetkiGrubuEkle")]
        public IActionResult YeniYetkiGrubuEkle(VMYetkiGruplari eklenecek)
        {
            //Yeni veri id si service tarafından atanmaktadır.
            //VMYetkiGruplari to YtYetkigruplari
            var model = new YtYetkigruplari()
            {
                Id = eklenecek.id,
                Deleted = (bool)eklenecek.Deleted,
                Adi=eklenecek.Adi,
                YetkilerId=eklenecek.YetkilerId
            };
            try
            {
                _yetkigrupServices.Ekle(model);
                return new ABBJsonResponse("YetkiGruplariController/ Kayıt Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("YetkiGruplariGuncelle")]
        public IActionResult YetkiGruplariGuncelle(VMYetkiGruplari guncellenecek)
        {
            var model = new YtYetkigruplari()
            {
                Id = guncellenecek.id,
                Deleted = (bool)guncellenecek.Deleted,
                Adi=guncellenecek.Adi,
                YetkilerId=guncellenecek.YetkilerId
            };
            try
            {
                _yetkigrupServices.Guncelle(model);
                return new ABBJsonResponse("YetkiGruplariController/ Araç Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("YetkiGrubuSil")]
        public IActionResult YetkiGrubuSil(VMYetkiGruplari silinecek)
        {
            YtYetkigruplari model = _yetkigrupServices.Getir(kullanici => kullanici.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _yetkigrupServices.Guncelle(model);
                return new ABBJsonResponse("YetkiGruplariController/ Araç Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }
    }
}
