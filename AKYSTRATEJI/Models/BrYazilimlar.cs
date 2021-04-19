using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Models
{
    public partial class BrYazilimlar
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public int BirimId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int YazilimId { get; set; }

        public virtual BrBirimler Birim { get; set; }
    }
}
