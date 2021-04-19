using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.enums
{
    public enum Kadrolar
    {
        Memur,
        [Display(Name = "Sözleşmeli Memur")]
        SözleşmeliMemur,
        [Display(Name = "Şirket Personeli")]
        ŞirketPersoneli,
        İşçi

    }
}
