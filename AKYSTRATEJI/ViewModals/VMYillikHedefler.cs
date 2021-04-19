using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMYillikHedefler
    {
        public int id { get; set; }
        public int Yil { get; set; }
        public int Hedef { get; set; }
        public int? HedefN { get; set; }
        public int? HedefNN { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public List<VMMaliFaaliyetTurleri> MaliFaaliyetler { get; set; }
        public List<VMIsturleri> IsTurleri { get; set; }

    }
}
