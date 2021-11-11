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
    public class StratejiReleationService : ABBEntityServis<StStratejireleation, AKYSTRATEJIContext>, IStratejiRelationServices
    {
        public readonly ILogger<StratejiReleationService> _logger;
        public StratejiReleationService(ILogger<StratejiReleationService> logger) : base(logger)
        {
            _logger = logger;
        }

        public List<StStratejireleation> StratejininYiliniListele(Expression<Func<StStratejireleation, bool>> filter = null, params Expression<Func<StStratejireleation, object>>[] includeProperties)
        {            
            return base.GetList(filter,includeProperties);
        }
        public StratejiYiliBilgileri YilStratejiBilgileriListele(int Yil, int[] Birimler)
        {
            List<StStratejireleation> relationlar = base.GetList(obj => obj.StratejiYili.Yil == Yil && Array.BinarySearch(Birimler, obj.StratejiYili) > -1,obj=>obj.Amac,obj=>obj.Faaliyet,obj=>obj.Hedef,obj=>obj.Isturu,obj=>obj.Performans,obj=>obj.StratejiYili);

            List<VMFaaliyetTurleri> faaliyetler = new List<VMFaaliyetTurleri>();
            List<VMAmaclar> amaclar = new List<VMAmaclar>();
            List<VMHedefler> hedefler = new List<VMHedefler>();
            List<VMPerformanslar> performanslar = new List<VMPerformanslar>();
            List<VMIsturleri> isturleri = new List<VMIsturleri>();
            foreach (StStratejireleation relation in relationlar)
            {
                if (relation.Faaliyet is not null)
                {
                    VMFaaliyetTurleri vmfaaliyet = new VMFaaliyetTurleri()
                    {
                        Aciklama = relation.Faaliyet.Aciklama,
                        Adi = relation.Faaliyet.Adi,
                        BirimId = relation.Faaliyet.BirimId,
                        Deleted = (bool)relation.Faaliyet.Deleted,
                        EkonomikSiniflandirma = (int)relation.Faaliyet.EkonomikKod,
                        FaaliyetlerId = relation.Faaliyet.FaaliyetlerId,
                        id = relation.Faaliyet.Id,
                        IsturleriId = (int)relation.Faaliyet.IsTuruId,
                        OlcuBirimiId = relation.Faaliyet.OlcuBirimi,
                        OlusturmaTarihi = relation.Faaliyet.OlusturmaTarihi,
                        PerformansId = relation.Faaliyet.PerformansId
                    };
                    faaliyetler.Add(vmfaaliyet);
                }
                if (relation.Amac is not null)
                {
                    VMAmaclar vmamac = new VMAmaclar()
                    {
                        Adi=relation.Amac.Adi,
                        Deleted=(bool)relation.Amac.Deleted,
                        id=relation.Amac.Id,
                        OlusturmaTarihi=relation.Amac.OlusturmaTarihi
                    };
                    amaclar.Add(vmamac);
                }
                if (relation.Hedef is not null)
                {
                    VMHedefler vmhedef = new VMHedefler()
                    {
                        AmaclarId=relation.Hedef.AmaclarId,
                        Deleted=(bool)relation.Hedef.Deleted,
                        id=relation.Hedef.Id,
                        OlusturmaTarihi=relation.Hedef.OlusturmaTarihi,
                        Tanim=relation.Hedef.Tanim
                    };
                    hedefler.Add(vmhedef);
                }
                if (relation.Performans is not null)
                {
                    VMPerformanslar vmperformans = new VMPerformanslar()
                    {
                        Adi=relation.Performans.Adi,
                        HedeflerId=relation.Performans.HedeflerId,
                        id=relation.Performans.Id,
                        Deleted=(bool)relation.Performans.Deleted,
                        OlusturmaTarihi=relation.Performans.OlusturmaTarihi
                    };
                    performanslar.Add(vmperformans);
                }
                if (relation.Isturu is not null)
                {
                    VMIsturleri vmisturu = new VMIsturleri()
                    {
                        Aciklama=relation.Isturu.Aciklama,
                        BirimId=relation.Isturu.BirimId,
                        Adi=relation.Isturu.Adi,
                        Deleted=(bool)relation.Isturu.Deleted,
                        id=relation.Isturu.Id,
                        OlcuBirimi=relation.Isturu.OlcuBirimi,
                        OlusturmaTarihi=relation.Isturu.OlusturmaTarihi,
                        PerformansId=relation.Isturu.PerformansId
                    };
                }
            }
            StratejiYiliBilgileri birimBilgileri = new StratejiYiliBilgileri
            {
                VMFaaliyetTurleri=faaliyetler,
                Amaclar=amaclar,
                Hedefler=hedefler,
                Performanslar=performanslar,
                Isturleri=isturleri
            };

            return birimBilgileri;
        }

        public bool TekStratejiIliskiSil(StStratejireleation Iliski)
        {
            try
            {
                Iliski.Deleted = true;
                base.Guncelle(Iliski);
            }catch(Exception e)
            {
                _logger.LogCritical(e, "ABBEntityServis Beklenmeyen Hata");
                throw new Exception("Beklenmeyen Hata");
            }

            return true;
        }

        public StStratejireleation TekStratejiRelationGetir(Expression<Func<StStratejireleation, bool>> filter = null, params Expression<Func<StStratejireleation, object>>[] includeProperties)
        {
            return base.Getir(filter,includeProperties);
        }

        public bool TopluStratejiIliskiEkle(List<StStratejireleation> StratejiIliskileri)
        {
            base.TopluEkle(StratejiIliskileri);
            return true;
        }

        public bool TopluStratejiIliskiSil(List<StStratejireleation> StratejiIliskileri)
        {
            for (int i = 0; i < StratejiIliskileri.Count; i++)
            {
                StratejiIliskileri[i].Deleted = true;
                base.Guncelle(StratejiIliskileri[i]);
            }
            return true;
        }

        public override void Validate(StStratejireleation entity)
        {
            
        }

        public bool YeniStratejiIliskiEkle(StStratejireleation Iliski)
        {
            try
            {
                base.Ekle(Iliski);
            } catch(Exception e)
            {
                _logger.LogCritical(e, "ABBEntityServis Beklenmeyen Hata");
                return false;
            }
            return true;
            
        }
    }
}
