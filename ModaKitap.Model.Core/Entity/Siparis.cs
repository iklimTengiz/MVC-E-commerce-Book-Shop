using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaKitap.Model.Core.Entity
{
    public class Siparis : EntityBase
    {

        public int UserID { get; set; }
        public User User { get; set; }

        public int UserAdresID { get; set; }
        public UserAdres UserAdres { get; set; }

 
        public int DurumID { get; set; }
        public Durum Durum { get; set; }

        public string SiparisNo { get; set; }

        public decimal ToplamTutar { get; set; }

   
        public decimal ToplamKDV { get; set; }


        public decimal İndirimToplamı { get; set; }


        public decimal Toplam { get; set; }

        public virtual List<OdemeSecenekleri> OdemeSecenekleris { get; set; }
        public List<SiparisDetay> SiparisDetays { get; set; }
    }
}
