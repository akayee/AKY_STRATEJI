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
        public decimal OlcuBirimi { get; set; }
        public int YillikHedefId { get; set; }
        public int PerformansId { get; set; }
        public bool Deleted { get; set; }
        public int BirimId { get; set; }
        public int? Maaliyet { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public VMBirimler Birim { get; set; }
        public List<VMIsler> Isler { get; set; }
        public VMPerformanslar Performans { get; set; }
        public VMYillikHedefler YillikHedef { get; set; }

    }
}
