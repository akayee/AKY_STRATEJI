using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMAraclar
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public enums.AracCinsi AracCinsi { get; set; }
        public enums.TahsisTuru TahsisTuru { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int BirimId { get; set; }
        public bool Deleted { get; set; }
    }
}
