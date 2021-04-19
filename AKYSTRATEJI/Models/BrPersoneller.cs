using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Models
{
    public partial class BrPersoneller
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public decimal Kadro { get; set; }
        public decimal? Mezuniyet { get; set; }
        public int BirimId { get; set; }
        public bool Cinsiyet { get; set; }
        public DateTime IseGirisTarihi { get; set; }
        public decimal? Unvan { get; set; }
        public DateTime DogumTarihi { get; set; }
        public short? Tel { get; set; }
        public int? KullaniciId { get; set; }
        public int PersonelId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }

        public virtual BrBirimler Birim { get; set; }
    }
}
