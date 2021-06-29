using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class StratejiyiliIsturleri
    {
        public int IsturuId { get; set; }
        public int StratejiyiliId { get; set; }
        public bool? Deleted { get; set; }

        public virtual StIsturlerİ Isturu { get; set; }
        public virtual StStratejiyili Stratejiyili { get; set; }
    }
}
