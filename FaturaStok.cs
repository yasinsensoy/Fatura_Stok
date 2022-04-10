using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Fatura_Stok
{
    [Serializable()]
    public class FaturaStok
    {
        public List<Kisiler> Kisiler { get; set; } = new List<Kisiler>();
        public List<Donemler> Donemler { get; set; } = new List<Donemler>();
        public List<Turler> Turler { get; set; } = new List<Turler>();
        public List<Fatura> Fatura { get; set; } = new List<Fatura>();

        public FaturaStok()
        { }
    }

    public abstract class Tablo
    {
        public long Id { get; set; }
    }

    [Serializable()]
    public class Kisiler : Tablo
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        [XmlIgnore]
        public string AdSoyad => Id == -1 ? "Tümü" : $"{Ad} {Soyad}";

        public Kisiler(long id, string ad, string soyad)
        {
            Id = id;
            Ad = ad;
            Soyad = soyad;
        }

        public Kisiler()
        { }
    }

    [Serializable()]
    public class Donemler : Tablo
    {
        public int Yil { get; set; }
        public int Ay { get; set; }
        [XmlIgnore]
        public string Ad => Id == -1 ? "Tümü" : $"{Yil}-{Ay:D2} ({Kayit.aylar[Ay]})";

        public Donemler(long id, int yil, int ay)
        {
            Id = id;
            Yil = yil;
            Ay = ay;
        }

        public Donemler()
        { }
    }

    [Serializable()]
    public class Turler : Tablo
    {
        public string Tur { get; set; }
        [XmlIgnore]
        public string Ad => Id == -1 ? "Tümü" : Tur;

        public Turler(long id, string tur)
        {
            Id = id;
            Tur = tur;
        }

        public Turler()
        { }
    }

    [Serializable()]
    public class Fatura : Tablo
    {
        public long KisiId { get; set; }
        public long DonemId { get; set; }
        public long TurId { get; set; }
        public decimal Fiyat { get; set; }
        public string Dekont { get; set; }
        public long IkinciKisiId { get; set; }
        public decimal IkinciFiyat { get; set; }
        public string IkinciDekont { get; set; }
        public string Aciklama { get; set; }
        [XmlIgnore]
        public string Kisi => Kayit.stok.Kisiler.FirstOrDefault(t => t.Id == KisiId).AdSoyad;
        [XmlIgnore]
        public string IkinciKisi { get { Kisiler ikikisi = Kayit.stok.Kisiler.FirstOrDefault(t => t.Id == IkinciKisiId); return ikikisi == null ? "" : ikikisi.AdSoyad; } }
        [XmlIgnore]
        public string Donem => Kayit.stok.Donemler.FirstOrDefault(t => t.Id == DonemId).Ad;
        [XmlIgnore]
        public string Tur => Kayit.stok.Turler.FirstOrDefault(t => t.Id == TurId).Ad;

        public Fatura()
        { }
    }
}