using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaKitap.Model.Core.Entity
{
    public class Sepet : EntityBase
    {

        public int UserID { get; set; }
        public User User { get; set; }

        public int ? UserAdresID { get; set; }
        public User UserAdres { get; set; }

        public int KitaplarID { get; set; }
        public Kitaplar Kitaplar { get; set; }
        public int Adet { get; set; }
    }
}
