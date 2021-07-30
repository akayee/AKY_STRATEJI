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
    public class FaaliyetTurleriController:ControllerBase
    {
        private readonly ILogger<FaaliyetTurleriController> _logger;

        private readonly IFaaliyetTurleriServices _faaliyetTurleri;

        public FaaliyetTurleriController(ILogger<FaaliyetTurleriController> logger, IFaaliyetTurleriServices faaliyetTurleri)
        {
            _logger = logger;
            _faaliyetTurleri = faaliyetTurleri;
        }

        [HttpGet("GetFaaliyetTuru")]
        public JsonResult GetFaaliyetTuru(int id)
        {
            //Tek Faaliyet Türü Getirme

            StFaaliyetler faaliyetTuru = _faaliyetTurleri.FaaliyetTuruGetir(id);

            var model = new VMFaaliyetTurleri()
            {
                id = faaliyetTuru.Id,
                Aciklama = faaliyetTuru.Aciklama,
                BirimId = faaliyetTuru.BirimId,
                Deleted = (bool)faaliyetTuru.Deleted,
                Adi = faaliyetTuru.Adi,
                FaaliyetlerId = faaliyetTuru.FaaliyetlerId,
                IsturleriId = (int)faaliyetTuru.IsTuruId,
                OlcuBirimiId = faaliyetTuru.OlcuBirimi,
                PerformansId = faaliyetTuru.PerformansId,
                YillikHedeflerId = (int)faaliyetTuru.YillikHedefId
            };
            return new JsonResult(model);
        }
        [HttpGet("GetListofFaaliyetTurleri")]
        public JsonResult FaaliyetTurleriListele()
        {
            List<StFaaliyetler> faaliyetTurleri = _faaliyetTurleri.FaaliyetTurleriListele();
            List<VMFaaliyetTurleri> vmListe = new List<VMFaaliyetTurleri>();

            foreach(StFaaliyetler faaliyetturu in faaliyetTurleri)
            {
                vmListe.Add(new VMFaaliyetTurleri()
                {
                    id = faaliyetturu.Id,
                    Aciklama = faaliyetturu.Aciklama,
                    BirimId = faaliyetturu.BirimId,
                    Deleted = (bool)faaliyetturu.Deleted,
                    Adi = faaliyetturu.Adi,
                    FaaliyetlerId = faaliyetturu.FaaliyetlerId,
                    IsturleriId = (int)faaliyetturu.IsTuruId,
                    OlcuBirimiId = faaliyetturu.OlcuBirimi,
                    PerformansId = faaliyetturu.PerformansId,
                    YillikHedeflerId= (int)faaliyetturu.YillikHedefId
                   
                });
            }
            return new JsonResult(vmListe);
        }
        [HttpPost("AddNewFaaliyetTuru")]
        public IActionResult YeniFaaliyetTuruEkle(VMFaaliyetTurleri eklenecek)
        {
            var model = new StFaaliyetler()
            {
                Id = eklenecek.id,
                Aciklama = eklenecek.Aciklama,
                Adi = eklenecek.Adi,
                BirimId = eklenecek.BirimId,
                Deleted = eklenecek.Deleted,
                FaaliyetlerId = eklenecek.FaaliyetlerId,
                IsTuruId = eklenecek.IsturleriId,
                OlcuBirimi = eklenecek.OlcuBirimiId,
                OlusturmaTarihi = eklenecek.OlusturmaTarihi,
                PerformansId = eklenecek.PerformansId,
                YillikHedefId = eklenecek.YillikHedeflerId
            };
            try
            {
                _faaliyetTurleri.Ekle(model);
                return new ABBJsonResponse("FaaliyetTurleriController/ Kayıt Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("UpdateaFaaliyetTuru")]
        public IActionResult FaaliyetTuruGuncelle (VMFaaliyetTurleri guncellenecek)
        {
            var model = new StFaaliyetler()
            {
                Id = guncellenecek.id,
                Aciklama = guncellenecek.Aciklama,
                Adi = guncellenecek.Adi,
                BirimId = guncellenecek.BirimId,
                Deleted = guncellenecek.Deleted,
                FaaliyetlerId = guncellenecek.FaaliyetlerId,
                IsTuruId = guncellenecek.FaaliyetlerId,
                OlcuBirimi = guncellenecek.OlcuBirimiId,
                OlusturmaTarihi = guncellenecek.OlusturmaTarihi,
                PerformansId = guncellenecek.PerformansId,
                YillikHedefId = guncellenecek.YillikHedeflerId
            };
            try
            {
                _faaliyetTurleri.Guncelle(model);
                return new ABBJsonResponse("FaaliyetTurleriController/ Kayıt Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("DeleteaFaaliyetTuru")]
        public IActionResult FaaliyetTuruSil(VMFaaliyetTurleri silinecek)
        {
            StFaaliyetler model = _faaliyetTurleri.Getir(faaliyetturu => faaliyetturu.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _faaliyetTurleri.Guncelle(model);
                return new ABBJsonResponse("FaaliyetTurleriController/ Kayıt Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }
    }
}
