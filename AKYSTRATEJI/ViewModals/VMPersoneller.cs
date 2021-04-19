using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMPersoneller
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public enums.Kadrolar Kadro { get; set; }
        public enums.Mezuniyet Mezuniyet { get; set; }
        public int BirimId { get; set; }
        public bool Cinsiyet { get; set; }
        public DateTime IseGirisTarihi { get; set; }
        public enums.Unvanlar Unvan { get; set; }
        public DateTime DogumTarihi { get; set; }
        public short Tel { get; set; }
        public int KullaniciId { get; set; }
        public VMBirimler Birim { get; set; }
    }
}
