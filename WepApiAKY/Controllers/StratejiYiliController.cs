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
    public class StratejiYiliController:ControllerBase
    {
        private readonly ILogger<StratejiYiliController> _logger;
        //Strateji yılı işlemleri
        private readonly IStratejiYiliServices _stratejiyili;

        public StratejiYiliController(ILogger<StratejiYiliController> logger, IStratejiYiliServices stratejiyili)
        {
            _logger = logger;
            _stratejiyili = stratejiyili;
        }
        [HttpGet("GetaStratejiYili")]
        public JsonResult StratejiYiliGetir(int id)
        {
            //Tek strateji yılı getirme.

            StStratejiyili getirelecekveri = _stratejiyili.TekStratejiYiliGetir(id);

            if (!(getirelecekveri is null))
            {
                var model = new VMStratejiYili()
                {
                    id = getirelecekveri.Id,
                    Deleted = (bool)getirelecekveri.Deleted,
                    yil = getirelecekveri.Yil
                };
                return new JsonResult(model);
            }
            else
            {

                return new JsonResult("Veri Bulunmuyor");
            }
        }
        [HttpGet("GetListofStratejiYili")]
        public JsonResult KullanicilariListele()
        {
            //Veritabanından Strateji yılı tablosunun listesini almaişlemi.
            List<StStratejiyili> list = _stratejiyili.StratejiYiliListele();
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMStratejiYili> vmListe = new List<VMStratejiYili>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (StStratejiyili listmember in list)
            {

                vmListe.Add(new VMStratejiYili()
                {
                    id = listmember.Id,
                    Deleted = (bool)listmember.Deleted,
                    yil=listmember.Yil
                });
            }
            return new JsonResult(vmListe);
        }
        [HttpPost("AddNewaStratejiYili")]
        public IActionResult YeniStratejiYiliEkle(VMStratejiYili eklenecek)
        {
            //Yeni veri id si service tarafından atanmaktadır.
            //VMStratejiYili to StStratejiyili
            var model = new StStratejiyili()
            {
                Id = eklenecek.id,
                Deleted = (bool)eklenecek.Deleted,
                Yil=eklenecek.yil
            };
            try
            {
                _stratejiyili.YeniStratejiYiliEkle(model);
                return new ABBJsonResponse("StratejiYiliController/ Kayıt Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("DeleteaStratejiYili")]
        public IActionResult StratejiYiliSil(VMStratejiYili silinecek)
        {
            StStratejiyili model = _stratejiyili.Getir(kullanici => kullanici.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _stratejiyili.TekStratejiYiliGuncelle(model);
                return new ABBJsonResponse("StratejiYiliController/ Araç Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }

    }
}
