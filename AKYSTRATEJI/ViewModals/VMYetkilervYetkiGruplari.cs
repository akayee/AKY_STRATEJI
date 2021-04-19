using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMYetkilervYetkiGruplari
    {
        public int YetkiGruplariId { get; set; }
        public int YetkilerId { get; set; }
        public VMYetkiGruplari YetkiGruplari { get; set; }
        public VMYetkiler Yetkiler { get; set; }
    }
}
