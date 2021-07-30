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


    }
}
