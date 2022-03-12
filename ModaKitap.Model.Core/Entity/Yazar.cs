using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaKitap.Model.Core.Entity
{
    public class Yazar : EntityBase
    {
        public int UstID { get; set; }

        public String Yazaİsim { get; set; }


        public bool Aktif_Degil { get; set; }

       }
}
