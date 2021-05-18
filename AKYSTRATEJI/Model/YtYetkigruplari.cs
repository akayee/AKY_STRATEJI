using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class YtYetkigruplari
    {
        public YtYetkigruplari()
        {
            Kullanicilars = new HashSet<Kullanicilar>();
            YtYetkilerYetkigruplaris = new HashSet<YtYetkilerYetkigruplari>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public int YetkilerId { get; set; }

        public virtual ICollection<Kullanicilar> Kullanicilars { get; set; }
        public virtual ICollection<YtYetkilerYetkigruplari> YtYetkilerYetkigruplaris { get; set; }
    }
}
