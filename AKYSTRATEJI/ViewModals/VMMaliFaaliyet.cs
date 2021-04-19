using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMMaliFaaliyet
    {
        public int id { get; set; }
        public int Deger { get; set; }
        public bool GelirGider { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public VMMaliFaaliyetTurleri MaliFaliyetTuru { get; set; }
    }
}
