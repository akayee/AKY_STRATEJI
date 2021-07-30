using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMYetkiGorevTanimlari
    {
        public int id { get; set; }
        public string Adi { get; set; }
        public string Kanun { get; set; }
        public int BirimId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public bool Deleted { get; set; }
    }
}
