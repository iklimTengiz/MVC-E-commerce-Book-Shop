using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaKitap.Model.Core.Entity
{
    public class User : EntityBase
    {


        public String Ad { get; set; }


        public String Soyad { get; set; }


        public String Mail { get; set; }


        public String Telefon { get; set; }



        public string Sifre { get; set; }


        public string TC { get; set; }
        

        public bool Aktif_Değil { get; set; }

        public bool Adminmi { get; set; }


        public bool okudum { get; set; }

        public virtual IEnumerable<UserAdres> UserAdres { get; set; }
    }
    }
