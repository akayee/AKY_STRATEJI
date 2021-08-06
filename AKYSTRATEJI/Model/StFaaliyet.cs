using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class StFaaliyet
    {
        public int Id { get; set; }
        public int Deger { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int FaaliyetlerId { get; set; }
        public int FaaliyetId { get; set; }
        public bool? Deleted { get; set; }

        public virtual StFaaliyetler Faaliyetler { get; set; }
    }
}
