using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using BL.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class HedeflerServices : ABBEntityServis<StHedefler, AKYSTRATEJIContext>, IHedeflerServices
    {
        private readonly ILogger<HedeflerServices> _logger;

        public HedeflerServices(ILogger<HedeflerServices> logger) : base(logger)
        {
            _logger = logger;
        }
        public StHedefler Getir(int hedefId)
        {
            return Getir(i => i.Id == hedefId);
        }

        public List<StHedefler> Listele()
        {
            return DetayliListe();
        }

        public override void Validate(StHedefler entity)
        {
            throw new NotImplementedException();
        }
    }
}
