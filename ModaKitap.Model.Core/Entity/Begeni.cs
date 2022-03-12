using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaKitap.Model.Core.Entity
{
   public class Begeni : EntityBase
    {
        public int UserID { get; set; }
        public User User { get; set; }

        public int KitaplarID { get; set; }
        public Kitaplar Kitaplar { get; set; }
    }
}
