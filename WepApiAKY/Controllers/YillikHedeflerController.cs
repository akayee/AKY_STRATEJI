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
    public class YillikHedeflerController:ControllerBase
    {
        private readonly ILogger<YillikHedeflerController> _logger;

        private readonly IYillikHedefServices _yillikhedefService;

        public YillikHedeflerController(ILogger<YillikHedeflerController> logger, IYillikHedefServices yillikhedefService)
        {
            _logger = logger;
            _yillikhedefService = yillikhedefService;
        }

        [HttpGet]
        public JsonResult YillikHedefGetir(int id)
        {
            //Tek yıllık hedef getirme.

            StYillikhedef getirelecekveri = _yillikhedefService.TekYillikHedefGetir(id);

            var model = new VMYillikHedefler()
            {
                id = getirelecekveri.Id,
                Deleted = (bool)getirelecekveri.Deleted,
                Hedef=getirelecekveri.Hedef,
                HedefN=getirelecekveri.HedefN,
                HedefNN=getirelecekveri.HedefNn,
                OlusturmaTarihi=getirelecekveri.OlusturmaTarihi,
                Yil=getirelecekveri.Yil
            };
            return new JsonResult(model);
        }
    }
}
