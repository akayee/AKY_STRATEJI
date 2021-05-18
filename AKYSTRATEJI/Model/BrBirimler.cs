using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class BrBirimler
    {
        public BrBirimler()
        {
            BrAraclars = new HashSet<BrAraclar>();
            BrDonanimlars = new HashSet<BrDonanimlar>();
            BrFizikselYapilars = new HashSet<BrFizikselYapilar>();
            BrMevzuatlars = new HashSet<BrMevzuatlar>();
            BrPersonellers = new HashSet<BrPersoneller>();
            BrYazilimlars = new HashSet<BrYazilimlar>();
            BrYetkiGorevTanimlaris = new HashSet<BrYetkiGorevTanimlari>();
            FlFaaliyetturleris = new HashSet<FlFaaliyetturleri>();
            KullanicilarBirimlers = new HashSet<KullanicilarBirimler>();
            StFaalİyetlers = new HashSet<StFaalİyetler>();
            StIsturlerİs = new HashSet<StIsturlerİ>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public int? UstBirimId { get; set; }
        public DateTime OlustumraTarihi { get; set; }
        public int BirimId { get; set; }
        public int? BirimTipiId { get; set; }

        public virtual BrBirimtipleri BirimTipi { get; set; }
        public virtual ICollection<BrAraclar> BrAraclars { get; set; }
        public virtual ICollection<BrDonanimlar> BrDonanimlars { get; set; }
        public virtual ICollection<BrFizikselYapilar> BrFizikselYapilars { get; set; }
        public virtual ICollection<BrMevzuatlar> BrMevzuatlars { get; set; }
        public virtual ICollection<BrPersoneller> BrPersonellers { get; set; }
        public virtual ICollection<BrYazilimlar> BrYazilimlars { get; set; }
        public virtual ICollection<BrYetkiGorevTanimlari> BrYetkiGorevTanimlaris { get; set; }
        public virtual ICollection<FlFaaliyetturleri> FlFaaliyetturleris { get; set; }
        public virtual ICollection<KullanicilarBirimler> KullanicilarBirimlers { get; set; }
        public virtual ICollection<StFaalİyetler> StFaalİyetlers { get; set; }
        public virtual ICollection<StIsturlerİ> StIsturlerİs { get; set; }
    }
}
