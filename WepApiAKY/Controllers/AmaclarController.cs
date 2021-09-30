using ABB.WebMvcUI.Models;
using AKYSTRATEJI.Model;
using AKYSTRATEJI.ViewModals;
using AutoMapper;
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
    public class AmaclarController : ControllerBase
    {
        //loglama servisi
        private readonly ILogger<AmaclarController> _logger;
        //Stratejik Amaclar işlemlerini yaptığımız servis
        private readonly IAmaclarService _amaclar;
        private readonly IStratejiRelationServices _stratejiRelations;
        public AmaclarController(ILogger<AmaclarController> logger, IAmaclarService amaclar ,IStratejiRelationServices relations)
        {
            _logger = logger;
            _amaclar = amaclar;
            _stratejiRelations = relations;
        }

        [HttpGet("GetAmac")]
        public JsonResult GetAmaclar(int id)
        {
            
            //Tek Amac getirme.
            StAmaclar amaclar = _amaclar.AmacGetir(id);
            if (!(amaclar is null))
            {
                //Mapleme işlemi.
                var model = new VMAmaclar()
                {
                    id = amaclar.Id,
                    Adi = amaclar.Adi,
                    OlusturmaTarihi = amaclar.OlusturmaTarihi,
                    Deleted = (bool)amaclar.Deleted
                };

                return new JsonResult(model);
            }
            else
            {

                return new JsonResult("Veri Bulunmuyor");
            }



        }
        [HttpGet("GetListofAmaclar")]
        public JsonResult AmacListe()
        {
            //Veritabanından StAmaclar tablosunun listesini almaişlemi.
            List<StAmaclar> amaclar = _amaclar.Listele(obj=>obj.Deleted!=true,obj=>obj.StStratejireleations);
            List<VMAmaclar> vMAmaclars = new List<VMAmaclar>(); 
            foreach(StAmaclar amac in amaclar)
            {
                //WARNING Hatalı
                //StStratejireleation relations = _stratejiRelations.TekStratejiRelationGetir(obj => obj.Deleted != true && obj.Id == amac.StStratejireleations.ı, obj => obj.StratejiYili);
                VMAmaclar vmamac = new VMAmaclar()
                {
                    Adi = amac.Adi,
                    Deleted = (bool)amac.Deleted,
                    id = amac.Id,
                    OlusturmaTarihi = amac.OlusturmaTarihi,
                    //Yil=relations.StratejiYili.Yil
            };
                vMAmaclars.Add(vmamac);
            }

            return new JsonResult(vMAmaclars);
        }
        [HttpPost("AddNewAmac")]
        public IActionResult Ekle(VMAmaclar eklenecek)
        {

            //Yeni veri id si service tarafından atanmaktadır.
            //VMAmaclar to StAmaclar mapleme işlemi
            var model = new StAmaclar()
            {
                Adi = eklenecek.Adi,
                OlusturmaTarihi = DateTime.Now
            };
            try
            {
                return new JsonResult(_amaclar.AmacEkle(model));
            }
            catch(Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("UpdateAnAmac")]
        public IActionResult AmacGuncelle(VMAmaclar guncellenecek)
        {
            
            var model = new StAmaclar()
            {
                Adi = guncellenecek.Adi,
                OlusturmaTarihi = guncellenecek.OlusturmaTarihi,
                Id = guncellenecek.id,
                Deleted=guncellenecek.Deleted,
                AmacId=guncellenecek.id
            };
            try
            {
                _amaclar.AmacGuncelle(model);
                return new ABBJsonResponse("Stratejik Amaç Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("DeleteAnAmac")]
        public IActionResult AmacDelete(VMAmaclar guncellenecek)
        {

            var model = new StAmaclar()
            {
                Adi = guncellenecek.Adi,
                OlusturmaTarihi = guncellenecek.OlusturmaTarihi,
                Id = guncellenecek.id,
                Deleted = true,
                AmacId = guncellenecek.id
            };
            try
            {
                _amaclar.AmacGuncelle(model);
                return new ABBJsonResponse("Stratejik Amaç Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
    }
}
