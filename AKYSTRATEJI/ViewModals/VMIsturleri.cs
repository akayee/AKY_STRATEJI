using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMIsturleri
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public int YillikHedef { get; set; }
        public int IsturleriId { get; set; }
        public int PerformansId { get; set; }
        public bool Deleted { get; set; }
        public int ToplamDeger { get; set; }
        public int FirstPart { get; set; }
        public int SecondPart { get; set; }
        public int ThirdPart { get; set; }
        public int LastPart { get; set; }
        public int BirimId { get; set; }
        public int? Maaliyet { get; set; }
        public int OlcuBirimiId { get; set; }
        public string  OlcuBirimiTanimi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }

    }
}
