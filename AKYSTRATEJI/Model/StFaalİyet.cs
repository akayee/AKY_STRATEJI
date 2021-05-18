using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class StFaalİyet
    {
        public int Id { get; set; }
        public int Deger { get; set; }
        public bool GelirGider { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int FaaliyetlerId { get; set; }
        public int FaaliyetId { get; set; }

        public virtual StFaalİyetler Faaliyetler { get; set; }
    }
}
