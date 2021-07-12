using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMFaaliyet
    {
        public int id { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int Deger { get; set; }
        public bool GelirGider { get; set; }
        public bool Deleted { get; set; }
        public int FaaliyetlerId { get; set; }
        public VMFaaliyetTurleri FaaliyetTurleri { get; set; }
    }
}
