using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Models
{
    public partial class BrAraclar
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public decimal Cinsi { get; set; }
        public decimal TahsisTuru { get; set; }
        public int BirimId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int AracId { get; set; }

        public virtual BrBirimler Birim { get; set; }
    }
}
