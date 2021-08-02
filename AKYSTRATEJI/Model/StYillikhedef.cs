using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class StYillikhedef
    {
        public int Id { get; set; }
        public int YillikHedefId { get; set; }
        public int Yil { get; set; }
        public int Hedef { get; set; }
        public int? HedefN { get; set; }
        public int? HedefNn { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int? FaaliyetId { get; set; }
        public bool? Deleted { get; set; }
        public int? IsTuruId { get; set; }

        public virtual StFaaliyetler Faaliyet { get; set; }
        public virtual StIsturleri IsTuru { get; set; }
    }
}
