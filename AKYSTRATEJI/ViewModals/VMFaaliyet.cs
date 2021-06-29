using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMFaaliyet
    {
        public int id { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int Deger { get; set; }
        public enums.Ilceler Ilce { get; set; }
        public enums.Mahalleler Mahalle { get; set; }
        public bool Deleted { get; set; }
        public VMFaaliyetTurleri FaaliyetTurleri { get; set; }
    }
}
