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
    public class PersonelController:ControllerBase
    {
        private readonly ILogger<PersonelController> _logger;
        //Personel  İşlemlerinin yapıldığı Servis
        private readonly IPersonellerServices _personelServices;

        public PersonelController(ILogger<PersonelController> logger, IPersonellerServices personelServices)
        {
            _logger = logger;
            _personelServices = personelServices;
        }
        [HttpGet]
        public JsonResult PersonelGetir(int id)
        {
            //Tek Personel getirme.

            BrPersoneller Personel = _personelServices.TekPersonelGetir(id);

            var model = new VMPersoneller()
            {
                id = Personel.Id,
                Deleted = (bool)Personel.Deleted,
                Adi = Personel.Adi,
                BirimId = Personel.BirimId,
                OlusturmaTarihi = Personel.OlusturmaTarihi,
                Cinsiyet = Personel.Cinsiyet,
                DogumTarihi = Personel.DogumTarihi,
                IseGirisTarihi = Personel.IseGirisTarihi,
                Kadro = (AKYSTRATEJI.enums.Kadrolar)Personel.Kadro,
                KullaniciId = (int)Personel.KullaniciId,
                Mezuniyet = (AKYSTRATEJI.enums.Mezuniyet)Personel.Mezuniyet,
                Tel = (short)Personel.Tel,
                Unvan = (AKYSTRATEJI.enums.Unvanlar)Personel.Unvan
            };
            return new JsonResult(model);
        }
        [HttpGet("GetListofPersoneller")]
        public JsonResult PersonelleriListele()
        {
            //Veritabanından BrMevzuatlar tablosunun listesini almaişlemi.
            List<BrPersoneller> personeller = _personelServices.PersonelleriListele();
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMPersoneller> vmListe = new List<VMPersoneller>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (BrPersoneller Personel in personeller)
            {

                vmListe.Add(new VMPersoneller()
                {
                    id = Personel.Id,
                    Deleted = (bool)Personel.Deleted,
                    Adi = Personel.Adi,
                    BirimId = Personel.BirimId,
                    OlusturmaTarihi = Personel.OlusturmaTarihi,
                    Cinsiyet = Personel.Cinsiyet,
                    DogumTarihi = Personel.DogumTarihi,
                    IseGirisTarihi = Personel.IseGirisTarihi,
                    Kadro = (AKYSTRATEJI.enums.Kadrolar)Personel.Kadro,
                    KullaniciId = (int)Personel.KullaniciId,
                    Mezuniyet = (AKYSTRATEJI.enums.Mezuniyet)Personel.Mezuniyet,
                    Tel = (short)Personel.Tel,
                    Unvan = (AKYSTRATEJI.enums.Unvanlar)Personel.Unvan
                });
            }
            return new JsonResult(vmListe);
        }
        [HttpPost]
        public IActionResult YeniPersonelEkle(VMPersoneller eklenecek)
        {
            //Yeni veri id si service tarafından atanmaktadır.
            //VMPersoneller to BrPersoneller
            var model = new BrPersoneller()
            {
                Id = eklenecek.id,
                Deleted = (bool)eklenecek.Deleted,
                Adi = eklenecek.Adi,
                BirimId = eklenecek.BirimId,
                OlusturmaTarihi = eklenecek.OlusturmaTarihi,
                Cinsiyet = eklenecek.Cinsiyet,
                DogumTarihi = eklenecek.DogumTarihi,
                IseGirisTarihi = eklenecek.IseGirisTarihi,
                Kadro = (decimal)eklenecek.Kadro,
                KullaniciId = eklenecek.KullaniciId,
                Mezuniyet = (decimal?)eklenecek.Mezuniyet,
                Tel = eklenecek.Tel,
                Unvan = (decimal?)eklenecek.Unvan
            };
            try
            {
                _personelServices.Ekle(model);
                return new ABBJsonResponse("PersonelController/ Araç Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut]
        public IActionResult PersonelGuncelle(VMPersoneller guncellenecek)
        {
            var model = new BrPersoneller()
            {
                Id = guncellenecek.id,
                Deleted = (bool)guncellenecek.Deleted,
                Adi = guncellenecek.Adi,
                BirimId = guncellenecek.BirimId,
                OlusturmaTarihi = guncellenecek.OlusturmaTarihi,
                Cinsiyet = guncellenecek.Cinsiyet,
                DogumTarihi = guncellenecek.DogumTarihi,
                IseGirisTarihi = guncellenecek.IseGirisTarihi,
                Kadro = (decimal)guncellenecek.Kadro,
                KullaniciId = guncellenecek.KullaniciId,
                Mezuniyet = (decimal?)guncellenecek.Mezuniyet,
                Tel = guncellenecek.Tel,
                Unvan = (decimal?)guncellenecek.Unvan
            };
            try
            {
                _personelServices.Guncelle(model);
                return new ABBJsonResponse("PersonelController/ Araç Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("Delete")]
        public IActionResult PersonelSil(VMPersoneller silinecek)
        {
            BrPersoneller model = _personelServices.Getir(personel => personel.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _personelServices.Guncelle(model);
                return new ABBJsonResponse("PersonelController/ Araç Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }

    }
}
