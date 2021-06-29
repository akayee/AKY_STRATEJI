using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class BrBirimtipleri
    {
        public BrBirimtipleri()
        {
            BrBirimlers = new HashSet<BrBirimler>();
        }

        public int Id { get; set; }
        public string BirimTipi { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<BrBirimler> BrBirimlers { get; set; }
    }
}
