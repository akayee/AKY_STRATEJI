using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class StratejiBilgileri
    {
        public List<VMBirimler> YetkiliBirimler { get; set; }

        public List<VMPerformanslar> Performanslar { get; set; }
        public List<VMAmaclar> StratejikAmac { get; set; }
        public List<VMHedefler> Hedefler { get; set; }
        public List<VMIsturleri> Isturleri { get; set; }
        public List<VMIsler> Isler { get; set; }
        public List<VMFaaliyetTurleri> VMFaaliyetTurleri { get; set; }
        public List<VMFaaliyet> Faaliyetler { get; set; }
        public VMBirimler UstBirim { get; set; }

    }
}
