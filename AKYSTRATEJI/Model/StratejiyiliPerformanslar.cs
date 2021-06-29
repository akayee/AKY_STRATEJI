using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class StratejiyiliPerformanslar
    {
        public int PerformanslarId { get; set; }
        public int StratejiyiliId { get; set; }
        public bool? Deleted { get; set; }

        public virtual StPerformanslar Performanslar { get; set; }
        public virtual StStratejiyili Stratejiyili { get; set; }
    }
}
