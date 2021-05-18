using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class KullanicilarBirimler
    {
        public int BirimId { get; set; }
        public int KullaniciId { get; set; }

        public virtual BrBirimler Birim { get; set; }
        public virtual Kullanicilar Kullanici { get; set; }
    }
}
