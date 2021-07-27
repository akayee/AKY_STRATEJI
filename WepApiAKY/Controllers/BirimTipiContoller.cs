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
    public class BirimTipiContoller:ControllerBase
    {
        private readonly ILogger<BirimTipiContoller> _logger;
        //BirimTipi İşlemlerinin yapıldığı Servis
        private readonly IBirimTipleriServices _birimtipleri;

        public BirimTipiContoller(ILogger<BirimTipiContoller> logger, IBirimTipleriServices birimtipleri)
        {
            _logger = logger;
            _birimtipleri = birimtipleri;
        }
        [HttpGet("GetaBirimTipi")]
        public JsonResult GetBirimTipi(int id)
        {
            //Tek Arac getirme.

            BrBirimtipleri birimtipi = _birimtipleri.TekBirimTipiGetir(id);

            var model = new VMBirimTipleri()
            {
                Id = birimtipi.Id,
                Deleted = (bool)birimtipi.Deleted,
                BirimTipi= birimtipi.BirimTipi

            };

            return new JsonResult(model);
        }
        [HttpGet("GetListofBirimTipleri")]
        public JsonResult BirimTipiListele()
        {
            //Veritabanından BrDonanimlar tablosunun listesini almaişlemi.
            List<BrBirimtipleri> birimtipleri = _birimtipleri.BirimTipleriListele();
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMBirimTipleri> vmListe = new List<VMBirimTipleri>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (BrBirimtipleri birimtipi in birimtipleri)
            {

                vmListe.Add(new VMBirimTipleri()
                {
                    Id = birimtipi.Id,
                    Deleted = (bool)birimtipi.Deleted,
                    BirimTipi=birimtipi.BirimTipi
                });
            }
            return new JsonResult(vmListe);
        }
        [HttpPost("AddNewBirimTipi")]
        public IActionResult YeniBirimTipiEkle(VMBirimTipleri eklenecek)
        {
            //Yeni veri id si service tarafından atanmaktadır.
            //VMBirimtipleri to BrBirimtipleri
            var model = new BrBirimtipleri()
            {
                Id = eklenecek.Id,
                Deleted = (bool)eklenecek.Deleted,
                BirimTipi = eklenecek.BirimTipi
            };
            try
            {
                _birimtipleri.Ekle(model);
                return new ABBJsonResponse("BirimTipiController/ Araç Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("UpdateaBirimTipi")]
        public IActionResult BirimTipiGuncelle(VMBirimTipleri guncellenecek)
        {
            var model = new BrBirimtipleri()
            {
                Id = guncellenecek.Id,
                Deleted = (bool)guncellenecek.Deleted,
                BirimTipi = guncellenecek.BirimTipi
            };
            try
            {
                _birimtipleri.Guncelle(model);
                return new ABBJsonResponse("BirimTipiController/ Araç Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("DeleteaBirimTipi")]
        public IActionResult BirimTipiSil(VMBirimTipleri silinecek)
        {
            BrBirimtipleri model = _birimtipleri.Getir(birimtipi => birimtipi.Id == silinecek.Id);
            model.Deleted = true;
            try
            {
                _birimtipleri.Guncelle(model);
                return new ABBJsonResponse("BirimTipiController/ Araç Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }
    }

}
