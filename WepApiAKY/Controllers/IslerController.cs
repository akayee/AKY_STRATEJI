using ABB.WebMvcUI.Models;
using AKYSTRATEJI.Model;
using AKYSTRATEJI.ViewModals;
using BL.Abstract;
using BL.Concrete;
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
    public class IslerController:ControllerBase
    {
        private readonly ILogger<IslerController> _logger;
        private readonly IsService _isler;
        private readonly IIsturleriServices _isTurleri;

        public IslerController(ILogger<IslerController> logger, IsService isler, IIsturleriServices isTurleri)
        {
            _logger = logger;
            _isler = isler;
            _isTurleri = isTurleri;
        }
        [HttpGet]
        public JsonResult GetIs(int id)
        {
            //Tek Is getirme.

            StIsler stIsler = _isler.TekIsGetir(id);
            //İslere bağlı olduğu İstürü getirme.
            StIsturleri IsinIsturu = stIsler.IsTuru;
            VMIsturleri vmIsturu = new VMIsturleri()
            {
                Adi = IsinIsturu.Adi,
                id = IsinIsturu.Id,
                Deleted = (bool)IsinIsturu.Deleted
            };
            //ViewModal Mapleme işlemi.
            var model = new VMIsler()
            {
                id = stIsler.Id,
                OlusturmaTarihi = stIsler.OlusturmaTarihi,
                Deleted = (bool)stIsler.Deleted,
                IsTurleri = vmIsturu,
                IsturuId = stIsler.IsTuruId,
                BaslangicTarihi = stIsler.BaslangicTarihi,
                BitisTarihi = stIsler.BitisTarihi,
                Ilce = (AKYSTRATEJI.enums.Ilceler)stIsler.Ilce,
                Mahalle = (AKYSTRATEJI.enums.Mahalleler)stIsler.Mahalle,
                Deger = stIsler.Deger,

            };

            return new JsonResult(model);
        }
        [HttpGet("GetListofIsler")]
        public JsonResult PerformansListele()
        {
            //Veritabanından StIsler tablosunun listesini almaişlemi.
            List<StIsler> Isler = _isler.IsleriListele();
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMIsler> vmListe = new List<VMIsler>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (StIsler isturu in Isler)
            {
                StIsturleri islerinIsturu = _isTurleri.Getir(performans => performans.Id == isturu.IsTuruId);
                VMIsturleri vmIsturleri = new VMIsturleri()
                {
                    Adi = islerinIsturu.Adi,
                    id = islerinIsturu.Id,
                    Deleted = (bool)islerinIsturu.Deleted
                };
                vmListe.Add(new VMIsler()
                {
                    id = isturu.Id,
                    IsturuId = isturu.IsTuruId,
                    IsTurleri = vmIsturleri,
                    Deleted = (bool)isturu.Deleted,
                    OlusturmaTarihi = isturu.OlusturmaTarihi,
                    BaslangicTarihi = isturu.BaslangicTarihi,
                    BitisTarihi = isturu.BitisTarihi,
                    Ilce = (AKYSTRATEJI.enums.Ilceler)isturu.Ilce,
                    Mahalle = (AKYSTRATEJI.enums.Mahalleler)isturu.Mahalle,
                    Deger = isturu.Deger,
                });
            }

            return new JsonResult(vmListe);
        }
        [HttpPost]
        public IActionResult YeniIsTuruEkle(VMIsler eklenecek)
        {

            //Yeni veri id si service tarafından atanmaktadır.
            //VMIsler to StIsler
            var model = new StIsler()
            {
                BaslangicTarihi=eklenecek.BaslangicTarihi,
                BitisTarihi=eklenecek.BitisTarihi,
                Ilce= (int?)eklenecek.Ilce,
                Mahalle= (int?)eklenecek.Mahalle,
                Deger=eklenecek.Deger,
                IsTuruId = eklenecek.IsturuId,
                Deleted = eklenecek.Deleted,
                OlusturmaTarihi = DateTime.Now
            };
            try
            {
                _isler.Ekle(model);
                return new ABBJsonResponse("IslerController Stratejik Isler Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut]
        public IActionResult IsturuGunceller(VMIsler guncellenecek)
        {
            var model = new StIsler()
            {
                BaslangicTarihi = guncellenecek.BaslangicTarihi,
                BitisTarihi = guncellenecek.BitisTarihi,
                Ilce = (int?)guncellenecek.Ilce,
                Mahalle = (int?)guncellenecek.Mahalle,
                Deger = guncellenecek.Deger,
                IsTuruId = guncellenecek.IsturuId,
                Deleted = guncellenecek.Deleted,
                OlusturmaTarihi = DateTime.Now
            };
            try
            {
                _isler.Guncelle(model);
                return new ABBJsonResponse("IslerController Stratejik İş Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("Delete")]
        public IActionResult IsturuSil(VMIsler silinecek)
        {
            StIsler model = _isler.Getir(isturu => isturu.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _isler.Guncelle(model);
                return new ABBJsonResponse("IslerController Stratejik İş Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }

    }
}
