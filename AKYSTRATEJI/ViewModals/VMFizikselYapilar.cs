using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMFizikselYapilar
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public string Konum { get; set; }
        public int MetreKare { get; set; }
        public int BirimId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public VMBirimler Birim { get; set; }
    }
}
