using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class StratejiyiliFaaliyetler
    {
        public int FaaliyetId { get; set; }
        public int StratejiyiliId { get; set; }

        public virtual StFaalİyetler Faaliyet { get; set; }
        public virtual StStratejiyili Stratejiyili { get; set; }
    }
}
