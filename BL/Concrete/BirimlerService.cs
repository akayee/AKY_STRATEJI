using ABB.Core.DataAccess;
using AKYSTRATEJI.Model;
using AKYSTRATEJI.ViewModals;
using BL.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class BirimlerService : ABBEntityServis<BrBirimler, AKYSTRATEJIContext>, IBirimServis
    {
        private readonly ILogger<BirimlerService> _logger;

        public BirimlerService(ILogger<BirimlerService> logger , IBirimTipleriServices birimtipi) : base(logger)
        {
            _logger = logger;
        }

        public bool BirimGuncelle(BrBirimler birim)
        {
            try
            {
                base.Guncelle(birim);
                return true;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public List<BrBirimler> BirimlerListele(Expression<Func<BrBirimler, bool>> filter = null, params Expression<Func<BrBirimler, object>>[] includeProperties)
        {
            try
            {
                return base.GetList(filter,birim=>birim.BirimTipi);
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool BirimSil(BrBirimler birim)
        {
            try
            {

                birim.Deleted = true;
                base.Guncelle(birim);
                return true;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public BrBirimler TekBirimGetir(int BirimId)
        {
            try
            {

                return base.Get(birim => birim.Id == BirimId && birim.Deleted != true,b=>b.BirimTipi);
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public override void Validate(BrBirimler entity)
        {
            //throw new NotImplementedException();
        }

        public int YeniBirimEkle(BrBirimler birim)
        {
            int counted = BirimlerListele().Count + 1;
            birim.BirimId = counted;
            birim.Id = counted;
            //System.Diagnostics.Debug.WriteLine(amac.Adi);

            try
            {

                base.Ekle(birim);
                return (birim.Id);
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
        public int UstBirimGetir(int BirimId)
        {

            BrBirimler birim = base.Get(null, birim => birim.BirimTipi);
            if(birim.BirimTipi.Id !=4)
            {
                int ustbirimId = (int)birim.UstBirimId;
                UstBirimGetir((int)birim.UstBirimId);
                return ustbirimId;
            }
            else
            {

                return birim.Id;
            }

        }

        public BirimBilgiler BirimBilgileriGetir(int[] BirimId)
        {
            List<BrBirimler> birimler = new List<BrBirimler>();
            List<VMBirimler> vmbirimler = new List<VMBirimler>();
            List<VMMevzuatlar> mevzuatlar = new List<VMMevzuatlar>();
            List<VMAraclar> araclar = new List<VMAraclar>();
            List<VMDonanimlar> donanimlar = new List<VMDonanimlar>();
            List<VMYazilimlar> yazilimlar = new List<VMYazilimlar>();
            List<VMFizikselYapilar> fizikselyapilar = new List<VMFizikselYapilar>();
            List<VMYetkiGorevTanimlari> yetkigorevler = new List<VMYetkiGorevTanimlari>();
            List<VMPersoneller> personeller = new List<VMPersoneller>();


            

            // Birimin ilgili tüm verileri burada çekiliyor.
            foreach (int i in BirimId)
            {
                BrBirimler tekbirim = base.Get(b => b.Id == i && b.Deleted!=true,
                    birim=>birim.BirimTipi,
                    b=>b.BrYetkiGorevTanimlaris,
                    birim=>birim.BrYazilimlars,
                    birim=>birim.BrPersonellers,
                    birim=>birim.BrMevzuatlars,
                    birim => birim.BrFizikselYapilars,
                    birim => birim.BrDonanimlars,
                    birim=>birim.BrAraclars);
                VMBirimler vmbirim = new VMBirimler()
                {
                    Adi=tekbirim.Adi,
                    BirimTipiAdi=tekbirim.BirimTipi.BirimTipi,
                    id=tekbirim.Id,
                    BirimTipiId=tekbirim.BirimTipiId,
                    Deleted=tekbirim.Deleted,
                    OlusturmaTarihi=tekbirim.OlustumraTarihi,
                    UstBirimAdi=null,
                    UstBirimId=tekbirim.UstBirimId
                };
                vmbirimler.Add(vmbirim);
                birimler.Add(tekbirim);
            }
            //MAPLEME İŞLEMİ
            foreach (BrBirimler birim in birimler)
            {
                //ARACLAR MAPLEME
                if(birim.BrAraclars.Count>0)
                {
                    foreach (BrAraclar arac in birim.BrAraclars)
                    {
                        VMAraclar vmarac = new VMAraclar()
                        {
                            Adi = arac.Adi,
                            AracCinsi = (AKYSTRATEJI.enums.AracCinsi)arac.Cinsi,
                            id = arac.Id,
                            TahsisTuru = (AKYSTRATEJI.enums.TahsisTuru)arac.TahsisTuru,
                            BirimId = arac.BirimId
                        };
                        araclar.Add(vmarac);
                    }
                }
                
                //DONANİMLAR MAPLEME
                if(birim.BrDonanimlars.Count>0)
                {

                    foreach (BrDonanimlar donanim in birim.BrDonanimlars)
                    {
                        VMDonanimlar vmdonanim = new VMDonanimlar()
                        {
                            Adi = donanim.Adi,
                            id = donanim.Id,
                            Sayi = donanim.Sayi,
                            BirimId = donanim.BirimId
                        };
                        donanimlar.Add(vmdonanim);
                    }
                }
                //YAZİLİM MAPLEME
                foreach (BrYazilimlar yazilim in birim.BrYazilimlars)
                {
                    VMYazilimlar vmyazilim = new VMYazilimlar()
                    {
                        Adi = yazilim.Adi,
                        id = yazilim.Id,
                        BirimId=yazilim.BirimId
                        
                    };
                    yazilimlar.Add(vmyazilim);
                }
                //FİZİKSEL YAPILAR MAPLEME
                foreach (BrFizikselYapilar fizikselyapi in birim.BrFizikselYapilars)
                {
                    VMFizikselYapilar vmfizikselyapi = new VMFizikselYapilar()
                    {
                        Adi = fizikselyapi.Adi,
                        id = fizikselyapi.Id,
                        Konum=fizikselyapi.Konum,
                        MetreKare=fizikselyapi.MetreKare,
                        BirimId=fizikselyapi.BirimId

                    };
                    fizikselyapilar.Add(vmfizikselyapi);
                }
                //YETKİ GÖREV TANIMLARI MAPLEME
                foreach (BrYetkiGorevTanimlari yetkigorev in birim.BrYetkiGorevTanimlaris)
                {
                    VMYetkiGorevTanimlari vmyetkigorevyapilar = new VMYetkiGorevTanimlari()
                    {
                        Adi = yetkigorev.Adi,
                        id = yetkigorev.Id,
                        BirimId = yetkigorev.BirimId,
                        Kanun=yetkigorev.Kanun

                    };
                    yetkigorevler.Add(vmyetkigorevyapilar);
                }
                //MEVZUATLAR MAPLEME
                foreach (BrMevzuatlar mevzuat in birim.BrMevzuatlars)
                {
                    VMMevzuatlar vmmevzuatlar = new VMMevzuatlar()
                    {
                        Adi = mevzuat.Adi,
                        id = mevzuat.Id,
                        BirimId = mevzuat.BirimId,
                        Yonetmelik=mevzuat.Yonetmelik

                    };
                    mevzuatlar.Add(vmmevzuatlar);
                }
                //Personeller MAPLEME
                foreach (BrPersoneller personel in birim.BrPersonellers)
                {
                    VMPersoneller vmpersonel = new VMPersoneller()
                    {
                        Adi = personel.Adi,
                        id = personel.Id,
                        BirimId = personel.BirimId,
                        Cinsiyet=personel.Cinsiyet,
                        Deleted= (bool)personel.Deleted,
                        DogumTarihi=personel.DogumTarihi,
                        IseGirisTarihi=personel.IseGirisTarihi,
                        Kadro= (AKYSTRATEJI.enums.Kadrolar)personel.Kadro,
                        KullaniciId= (int)personel.KullaniciId,
                        Mezuniyet= (AKYSTRATEJI.enums.Mezuniyet)personel.Mezuniyet,
                        OlusturmaTarihi=personel.OlusturmaTarihi,
                        Tel= (short)personel.Tel,
                        Unvan= (AKYSTRATEJI.enums.Unvanlar)personel.Unvan

                    };
                    personeller.Add(vmpersonel);
                }
            }
            BirimBilgiler birimbilgileri = new BirimBilgiler()
            {
                AracListesi = araclar,
                Donanimlar = donanimlar,
                FizikselYapilar = fizikselyapilar,
                Mevzuatlar = mevzuatlar,
                Personeller = personeller,
                Yazilimlar = yazilimlar,
                YetkiGorevTanimlari = yetkigorevler,
                YetkiliOlduguBirimler = vmbirimler
            };


            return birimbilgileri;
        }
    }
}
