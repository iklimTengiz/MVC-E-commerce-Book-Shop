using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaKitap.Model.Core.Entity
{
    public class Kitaplar : EntityBase
    {
        public string KitapAdı { get; set; }

        public int KategoriID { get; set; }
        public Kategori Kategori { get; set; }

        public int YayınEviID { get; set; }
        public YayınEvi YayınEvi { get; set; }

        public int KargoKiminsID { get; set; }
        public KargoKimin KargoKimin { get; set; }

        public int KondisyonsID { get; set; }
        public Kondisyon Kondisyon { get; set; }

        public int CiltDurumusID { get; set; }
        public CiltDurumu CiltDurumu { get; set; }

        public string Yazar { get; set; }
        public string Boyuten { get; set; }
        public string Boyutboy { get; set; }
        public string Aciklama { get; set; }
        public string Ceviren { get; set; }
        public string YayinYeri { get; set; }
        public string YayinYili { get; set; }
        public string ISBN { get; set; }
        public string Hazirlayan { get; set; }
        public string Dil { get; set; }
        public string Dil2 { get; set; }
        public string SayfaSayisi { get; set; }
        public string ResimURL { get; set; }
        public decimal Fiyat { get; set; }
        public decimal İndirim { get; set; }
        public int Stok { get; set; }



    }
}
