using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Models
{
    public partial class StHedefler
    {
        public StHedefler()
        {
            StPerformanslars = new HashSet<StPerformanslar>();
        }

        public int Id { get; set; }
        public string Tanim { get; set; }
        public int AmaclarId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int HedeflerId { get; set; }

        public virtual StAmaclar Amaclar { get; set; }
        public virtual ICollection<StPerformanslar> StPerformanslars { get; set; }
    }
}
