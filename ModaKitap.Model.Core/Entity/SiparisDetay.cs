using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaKitap.Model.Core.Entity
{
    public class SiparisDetay : EntityBase
    {

        public int SiparisID { get; set; }

        public int KitapID { get; set; }
        public Kitaplar Kitaplar { get; set; }


        public int Adet { get; set; }
    }
}
