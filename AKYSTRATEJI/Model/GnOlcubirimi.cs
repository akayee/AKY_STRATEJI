using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class GnOlcubirimi
    {
        public GnOlcubirimi()
        {
            StFaalİyetlers = new HashSet<StFaaliyetler>();
            StIsturlerİs = new HashSet<StIsturleri>();
        }

        public int Id { get; set; }
        public string Tanim { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<StFaaliyetler> StFaalİyetlers { get; set; }
        public virtual ICollection<StIsturleri> StIsturlerİs { get; set; }
    }
}
