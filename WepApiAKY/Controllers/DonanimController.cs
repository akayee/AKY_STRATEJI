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
    public class DonanimController:ControllerBase
    {
        private readonly ILogger<DonanimController> _logger;
        //Donanim İşlemlerinin yapıldığı Servis
        private readonly IDonanimServices _donanimlar;

        public DonanimController(ILogger<DonanimController> logger, IDonanimServices donanimlar)
        {
            _logger = logger;
            _donanimlar = donanimlar;
        }
        [HttpGet("GetaDonanim")]
        public JsonResult GetDonanim(int id)
        {
            //Tek Arac getirme.

            BrDonanimlar donanim = _donanimlar.TekDonanimGetir(id);


            if (!(donanim is null))
            {
                var model = new VMDonanimlar()
                {
                    id = donanim.Id,
                    Adi = donanim.Adi,
                    OlusturmaTarihi = donanim.OlusturmaTarihi,
                    Deleted = (bool)donanim.Deleted,
                    Sayi = donanim.Sayi,
                    BirimId = donanim.BirimId
                    //-WRN- //Birimler eklenecek

                };

                return new JsonResult(model);
            }
            else
            {

                return new JsonResult("Veri Bulunmuyor");
            }            
        }
        [HttpGet("GetListofDonanimlar")]
        public JsonResult DonanimListele(int BirimId)
        {
            //Veritabanından BrDonanimlar tablosunun listesini almaişlemi.
            List<BrDonanimlar> donanimlar = _donanimlar.DonanimListele(obj=> obj.BirimId==BirimId && obj.Deleted!=true);
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMDonanimlar> vmListe = new List<VMDonanimlar>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (BrDonanimlar donanim in donanimlar)
            {
                
                vmListe.Add(new VMDonanimlar()
                {
                    id = donanim.Id,
                    Adi = donanim.Adi,
                    OlusturmaTarihi = donanim.OlusturmaTarihi,
                    Deleted = (bool)donanim.Deleted,
                    Sayi = donanim.Sayi,
                    BirimId = donanim.BirimId
                });
            }
            return new JsonResult(vmListe);
        }
        [HttpPost("AddNewDonanim")]
        public IActionResult YeniDonanimEkle(VMDonanimlar eklenecek)
        {
            //Yeni veri id si service tarafından atanmaktadır.
            //VMDonanimlar to BrDonanimlar
            var model = new BrDonanimlar()
            {
                Id = eklenecek.id,
                Adi = eklenecek.Adi,
                OlusturmaTarihi = DateTime.Now,
                Deleted = (bool)eklenecek.Deleted,
                Sayi = eklenecek.Sayi,
                BirimId = eklenecek.BirimId
            };
            try
            {
                return new JsonResult(_donanimlar.YeniDonanimEkle(model));
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("UpdateaDonanim")]
        public IActionResult DonanimGuncelle(VMDonanimlar guncellenecek)
        {
            var model = new BrDonanimlar()
            {
                Id = guncellenecek.id,
                Adi = guncellenecek.Adi,
                OlusturmaTarihi = guncellenecek.OlusturmaTarihi,
                Deleted = (bool)guncellenecek.Deleted,
                Sayi = guncellenecek.Sayi,
                BirimId = guncellenecek.BirimId
            };
            try
            {
                _donanimlar.DonanimGuncelle(model);
                return new ABBJsonResponse("DonanimController/ Araç Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("DeleteaDonanim")]
        public IActionResult DonanimSil(VMDonanimlar silinecek)
        {
            BrDonanimlar model = _donanimlar.Getir(donanim => donanim.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _donanimlar.DonanimGuncelle(model);
                return new ABBJsonResponse("DonanimController/ Araç Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }
    }
}
