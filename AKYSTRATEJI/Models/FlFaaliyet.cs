using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Models
{
    public partial class FlFaaliyet
    {
        public int Id { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int Deger { get; set; }
        public byte? Ilce { get; set; }
        public short? Mahalle { get; set; }
        public int FaaliyetId { get; set; }
        public int FaaliyetTurleriId { get; set; }

        public virtual FlFaaliyetturleri FaaliyetTurleri { get; set; }
    }
}
