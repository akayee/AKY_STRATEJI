
using AKYSTRATEJI.ViewModals;
using BL.Abstract;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace WebAppAKY.Controller
{
    [Authorize]
    class HomeController: ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStratejiServis _stratejiServis;
        public HomeController(ILogger<HomeController> logger,IStratejiServis stratejiServis)
        {
            _logger = logger;
            _stratejiServis = stratejiServis;
        }

        public IActionResult StratejiBilgileriGetir()
        {
            var model = new StratejiBilgileri()
            {

            };
            return View(model);

        }

        private IActionResult View(StratejiBilgileri model)
        {
            throw new NotImplementedException();
        }
    }
}
