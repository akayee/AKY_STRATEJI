﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Models
{
    public partial class YtYetkiler
    {
        public YtYetkiler()
        {
            YtYetkilerYetkigruplaris = new HashSet<YtYetkilerYetkigruplari>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public bool Yetki { get; set; }
        public int YetkilerId { get; set; }

        public virtual ICollection<YtYetkilerYetkigruplari> YtYetkilerYetkigruplaris { get; set; }
    }
}
