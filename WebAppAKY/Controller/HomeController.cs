
using BL.Abstract;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAppAKY.Controller
{
    [Authorize]
    class HomeController: ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStratejiServis _stratejiServis;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


    }
}
