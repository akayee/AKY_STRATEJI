using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMFaaliyetTurleri
    {
        public int id { get; set; }
        public string Aciklama { get; set; }
        public int? Hedef { get; set; }
        public int BirimId { get; set; }
        public int? Maaliyet { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public bool Deleted { get; set; }
        public int IsturleriId { get; set; }
        public VMBirimler Birim { get; set; }
        public VMOlcuBirimi OlcuBirimi { get; set; }
        public List<VMFaaliyet> Faaliyets { get; set; }
    }
}
