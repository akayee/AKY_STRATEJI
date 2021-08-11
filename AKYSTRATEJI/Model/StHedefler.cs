using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class StHedefler
    {
        public StHedefler()
        {
            StPerformanslars = new HashSet<StPerformanslar>();
            StStratejireleations = new HashSet<StStratejireleation>();
        }

        public int Id { get; set; }
        public string Tanim { get; set; }
        public int AmaclarId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int HedeflerId { get; set; }
        public bool? Deleted { get; set; }

        public virtual StAmaclar Amaclar { get; set; }
        public virtual ICollection<StPerformanslar> StPerformanslars { get; set; }
        public virtual ICollection<StStratejireleation> StStratejireleations { get; set; }
    }
}
