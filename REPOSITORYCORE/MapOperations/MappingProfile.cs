using AKYSTRATEJI.Model;
using AKYSTRATEJI.ViewModals;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REPOSITORYCORE.MapOperations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VMAmaclar,StAmaclar>();
            CreateMap<StAmaclar, VMAmaclar>();
            CreateMap<VMAraclar, BrAraclar>();
            CreateMap<BrAraclar, VMAraclar> ();
            CreateMap<VMBirimler, BrBirimler>();
            CreateMap<BrBirimler, VMBirimler>();
            CreateMap<VMDonanimlar, BrDonanimlar>();
            CreateMap<BrDonanimlar, VMDonanimlar>();
            CreateMap<VMFaaliyet, FlFaaliyet>();
            CreateMap<FlFaaliyet, VMFaaliyet>();
            CreateMap<VMFaaliyetTurleri, FlFaaliyetturleri>();
            CreateMap<FlFaaliyetturleri, VMFaaliyetTurleri>();
            CreateMap<VMFizikselYapilar, BrFizikselYapilar>();
            CreateMap<BrFizikselYapilar, VMFizikselYapilar>();
            CreateMap<VMHedefler, StHedefler>();
            CreateMap<StHedefler, VMHedefler>();
            CreateMap<VMIsler, StIsler>();
            CreateMap<StIsler, VMIsler>();
            CreateMap<VMIsturleri, StIsturlerİ>();
            CreateMap<VMKullanicilar, Kullanicilar>();
            CreateMap<Kullanicilar, VMKullanicilar>();
            CreateMap<VMKullanicilarBirimler, KullanicilarBirimler>();
            CreateMap<KullanicilarBirimler, VMKullanicilarBirimler>();
            CreateMap<VMMaliFaaliyet, StFaalİyet>();
            CreateMap<StFaalİyet, VMMaliFaaliyet>();
            CreateMap<VMMaliFaaliyetTurleri, StFaalİyetler>();
            CreateMap<VMMevzuatlar, BrMevzuatlar>();
            CreateMap<BrMevzuatlar, BrMevzuatlar>();
            CreateMap<VMOlcuBirimi, GnOlcubirimi>();
            CreateMap<GnOlcubirimi, VMOlcuBirimi>();
            CreateMap<VMPerformanslar, StPerformanslar>();
            CreateMap<StPerformanslar, VMPerformanslar>();
            CreateMap<VMPersoneller, BrPersoneller>();
            CreateMap<BrPersoneller, VMPersoneller>();
            CreateMap<VMYazilimlar, BrYazilimlar>();
            CreateMap<BrYazilimlar, VMYazilimlar>();
            CreateMap<VMYetkiGorevTanimlari, BrYetkiGorevTanimlari>();
            CreateMap<BrYetkiGorevTanimlari, VMYetkiGorevTanimlari>();
            CreateMap<VMYetkiler, YtYetkiler>();
            CreateMap<YtYetkiler, VMYetkiler>();
            CreateMap<VMYetkilervYetkiGruplari, YtYetkilerYetkigruplari>();
            CreateMap<YtYetkilerYetkigruplari, VMYetkilervYetkiGruplari>();
            CreateMap<VMYetkiGruplari, YtYetkigruplari>();
            CreateMap<YtYetkigruplari, VMYetkiGruplari>();
            CreateMap<VMYillikHedefler, StYillikhedef>();
            CreateMap<StYillikhedef, VMYillikHedefler>();
        }
    }
}
