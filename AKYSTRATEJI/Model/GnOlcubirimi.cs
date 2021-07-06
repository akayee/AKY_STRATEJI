using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class GnOlcubirimi
    {
        public GnOlcubirimi()
        {
            StFaaliyetlers = new HashSet<StFaaliyetler>();
            StIsturleris = new HashSet<StIsturleri>();
        }

        public int Id { get; set; }
        public string Tanim { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<StFaaliyetler> StFaaliyetlers { get; set; }
        public virtual ICollection<StIsturleri> StIsturleris { get; set; }
    }
}
