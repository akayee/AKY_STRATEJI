using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMFaaliyetTurleri
    {
        public int id { get; set; }
        public string Aciklama { get; set; }
        public string Adi { get; set; }
        public int OlcuBirimiId { get; set; }
        public int PerformansId { get; set; }
        public int FaaliyetlerId { get; set; }
        public int BirimId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public bool Deleted { get; set; }
        public int IsturleriId { get; set; }
    }
}
