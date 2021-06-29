﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Model
{
    public partial class StAmaclar
    {
        public StAmaclar()
        {
            StHedeflers = new HashSet<StHedefler>();
            StratejiyiliAmaclars = new HashSet<StratejiyiliAmaclar>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int AmacId { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<StHedefler> StHedeflers { get; set; }
        public virtual ICollection<StratejiyiliAmaclar> StratejiyiliAmaclars { get; set; }
    }
}
