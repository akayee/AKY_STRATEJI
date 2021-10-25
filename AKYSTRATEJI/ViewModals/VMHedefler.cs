using AKYSTRATEJI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMHedefler
    {
        public int id { get; set; }
        public string Tanim { get; set; }
        public int AmaclarId { get; set; }
        public bool Deleted { get; set; }
        public int HedeflerId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
    }
}
