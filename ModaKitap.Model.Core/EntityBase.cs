using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaKitap.Model.Core
{
    public class EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DateTime? OlusumTarihi { get; set; }
        public int? OlusturanKullanıcıID { get; set; }

        public DateTime ? GuncellemeTarih { get; set; }
        public int? GuncelleyennKullanıcıID { get; set; }
    }
}
