using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMMaliFaaliyetTurleri
    {
        public int id { get; set; }
        public string Aciklama { get; set; }
        public string Adi { get; set; }
        public int OlcuBirimiId { get; set; }
        public int YillikHedefId { get; set; }
        public int PerformansId { get; set; }
        public int BirimId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int MaliFaaliyetId { get; set; }
        public VMBirimler Birim { get; set; }
        public List<VMMaliFaaliyet> Faaliyetler { get; set; }
        public VMPerformanslar Performans { get; set; }
        public VMYillikHedefler YillikHedef { get; set; }
        public VMOlcuBirimi OlcuBirimi { get; set; }
    }
}
