using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Models
{
    public partial class StYillikhedef
    {
        public StYillikhedef()
        {
            StFaalİyetlers = new HashSet<StFaalİyetler>();
            StIsturlerİs = new HashSet<StIsturlerİ>();
        }

        public int Id { get; set; }
        public int YillikHedefId { get; set; }
        public int Yil { get; set; }
        public int Hedef { get; set; }
        public int? HedefN { get; set; }
        public int? HedefNn { get; set; }
        public DateTime OlusturmaTarihi { get; set; }

        public virtual ICollection<StFaalİyetler> StFaalİyetlers { get; set; }
        public virtual ICollection<StIsturlerİ> StIsturlerİs { get; set; }
    }
}
