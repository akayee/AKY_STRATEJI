using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMBirimler
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public int UstBirimId { get; set; }
        public bool Deleted { get; set; }
        public int BirimTipiId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public List<VMAraclar> Araclar { get; set; }
        public List<VMDonanimlar> Donanimlar { get; set; }
        public List<VMFizikselYapilar> FizikselYapilar { get; set; }
        public List<VMMevzuatlar> Mevzuatlar { get; set; }
        public List<VMPersoneller> Personeller { get; set; }
        public List<VMYazilimlar> Yazilimlar { get; set; }
        public List<VMYetkiGorevTanimlari> YetkiGorevTanimlari { get; set; }
        public List<VMFaaliyetTurleri> FaaliyetTurleri { get; set; }
        public List<VMKullanicilar> Kullanicilar { get; set; }
        public List<VMIsturleri> Isturleri { get; set; }


    }
}
