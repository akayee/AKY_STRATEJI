using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AKYSTRATEJI.enums
{
    public enum Unvanlar
    {
        Şef,
        [Display(Name = "Şube Müdürü")]
        ŞubeMüdürü,
        [Display(Name = "Daire Başkanı")]
        DaireBaşkanı,
        [Display(Name = "Genel Müdür")]
        GenelMüdür,
        [Display(Name = "Genel Sekreter")]
        GenelSekreter,
        Başkan
    }
}
