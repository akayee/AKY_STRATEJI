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
        private readonly IPerformanslarServices _performanslar;
        private readonly IStratejiRelationServices _stratejiRelations;
        private readonly IFaaliyetTurleriServices _faaliyetturleriServices;
        private readonly IIsturleriServices _isturleriServices;
        private readonly IOlcuBirimiServices _olcubirimi;
        public AmaclarController(ILogger<AmaclarController> logger, IAmaclarService amaclar ,IStratejiRelationServices relations, IPerformanslarServices performanslar,IOlcuBirimiServices olcubirimi,IIsturleriServices isTurleri,IFaaliyetTurleriServices faaliyetTurleri)
        {
            _logger = logger;
            _amaclar = amaclar;
            _stratejiRelations = relations;
            _performanslar = performanslar;
            _olcubirimi = olcubirimi;
            _faaliyetturleriServices = faaliyetTurleri;
            _isturleriServices = isTurleri;
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
        [HttpGet("GetListOfTumStrateji")]
        public JsonResult TumStratejiyiListele()
        {
            //Veritabanından StAmaclar tablosunun listesini almaişlemi.
            List<StAmaclar> amaclar = _amaclar.Listele(obj => obj.Deleted != true, obj => obj.StHedeflers);
            List<VMAmaclar> vMAmaclars = new List<VMAmaclar>();
            List<VMHedefler> vmHedeflers = new List<VMHedefler>();
            List<VMPerformanslar> vMPerformanslars = new List<VMPerformanslar>();
            List<VMFaaliyetTurleri> vMFaaliyetTurleris = new List<VMFaaliyetTurleri>();
            List<VMIsturleri> vMIsturleris = new List<VMIsturleri>();
            foreach (StAmaclar amac in amaclar)
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
                foreach(StHedefler hedef in amac.StHedeflers)
                {
                    VMHedefler vmhedef = new VMHedefler()
                    {
                        AmaclarId=hedef.AmaclarId,
                        Deleted=(bool)hedef.Deleted,
                        id=hedef.Id,
                        OlusturmaTarihi=hedef.OlusturmaTarihi,
                        Tanim=hedef.Tanim
                    };
                    vmHedeflers.Add(vmhedef);
                }
            }

            List<StPerformanslar> stPerformanslars = _performanslar.Liste(obj => obj.Deleted != true, obj => obj.StFaaliyetlers, obj => obj.StIsturleris);
            foreach(StPerformanslar performans in stPerformanslars)
            {
                VMPerformanslar vmperfor = new VMPerformanslar()
                {
                    Adi=performans.Adi,
                    Deleted=(bool)performans.Deleted,
                    id=performans.Id,
                    HedeflerId=performans.HedeflerId,
                    OlusturmaTarihi=performans.OlusturmaTarihi
                };
                vMPerformanslars.Add(vmperfor);
                foreach(StFaaliyetler faaliyet in performans.StFaaliyetlers)
                {
                    VMFaaliyetTurleri vmfaaliyet = new VMFaaliyetTurleri()
                    {
                        Aciklama=faaliyet.Aciklama,
                        Adi=faaliyet.Adi,
                        BirimId=faaliyet.BirimId,
                        Deleted=(bool)faaliyet.Deleted,
                        id=faaliyet.Id,
                        OlcuBirimiId=faaliyet.OlcuBirimi,
                        OlcuBirimiTanimi= _olcubirimi.TekOlcuBirimiGetir(faaliyet.OlcuBirimi).Tanim,
                        PerformansId=faaliyet.PerformansId
                    };
                    vMFaaliyetTurleris.Add(vmfaaliyet);
                }
                foreach (StIsturleri isturu in performans.StIsturleris)
                {
                    VMIsturleri vmisturu = new VMIsturleri()
                    {
                        Aciklama = isturu.Aciklama,
                        Adi = isturu.Adi,
                        BirimId = isturu.BirimId,
                        Deleted = (bool)isturu.Deleted,
                        id = isturu.Id,
                        OlcuBirimi=isturu.OlcuBirimi,
                        OlcuBirimiTanimi = _olcubirimi.TekOlcuBirimiGetir(isturu.OlcuBirimi).Tanim,
                        PerformansId=isturu.PerformansId,
                    };
                    vMIsturleris.Add(vmisturu);
                }
            }
            StratejiBilgileri stratejibilgileri = new StratejiBilgileri()
            {
                VMFaaliyetTurleri = vMFaaliyetTurleris,
                Hedefler = vmHedeflers,
                StratejikAmac= vMAmaclars,
                Isturleri=vMIsturleris,
                Performanslar=vMPerformanslars
            };
            return new JsonResult(stratejibilgileri);
        }

        [HttpGet("GetListOfFaaliyetRaporu")]
        public JsonResult TumFaaliyetRaporu()
        {
            //Veritabanından StAmaclar tablosunun listesini almaişlemi.
            List<StAmaclar> amaclar = _amaclar.Listele(obj => obj.Deleted != true, obj => obj.StHedeflers);
            List<VMAmaclar> vMAmaclars = new List<VMAmaclar>();
            List<VMHedefler> vmHedeflers = new List<VMHedefler>();
            List<VMPerformanslar> vMPerformanslars = new List<VMPerformanslar>();
            List<VMFaaliyetTurleri> vMFaaliyetTurleris = new List<VMFaaliyetTurleri>();
            List<VMIsturleri> vMIsturleris = new List<VMIsturleri>();
            List<VMFaaliyet> VMfaaliyetler = new List<VMFaaliyet>();
            List<VMIsler> VMisler = new List<VMIsler>();
            foreach (StAmaclar amac in amaclar)
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
                foreach (StHedefler hedef in amac.StHedeflers)
                {
                    VMHedefler vmhedef = new VMHedefler()
                    {
                        AmaclarId = hedef.AmaclarId,
                        Deleted = (bool)hedef.Deleted,
                        id = hedef.Id,
                        OlusturmaTarihi = hedef.OlusturmaTarihi,
                        Tanim = hedef.Tanim
                    };
                    vmHedeflers.Add(vmhedef);
                }
            }

            List<StPerformanslar> stPerformanslars = _performanslar.Liste(obj => obj.Deleted != true, obj => obj.StFaaliyetlers, obj => obj.StIsturleris);
            foreach (StPerformanslar performans in stPerformanslars)
            {
                VMPerformanslar vmperfor = new VMPerformanslar()
                {
                    Adi = performans.Adi,
                    Deleted = (bool)performans.Deleted,
                    id = performans.Id,
                    HedeflerId = performans.HedeflerId,
                    OlusturmaTarihi = performans.OlusturmaTarihi
                };
                vMPerformanslars.Add(vmperfor);
                foreach(StFaaliyetler stfaaliyet in performans.StFaaliyetlers)
                {
                    foreach(VMFaaliyetTurleri faaliyet in _faaliyetturleriServices.FaaliyetRaporuHesapla(stfaaliyet.Id))
                    {
                        vMFaaliyetTurleris.Add(faaliyet);
                    }
                }
                foreach (StIsturleri stisturu in performans.StIsturleris)
                {
                    foreach (VMIsturleri isturu in _isturleriServices.FaaliyetRaporuHesapla(stisturu.Id))
                    {
                        vMIsturleris.Add(isturu);
                    }

                }

                foreach (VMIsturleri isturu in _isturleriServices.FaaliyetRaporuHesapla(performans.Id))
                {
                    vMIsturleris.Add(isturu);
                }
                    
            }
            StratejiBilgileri stratejibilgileri = new StratejiBilgileri()
            {
                VMFaaliyetTurleri = vMFaaliyetTurleris,
                Hedefler = vmHedeflers,
                StratejikAmac = vMAmaclars,
                Isturleri = vMIsturleris,
                Performanslar = vMPerformanslars
            };
            return new JsonResult(stratejibilgileri);
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
                return new JsonResult("Stratejik Amaç Başarıyla Güncellendi");
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
