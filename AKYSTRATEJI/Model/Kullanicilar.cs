using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class Kullanicilar
    {
        public Kullanicilar()
        {
            KullanicilarBirimlers = new HashSet<KullanicilarBirimler>();
        }

        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public short KullaniciId { get; set; }
        public string Password { get; set; }
        public int? PersonelId { get; set; }
        public int? YetkiGruplariId { get; set; }

        public virtual YtYetkigruplari YetkiGruplari { get; set; }
        public virtual ICollection<KullanicilarBirimler> KullanicilarBirimlers { get; set; }
    }
}
