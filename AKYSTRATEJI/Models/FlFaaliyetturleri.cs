using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Models
{
    public partial class FlFaaliyetturleri
    {
        public FlFaaliyetturleri()
        {
            FlFaaliyets = new HashSet<FlFaaliyet>();
        }

        public int Id { get; set; }
        public string Aciklama { get; set; }
        public string Adi { get; set; }
        public int? Hedef { get; set; }
        public int BirimId { get; set; }
        public int? Maaliyet { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int FaaliyetTuruId { get; set; }
        public int OlcuBirimi { get; set; }

        public virtual BrBirimler Birim { get; set; }
        public virtual GnOlcubirimi OlcuBirimiNavigation { get; set; }
        public virtual ICollection<FlFaaliyet> FlFaaliyets { get; set; }
    }
}
