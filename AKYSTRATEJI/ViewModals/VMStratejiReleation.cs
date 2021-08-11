using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.ViewModals
{
    public class VMStratejiReleation
    {
        public int Id { get; set; }
        public int FaaliyetId { get; set; }
        public int AmacId { get; set; }
        public int HedefId { get; set; }
        public int PerformansId { get; set; }
        public int IsturuId { get; set; }
        public int YillikHedefId { get; set; }
        public int StratejiYiliId { get; set; }
        public bool Deleted { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public int OlusturanKullanici { get; set; }
    }
}
