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
        public AmaclarController(ILogger<AmaclarController> logger, IAmaclarService amaclar)
        {
            _logger = logger;
            _amaclar = amaclar;
        }

        [HttpGet]
        public JsonResult GetAmaclar(int id)
        {
            
            //Tek Amac getirme.
            StAmaclar amaclar = _amaclar.AmacGetir(id);
            System.Diagnostics.Debug.WriteLine(amaclar.Adi);
            System.Diagnostics.Debug.WriteLine(amaclar.Id);
            System.Diagnostics.Debug.WriteLine(amaclar.OlusturmaTarihi);
            System.Diagnostics.Debug.WriteLine(amaclar.Deleted);
            //Mapleme işlemi.
            var model = new VMAmaclar(){
                id = amaclar.Id,
                Adi = amaclar.Adi,
                OlusturmaTarihi = amaclar.OlusturmaTarihi,
                Deleted= (bool)amaclar.Deleted
           };
            

            return new JsonResult(model);
        }
        [HttpGet("GetAll")]
        public JsonResult AmacListe()
        {
            //Veritabanından StAmaclar tablosunun listesini almaişlemi.
            List<StAmaclar> amaclar = _amaclar.Listele();

            return new JsonResult(amaclar);
        }
        [HttpPost]
        public IActionResult Ekle(VMAmaclar eklenecek)
        {
            //VMAmaclar to StAmaclar mapleme işlemi
            var model = new StAmaclar()
            {
                Adi = eklenecek.Adi,
                OlusturmaTarihi = DateTime.Now
            };
            try
            {
                //Veri tabanına ekleme işlemi.
                _amaclar.Ekle(model);
                return new ABBJsonResponse("Stratejik Amaç Başarıyla Eklendi");
            }
            catch(Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut]
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
                _amaclar.Guncelle(model);
                return new ABBJsonResponse("Stratejik Amaç Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPut("Delete")]
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
                _amaclar.Guncelle(model);
                return new ABBJsonResponse("Stratejik Amaç Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
    }
}
