using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class BrYazilimlar
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public int BirimId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int YazilimId { get; set; }
        public bool? Deleted { get; set; }

        public virtual BrBirimler Birim { get; set; }
    }
}
