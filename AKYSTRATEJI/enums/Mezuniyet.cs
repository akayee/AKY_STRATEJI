using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.enums
{
    public enum Mezuniyet
    {
        Yok,
        İlkokul,
        Ortaokul,
        Lise,
        [Display(Name = "Yüksek Okul")]
        Yüksekokul,
        Üniversite,
        [Display(Name = "Yüksek Lisans")]
        YüksekLisans,
        Doktora
        
    }
}
