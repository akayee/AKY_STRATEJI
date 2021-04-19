using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMKullanicilarBirimler
    {
        public int BirimId { get; set; }
        public int KullaniciId { get; set; }
        public VMBirimler Birim { get; set; }
        public VMKullanicilar Kullanici { get; set; }
    }
}
