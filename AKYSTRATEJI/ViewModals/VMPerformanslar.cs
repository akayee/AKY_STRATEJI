using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMPerformanslar
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public int HedeflerId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public bool Deleted { get; set; }
        public int PerformanslarId { get; set; }
        public string HedefAdi { get; set; }
        public int AmaclarId { get; set; }
        public string AmacAdi { get; set; }
    }
}
