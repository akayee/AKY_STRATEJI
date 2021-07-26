using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class StFaaliyetler
    {
        public StFaaliyetler()
        {
            StFaaliyets = new HashSet<StFaaliyet>();
            StIsturleris = new HashSet<StIsturleri>();
            StratejiyiliFaaliyetlers = new HashSet<StratejiyiliFaaliyetler>();
        }

        public int Id { get; set; }
        public string Aciklama { get; set; }
        public string Adi { get; set; }
        public int OlcuBirimi { get; set; }
        public int? YillikHedefId { get; set; }
        public int PerformansId { get; set; }
        public int BirimId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int FaaliyetlerId { get; set; }
        public bool? Deleted { get; set; }
        public int? IsTuruId { get; set; }

        public virtual BrBirimler Birim { get; set; }
        public virtual StIsturleri IsTuru { get; set; }
        public virtual GnOlcubirimi OlcuBirimiNavigation { get; set; }
        public virtual StPerformanslar Performans { get; set; }
        public virtual StYillikhedef YillikHedef { get; set; }
        public virtual ICollection<StFaaliyet> StFaaliyets { get; set; }
        public virtual ICollection<StIsturleri> StIsturleris { get; set; }
        public virtual ICollection<StratejiyiliFaaliyetler> StratejiyiliFaaliyetlers { get; set; }
    }
}
