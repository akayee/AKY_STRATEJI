using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMYillikHedefler
    {
        public int id { get; set; }
        public int Yil { get; set; }
        public int Hedef { get; set; }
        public int? HedefN { get; set; }
        public int? FaaliyetlerId { get; set; }
        public int? HedefNN { get; set; }
        public int? IsturuId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public bool Deleted { get; set; }

    }
}
