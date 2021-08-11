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
    public class StratejiYilReleationController :  ControllerBase
    {
        private readonly ILogger<StratejiYilReleationController> _logger;
        private readonly IStratejiRelationServices _yililiskiservice;

        public StratejiYilReleationController(ILogger<StratejiYilReleationController> logger, IStratejiRelationServices yililiskiservice)
        {
            _logger = logger;
            _yililiskiservice = yililiskiservice;
        }

        [HttpGet("GetYilİliski")]
        public JsonResult GetYilReleation(int id)
        {

            //Tek Amac getirme.
            StStratejireleation releation = _yililiskiservice.TekStratejiRelationGetir(id);
            if (!(releation is null))
            {
                //Mapleme işlemi.
                var model = new VMStratejiReleation()
                {
                    AmacId= (int)releation.AmacId,
                    Deleted=releation.Deleted,
                    FaaliyetId=(int)releation.FaaliyetId,
                    HedefId=(int)releation.HedefId,
                    Id=releation.Id,
                    IsturuId=(int)releation.IsturuId,
                    OlusturanKullanici=(int)releation.OlusturanKullanici,
                    OlusturmaTarihi=releation.OlusturmaTarihi,
                    PerformansId=(int)releation.PerformansId,
                    StratejiYiliId=releation.StratejiYiliId,
                    YillikHedefId=(int)releation.YillikHedefId
                };
                
                return new JsonResult(model);
            }
            else
            {

                return new JsonResult("Veri Bulunmuyor");
            }
        }
        [HttpGet("GetListofStratejiReleation")]
        public JsonResult YilReleationListe()
        {
            //Veritabanından StAmaclar tablosunun listesini almaişlemi.
            List<StStratejireleation> amaclar = _yililiskiservice.DetayliListe();
            List<VMStratejiReleation> vMAmaclars = new List<VMStratejiReleation>();

            foreach (StStratejireleation releation in amaclar)
            {
                VMStratejiReleation vmamac = new VMStratejiReleation()
                {
                    AmacId = (int)releation.AmacId,
                    Deleted = releation.Deleted,
                    FaaliyetId = (int)releation.FaaliyetId,
                    HedefId = (int)releation.HedefId,
                    Id = releation.Id,
                    IsturuId = (int)releation.IsturuId,
                    OlusturanKullanici = (int)releation.OlusturanKullanici,
                    OlusturmaTarihi = releation.OlusturmaTarihi,
                    PerformansId = (int)releation.PerformansId,
                    StratejiYiliId = releation.StratejiYiliId,
                    YillikHedefId = (int)releation.YillikHedefId
                };
                vMAmaclars.Add(vmamac);
            }

            return new JsonResult(vMAmaclars);
        }

        [HttpPost("AddNewYilReleation")]
        public IActionResult YilReleationEkle(VMStratejiReleation eklenecek)
        {

            //Yeni veri id si service tarafından atanmaktadır.
            //VMAmaclar to StAmaclar mapleme işlemi
            var model = new StStratejireleation()
            {
                AmacId = (int)eklenecek.AmacId,
                Deleted = eklenecek.Deleted,
                FaaliyetId = (int)eklenecek.FaaliyetId,
                HedefId = (int)eklenecek.HedefId,
                Id = eklenecek.Id,
                IsturuId = (int)eklenecek.IsturuId,
                OlusturanKullanici = (int)eklenecek.OlusturanKullanici,
                OlusturmaTarihi = eklenecek.OlusturmaTarihi,
                PerformansId = (int)eklenecek.PerformansId,
                StratejiYiliId = eklenecek.StratejiYiliId,
                YillikHedefId = (int)eklenecek.YillikHedefId
            };
            try
            {
                //Veri tabanına ekleme işlemi.
                _yililiskiservice.YeniStratejiIliskiEkle(model);
                return new ABBJsonResponse("Stratejik Yil Verisi Başarıyla Eklendi");
            }
            catch(Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }

        [HttpPost("AddNewMultipleYilReleation")]
        public IActionResult TopluYilReleationEkle(List<VMStratejiReleation> eklenecekler)
        {

            //Yeni veri id si service tarafından atanmaktadır.
            //VMAmaclar to StAmaclar mapleme işlemi
            List<StStratejireleation> stliste = new List<StStratejireleation>();
            foreach(VMStratejiReleation eklenecek in eklenecekler)
            {
                var model = new StStratejireleation()
                {
                    AmacId = (int)eklenecek.AmacId,
                    Deleted = eklenecek.Deleted,
                    FaaliyetId = (int)eklenecek.FaaliyetId,
                    HedefId = (int)eklenecek.HedefId,
                    Id = eklenecek.Id,
                    IsturuId = (int)eklenecek.IsturuId,
                    OlusturanKullanici = (int)eklenecek.OlusturanKullanici,
                    OlusturmaTarihi = eklenecek.OlusturmaTarihi,
                    PerformansId = (int)eklenecek.PerformansId,
                    StratejiYiliId = eklenecek.StratejiYiliId,
                    YillikHedefId = (int)eklenecek.YillikHedefId
                };
                stliste.Add(model);
            }
           
            try
            {
                //Veri tabanına ekleme işlemi.
                _yililiskiservice.TopluEkle(stliste);
                return new ABBJsonResponse("Stratejik Yil Verisi Toplu Olarak Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("UpdateMultipleYilReleation")]
        public IActionResult TopluYilReleationGuncelle(List<VMStratejiReleation> eklenecekler)
        {

            //Yeni veri id si service tarafından atanmaktadır.
            //VMAmaclar to StAmaclar mapleme işlemi
            List<StStratejireleation> stliste = new List<StStratejireleation>();
            foreach (VMStratejiReleation eklenecek in eklenecekler)
            {
                var model = new StStratejireleation()
                {
                    AmacId = (int)eklenecek.AmacId,
                    Deleted = eklenecek.Deleted,
                    FaaliyetId = (int)eklenecek.FaaliyetId,
                    HedefId = (int)eklenecek.HedefId,
                    Id = eklenecek.Id,
                    IsturuId = (int)eklenecek.IsturuId,
                    OlusturanKullanici = (int)eklenecek.OlusturanKullanici,
                    OlusturmaTarihi = eklenecek.OlusturmaTarihi,
                    PerformansId = (int)eklenecek.PerformansId,
                    StratejiYiliId = eklenecek.StratejiYiliId,
                    YillikHedefId = (int)eklenecek.YillikHedefId
                };
                stliste.Add(model);
            }

            try
            {
                //Veri tabanına ekleme işlemi.
                _yililiskiservice.TopluStratejiIliskiSil(stliste);
                return new ABBJsonResponse("Stratejik Yil Verisi Toplu Olarak Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
    }
}
