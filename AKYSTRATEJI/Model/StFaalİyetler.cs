﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class StFaalİyetler
    {
        public StFaalİyetler()
        {
            StFaalİyets = new HashSet<StFaalİyet>();
            StratejiyiliFaaliyetlers = new HashSet<StratejiyiliFaaliyetler>();
        }

        public int Id { get; set; }
        public string Aciklama { get; set; }
        public string Adi { get; set; }
        public int OlcuBirimi { get; set; }
        public int YillikHedefId { get; set; }
        public int PerformansId { get; set; }
        public int BirimId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int FaaliyetlerId { get; set; }

        public virtual BrBirimler Birim { get; set; }
        public virtual GnOlcubirimi OlcuBirimiNavigation { get; set; }
        public virtual StPerformanslar Performans { get; set; }
        public virtual ICollection<StFaalİyet> StFaalİyets { get; set; }
        public virtual ICollection<StratejiyiliFaaliyetler> StratejiyiliFaaliyetlers { get; set; }
    }
}
