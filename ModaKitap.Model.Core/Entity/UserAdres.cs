using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaKitap.Model.Core.Entity
{
    public class UserAdres : EntityBase
    {
        public int UserID { get; set; }
        public User User { get; set; }

        public string Title { get; set; }

        public string Sehir { get; set; }

        public string Adres { get; set; }

        public bool Aktif_Degil { get; set; }




    }
}
