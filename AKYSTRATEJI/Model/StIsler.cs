using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class StIsler
    {
        public int Id { get; set; }
        public int IsTuruId { get; set; }
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int Deger { get; set; }
        public int? Ilce { get; set; }
        public int? Mahalle { get; set; }
        public int IslerId { get; set; }
        public bool? Deleted { get; set; }

        public virtual StIsturleri IsTuru { get; set; }
    }
}
