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
        public int YillikHedefId { get; set; }
        public int PerformansId { get; set; }
        public bool Deleted { get; set; }
        public int BirimId { get; set; }
        public int? Maaliyet { get; set; }
        public int? FaaliyetId { get; set; }
        public int OlcuBirimiId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }

    }
}
