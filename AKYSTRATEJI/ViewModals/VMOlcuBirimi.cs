using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMOlcuBirimi
    {
        public int id { get; set; }
        public string Tanim { get; set; }
        public bool Deleted { get; set; }
        public List<VMFaaliyetTurleri> Faaliyetler { get; set; }
        public List<VMMaliFaaliyetTurleri> MaliFaaliyetTurleri { get; set; }
        public List<VMIsturleri> Isturleri { get; set; }
    }
}
