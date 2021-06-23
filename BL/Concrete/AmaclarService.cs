using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using AKYSTRATEJI.ViewModals;
using BL.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class AmaclarService : ABBEntityServis<StAmaclar, AKYSTRATEJIContext>, IAmaclarService
    {
        private readonly ILogger<AmaclarService> _logger;

        public AmaclarService(ILogger<AmaclarService> logger) : base(logger)
        {
            _logger = logger;
        }

        public StAmaclar AmacGetir(int AmacId)
        {
            return Getir(amac => amac.Id == AmacId);
        }

        public override void Validate(StAmaclar entity)
        {
            throw new NotImplementedException();
        }
    }
}
