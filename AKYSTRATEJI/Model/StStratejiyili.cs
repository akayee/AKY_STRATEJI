using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class StStratejiyili
    {
        public StStratejiyili()
        {
            StratejiyiliAmaclars = new HashSet<StratejiyiliAmaclar>();
            StratejiyiliFaaliyetlers = new HashSet<StratejiyiliFaaliyetler>();
            StratejiyiliHedeflers = new HashSet<StratejiyiliHedefler>();
            StratejiyiliIsturleris = new HashSet<StratejiyiliIsturleri>();
            StratejiyiliPerformanslars = new HashSet<StratejiyiliPerformanslar>();
        }

        public int Id { get; set; }
        public int Yil { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<StratejiyiliAmaclar> StratejiyiliAmaclars { get; set; }
        public virtual ICollection<StratejiyiliFaaliyetler> StratejiyiliFaaliyetlers { get; set; }
        public virtual ICollection<StratejiyiliHedefler> StratejiyiliHedeflers { get; set; }
        public virtual ICollection<StratejiyiliIsturleri> StratejiyiliIsturleris { get; set; }
        public virtual ICollection<StratejiyiliPerformanslar> StratejiyiliPerformanslars { get; set; }
    }
}
