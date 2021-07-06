﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class StYillikhedef
    {
        public StYillikhedef()
        {
            StIsturleris = new HashSet<StIsturleri>();
        }

        public int Id { get; set; }
        public int YillikHedefId { get; set; }
        public int Yil { get; set; }
        public int Hedef { get; set; }
        public int? HedefN { get; set; }
        public int? HedefNn { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int FaaliyetId { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<StIsturleri> StIsturleris { get; set; }
    }
}
