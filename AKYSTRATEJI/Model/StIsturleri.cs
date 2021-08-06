using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class StIsturleri
    {
        public StIsturleri()
        {
            StIslers = new HashSet<StIsler>();
            StYillikhedefs = new HashSet<StYillikhedef>();
            StratejiyiliIsturleris = new HashSet<StratejiyiliIsturleri>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public int OlcuBirimi { get; set; }
        public int PerformansId { get; set; }
        public int BirimId { get; set; }
        public int? Maaliyet { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int IsTurleriId { get; set; }
        public bool Strateji { get; set; }
        public bool? Deleted { get; set; }
        public int? FaaliyetlerId { get; set; }

        public virtual BrBirimler Birim { get; set; }
        public virtual StFaaliyetler Faaliyetler { get; set; }
        public virtual GnOlcubirimi OlcuBirimiNavigation { get; set; }
        public virtual StPerformanslar Performans { get; set; }
        public virtual ICollection<StIsler> StIslers { get; set; }
        public virtual ICollection<StYillikhedef> StYillikhedefs { get; set; }
        public virtual ICollection<StratejiyiliIsturleri> StratejiyiliIsturleris { get; set; }
    }
}
