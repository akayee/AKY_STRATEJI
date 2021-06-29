using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class BrFizikselYapilar
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Konum { get; set; }
        public int MetreKare { get; set; }
        public int BirimId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int FizikselYapiId { get; set; }
        public bool? Deleted { get; set; }

        public virtual BrBirimler Birim { get; set; }
    }
}
