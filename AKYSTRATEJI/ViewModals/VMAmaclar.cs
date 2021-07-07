using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMAmaclar
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public bool Deleted { get; set; }
        public List<VMHedefler> Hedefler { get; set; }
        public VMStratejiYili StratejiYili{ get; set; }
    }
}
