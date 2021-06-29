using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class StratejiyiliAmaclar
    {
        public int AmaclarId { get; set; }
        public int StratejiyiliId { get; set; }
        public bool? Deleted { get; set; }

        public virtual StAmaclar Amaclar { get; set; }
        public virtual StStratejiyili Stratejiyili { get; set; }
    }
}
