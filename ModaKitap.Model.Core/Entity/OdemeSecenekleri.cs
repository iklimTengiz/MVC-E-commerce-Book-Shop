using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaKitap.Model.Core.Entity
{
    public class OdemeSecenekleri : EntityBase
    {

        public int SiparisID { get; set; }
        public _OrderType OrderType { get; set; }

        public decimal Price { get; set; }

  
        public String Banka { get; set; }

    }
    public enum _OrderType
    {
        Havale = 0,
        Kredikartı = 1

    }
}
