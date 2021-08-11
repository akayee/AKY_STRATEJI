using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class StPerformanslar
    {
        public StPerformanslar()
        {
            StFaaliyetlers = new HashSet<StFaaliyetler>();
            StIsturleris = new HashSet<StIsturleri>();
            StStratejireleations = new HashSet<StStratejireleation>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public int HedeflerId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int PerformanslarId { get; set; }
        public bool? Deleted { get; set; }

        public virtual StHedefler Hedefler { get; set; }
        public virtual ICollection<StFaaliyetler> StFaaliyetlers { get; set; }
        public virtual ICollection<StIsturleri> StIsturleris { get; set; }
        public virtual ICollection<StStratejireleation> StStratejireleations { get; set; }
    }
}
