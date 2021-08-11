using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class StStratejireleation
    {
        public int Id { get; set; }
        public int? FaaliyetId { get; set; }
        public int? AmacId { get; set; }
        public int? HedefId { get; set; }
        public int? PerformansId { get; set; }
        public int? IsturuId { get; set; }
        public int? YillikHedefId { get; set; }
        public int StratejiYiliId { get; set; }
        public bool Deleted { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int? OlusturanKullanici { get; set; }

        public virtual StAmaclar Amac { get; set; }
        public virtual StFaaliyetler Faaliyet { get; set; }
        public virtual StHedefler Hedef { get; set; }
        public virtual StIsturleri Isturu { get; set; }
        public virtual StPerformanslar Performans { get; set; }
        public virtual StStratejiyili StratejiYili { get; set; }
        public virtual StYillikhedef YillikHedef { get; set; }
    }
}
