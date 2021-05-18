using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class StIsturlerİ
    {
        public StIsturlerİ()
        {
            StIslers = new HashSet<StIsler>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public int OlcuBirimi { get; set; }
        public int YillikHedefId { get; set; }
        public int PerformansId { get; set; }
        public int BirimId { get; set; }
        public int? Maaliyet { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int IsTurleriId { get; set; }

        public virtual BrBirimler Birim { get; set; }
        public virtual GnOlcubirimi OlcuBirimiNavigation { get; set; }
        public virtual StPerformanslar Performans { get; set; }
        public virtual StYillikhedef YillikHedef { get; set; }
        public virtual ICollection<StIsler> StIslers { get; set; }
    }
}
