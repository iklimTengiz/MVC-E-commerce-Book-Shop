using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaKitap.Model.Core.Entity
{
    public class Form:EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string subject { get; set; }
        public string mesaj { get; set; }

    }
}
