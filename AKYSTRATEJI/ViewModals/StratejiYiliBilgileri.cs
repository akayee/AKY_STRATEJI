using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class StratejiYiliBilgileri
    {
        public List<VMPerformanslar> Performanslar { get; set; }
        public List<VMAmaclar> Amaclar { get; set; }
        public List<VMHedefler> Hedefler { get; set; }
        public List<VMIsturleri> Isturleri { get; set; }
        public List<VMFaaliyetTurleri> VMFaaliyetTurleri { get; set; }
    }
}
