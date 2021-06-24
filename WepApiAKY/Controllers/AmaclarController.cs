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
        private readonly ILogger<AmaclarController> _logger;
        private readonly IAmaclarService _amaclar;
        private readonly IMapper _mapper;
        public AmaclarController(ILogger<AmaclarController> logger, IAmaclarService amaclar)
        {
            _logger = logger;
            _amaclar = amaclar;
        }

        [HttpGet]
        public JsonResult GetAmaclar()
        {
            int id = 1;
            StAmaclar amaclar = _amaclar.AmacGetir(id);
            var model = new VMAmaclar(){
                id = amaclar.AmacId,
                Adi = amaclar.Adi,
                OlusturmaTarihi = amaclar.OlusturmaTarihi
           };
            

            return new JsonResult(model);
        }
        [HttpGet("GetAll")]
        public JsonResult AmacListe()
        {
            List<StAmaclar> amaclar = _amaclar.DetayliListe();

            return new JsonResult(amaclar);
        }
    }
}
