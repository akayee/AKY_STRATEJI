using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMYetkiGruplari
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public int YetkilerId { get; set; }
        public List<VMKullanicilar> Kullanicilar { get; set; }
        public List<VMYetkilervYetkiGruplari> YetkilervYetkiGruplaris { get; set; }
    }
}
