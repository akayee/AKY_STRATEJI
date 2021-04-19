using System;
using System.Collections.Generic;

#nullable disable

namespace AKYSTRATEJI.Models
{
    public partial class YtYetkilerYetkigruplari
    {
        public int YetkiGruplariId { get; set; }
        public int YetkilerId { get; set; }

        public virtual YtYetkigruplari YetkiGruplari { get; set; }
        public virtual YtYetkiler Yetkiler { get; set; }
    }
}
