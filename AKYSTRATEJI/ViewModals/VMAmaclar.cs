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
        public int Yil { get; set; }
        public bool Deleted { get; set; }
    }
}
