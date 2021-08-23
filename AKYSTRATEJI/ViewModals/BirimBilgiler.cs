using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class BirimBilgiler
    {
        public List<VMAraclar> AracListesi { get; set; }
        public VMBirimler Birim { get; set; }
        public List<VMBirimler> YetkiliOlduguBirimler { get; set; }
        public List<VMDonanimlar> Donanimlar { get; set; }
        public List<VMFizikselYapilar> FizikselYapilar { get; set; }
        public List<VMMevzuatlar> Mevzuatlar { get; set; }
        public List<VMPersoneller> Personeller { get; set; }
        public List<VMYazilimlar> Yazilimlar { get; set; }
        public List<VMYetkiGorevTanimlari> YetkiGorevTanimlari { get; set; }
    }
}
