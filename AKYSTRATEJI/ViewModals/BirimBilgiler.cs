using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class BirimBilgiler
    {
        public VMAraclar AracListesi { get; set; }
        public VMBirimler Birim { get; set; }
        public VMBirimler UstBirim { get; set; }
        public VMDonanimlar Donanimlar { get; set; }
        public VMFizikselYapilar FizikselYapilar { get; set; }
        public VMMevzuatlar Mevzuatlar { get; set; }
        public VMPerformanslar Personeller { get; set; }
        public VMYazilimlar Yazilimlar { get; set; }
        public VMYetkiGorevTanimlari YetkiGorevTanimlari { get; set; }
    }
}
