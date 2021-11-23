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
    public class KullanicilarController:ControllerBase
    {
        private readonly ILogger<KullanicilarController> _logger;
        //Kullanici İşlemlerinin yapıldığı Servis
        private readonly IKullaniciServices _kullanici;

        public KullanicilarController(ILogger<KullanicilarController> logger, IKullaniciServices kullanici)
        {
            _logger = logger;
            _kullanici = kullanici;
        }
        [HttpGet("GetKullanici")]
        public JsonResult KullaniciGetir(int id)
        {
            //Tek Kullanıcı getirme.

            Kullanicilar getirelecekveri = _kullanici.TekKullaniciGetir(id);


            if (!(getirelecekveri is null))
            {

                var model = new VMKullanicilar()
                {
                    id = getirelecekveri.Id,
                    Deleted = (bool)getirelecekveri.Deleted,
                    KullaniciAdi = getirelecekveri.KullaniciAdi,
                    Password = getirelecekveri.Password,
                    PersonelId = getirelecekveri.PersonelId,
                    YetkiGruplariId = getirelecekveri.YetkiGruplariId
                };
                return new JsonResult(model);
            }
            else
            {

                return new JsonResult("Veri Bulunmuyor");
            }
        }
        [HttpGet("GetListofKullanicilar")]
        public JsonResult KullanicilariListele()
        {
            //Veritabanından Kullanicilar tablosunun listesini almaişlemi.
            List<Kullanicilar> list = _kullanici.KullaniciListele();
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMKullanicilar> vmListe = new List<VMKullanicilar>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (Kullanicilar listmember in list)
            {

                vmListe.Add(new VMKullanicilar()
                {
                    id = listmember.Id,
                    Deleted = (bool)listmember.Deleted,
                    KullaniciAdi = listmember.KullaniciAdi,
                    Password = listmember.Password,
                    PersonelId = listmember.PersonelId,
                    YetkiGruplariId = listmember.YetkiGruplariId
                });
            }
            return new JsonResult(vmListe);
        }
        [HttpPost("AddNewKullanici")]
        public IActionResult YeniKullaniciEkle(VMKullanicilar eklenecek)
        {
            //Yeni veri id si service tarafından atanmaktadır.
            //VMKullanicilar to Kullanicilar
            var model = new Kullanicilar()
            {
                Id = eklenecek.id,
                Deleted = (bool)eklenecek.Deleted,
                KullaniciAdi = eklenecek.KullaniciAdi,
                Password = eklenecek.Password,
                PersonelId = eklenecek.PersonelId,
                YetkiGruplariId = eklenecek.YetkiGruplariId
            };
            try
            {
                _kullanici.YeniKullaniciEkle(model);
                return new ABBJsonResponse("KullanicilarController/ Kayıt Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("UpdateaKullanici")]
        public IActionResult KullaniciGuncelle(VMKullanicilar guncellenecek)
        {
            var model = new Kullanicilar()
            {
                Id = guncellenecek.id,
                Deleted = (bool)guncellenecek.Deleted,
                KullaniciAdi = guncellenecek.KullaniciAdi,
                Password = guncellenecek.Password,
                PersonelId = guncellenecek.PersonelId,
                YetkiGruplariId = guncellenecek.YetkiGruplariId
            };
            try
            {
                _kullanici.TekKullaniciGuncelle(model);
                return new ABBJsonResponse("KullanicilarController/ Araç Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("DeleteaKullanici")]
        public IActionResult KullaniciSil(VMKullanicilar silinecek)
        {
            Kullanicilar model = _kullanici.Getir(kullanici => kullanici.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _kullanici.TekKullaniciGuncelle(model);
                return new ABBJsonResponse("KullanicilarController/ Araç Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }
    }
}
