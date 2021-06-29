using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMKullanicilar
    {
        public int id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Password { get; set; }
        public int? PersonelId { get; set; }
        public int? YetkiGruplariId { get; set; }
        public bool Deleted { get; set; }
        public VMKullanicilarBirimler KullaniciBirimleri { get; set; }
        public VMYetkiGruplari YetkiGruplari { get; set; }
        public VMPersoneller PersonelBilgisi { get; set; }
    }
}
