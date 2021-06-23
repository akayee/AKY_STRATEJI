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
        public AmaclarController(ILogger<AmaclarController> logger, IAmaclarService amaclar)
        {
            _logger = logger;
            _amaclar = amaclar;
        }

        [HttpGet]
        public JsonResult GetAmaclar()
        {
            int id = 1;
            var amaclar = _amaclar.AmacGetir(id);

            return new JsonResult(amaclar);
        }
    }
}
