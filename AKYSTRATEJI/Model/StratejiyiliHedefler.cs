using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class StratejiyiliHedefler
    {
        public int HedeflerId { get; set; }
        public int StratejiyiliId { get; set; }

        public virtual StHedefler Hedefler { get; set; }
        public virtual StStratejiyili Stratejiyili { get; set; }
    }
}
