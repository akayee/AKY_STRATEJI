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
        public VMHedefler Hedefler { get; set; }
        public List<VMIsturleri> IsTurleri { get; set; }
    }
}
