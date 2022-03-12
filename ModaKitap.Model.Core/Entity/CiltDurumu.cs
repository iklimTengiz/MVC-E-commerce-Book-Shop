using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaKitap.Model.Core.Entity
{
    public class CiltDurumu : EntityBase 
    {
        public int UstID { get; set; } 
        public string CiltDurum { get; set; }
    }
}
