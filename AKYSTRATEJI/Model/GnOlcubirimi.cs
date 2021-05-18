using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class GnOlcubirimi
    {
        public GnOlcubirimi()
        {
            FlFaaliyetturleris = new HashSet<FlFaaliyetturleri>();
            StFaalİyetlers = new HashSet<StFaalİyetler>();
            StIsturlerİs = new HashSet<StIsturlerİ>();
        }

        public int Id { get; set; }
        public string Tanim { get; set; }

        public virtual ICollection<FlFaaliyetturleri> FlFaaliyetturleris { get; set; }
        public virtual ICollection<StFaalİyetler> StFaalİyetlers { get; set; }
        public virtual ICollection<StIsturlerİ> StIsturlerİs { get; set; }
    }
}
