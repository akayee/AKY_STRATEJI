using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class StStratejiyili
    {
        public StStratejiyili()
        {
            StStratejireleations = new HashSet<StStratejireleation>();
        }

        public int Id { get; set; }
        public int Yil { get; set; }
        public bool Deleted { get; set; }
        public DateTime OlusturmaTarihi { get; set; }

        public virtual ICollection<StStratejireleation> StStratejireleations { get; set; }
    }
}
