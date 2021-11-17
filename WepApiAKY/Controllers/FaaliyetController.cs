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
    public class FaaliyetController:ControllerBase
    {
        private readonly ILogger<FaaliyetController> _logger;
        //Faaliyet İşlemlerinin yapıldığı Servis
        private readonly IFaaliyetServices _faaliyet;

        public FaaliyetController(ILogger<FaaliyetController> logger, IFaaliyetServices faaliyet)
        {
            _logger = logger;
            _faaliyet = faaliyet;
        }
        [HttpGet("GetFaaliyet")]
        public JsonResult GetFaaliyet(int id)
        {
            //Tek Arac getirme.

            StFaaliyet faaliyet = _faaliyet.TekFaaliyetGetir(id);

            if (!(faaliyet is null))
            {

                var model = new VMFaaliyet()
                {
                    id = faaliyet.Id,
                    OlusturmaTarihi = faaliyet.OlusturmaTarihi,
                    Deleted = (bool)faaliyet.Deleted,
                    FaaliyetlerId = faaliyet.FaaliyetlerId,
                    Deger = faaliyet.Deger

                };

                return new JsonResult(model);
            }
            else
            {

                return new JsonResult("Veri Bulunmuyor");
            }
        }

        [HttpGet("GetListofFaaliyet")]
        public JsonResult FaaliyetListele()
        {
            //Veritabanından StFaaliyet tablosunun listesini almaişlemi.
            List<StFaaliyet> faaliyetler = _faaliyet.FaaliyetListele(obj=>obj.Deleted!=true);
            //View Model tipinde liste oluşturuluyor. Güvenlik Amaçlı
            List<VMFaaliyet> vmListe = new List<VMFaaliyet>();
            //İlgili Listeler birbirlerine mapleniyor ve relationlar çekilerek ekleniyor.
            foreach (StFaaliyet faaliyet in faaliyetler)
            {

                vmListe.Add(new VMFaaliyet()
                {
                    id = faaliyet.Id,
                    OlusturmaTarihi = faaliyet.OlusturmaTarihi,
                    Deleted = (bool)faaliyet.Deleted,
                    FaaliyetlerId = faaliyet.FaaliyetlerId,
                    Deger = faaliyet.Deger
                });
            }
            return new JsonResult(vmListe);
        }
        [HttpPost("AddNewFaaliyet")]
        public IActionResult YeniFaaliyetEkle(VMFaaliyet eklenecek)
        {
            //Yeni veri id si service tarafından atanmaktadır.
            //VMFaaliyet to StFaaliyet
            var model = new StFaaliyet()
            {
                Id = eklenecek.id,
                OlusturmaTarihi = DateTime.Now,
                Deleted = (bool)eklenecek.Deleted,
                FaaliyetlerId = eklenecek.FaaliyetlerId,
                Deger = eklenecek.Deger,
                FaaliyetId=eklenecek.id

            };
            try
            {
                _faaliyet.YeniFaaliyetEkle(model);
                return new ABBJsonResponse("FaaliyetController/ Kayıt Başarıyla Eklendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("UpdateaFaaliyet")]
        public IActionResult FaaliyetGuncelle(VMFaaliyet guncellenecek)
        {
            var model = new StFaaliyet()
            {
                Id = guncellenecek.id,
                OlusturmaTarihi = guncellenecek.OlusturmaTarihi,
                Deleted = (bool)guncellenecek.Deleted,
                FaaliyetlerId = guncellenecek.FaaliyetlerId,
                Deger = guncellenecek.Deger,
                FaaliyetId = guncellenecek.id
            };
            try
            {
                _faaliyet.TekFaaliyetGuncelle(model);
                return new ABBJsonResponse("FaaliyetController/ Araç Başarıyla Güncellendi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            }
        }
        [HttpPost("DeleteaFaaliyet")]
        public IActionResult FaaliyetSil(VMFaaliyet silinecek)
        {
            StFaaliyet model = _faaliyet.Getir(faaliyet => faaliyet.Id == silinecek.id);
            model.Deleted = true;
            try
            {
                _faaliyet.TekFaaliyetGuncelle(model);
                return new ABBJsonResponse("FaaliyetController/ Araç Başarıyla Silindi");
            }
            catch (Exception e)
            {
                return new ABBErrorJsonResponse(e.Message);
            };
        }
    }
}
