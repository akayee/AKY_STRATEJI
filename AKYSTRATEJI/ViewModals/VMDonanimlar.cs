using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMDonanimlar
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public short Sayi { get; set; }
        public VMBirimler Birim { get; set; }
        public int BirimId { get; set; }
        public bool Deleted { get; set; }
    }
}
