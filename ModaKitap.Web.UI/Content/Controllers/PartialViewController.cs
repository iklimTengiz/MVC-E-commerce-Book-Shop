using ModaKitap.Model.Core;
using ModaKitap.Model.Core.Entity;
using ModaKitap.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModaKitap.Web.UI.Controllers
{
    public class PartialViewController : FRControllerBase
    {
        ModaKitapDB db = new ModaKitapDB();
        // GET: PartialView
        public PartialViewResult KategoriFooter()
        {
            ViewBag.IsLogin = this.IsLogin;
            var data = db.Kategoris.OrderByDescending(x => x.OlusumTarihi).Take(6).ToList();
            return PartialView(data);
        }

        public PartialViewResult LeftMenuSozlesme()
        {
            return PartialView();
        }

        public PartialViewResult soneklenen()
        {
            ViewBag.IsLogin = this.IsLogin;
            var data = db.Kitaplars.OrderByDescending(x => x.OlusumTarihi).Take(4).ToList();

            return PartialView(data);
        }

        public PartialViewResult onerilen()
        {
            ViewBag.IsLogin = this.IsLogin;
            var data = db.Kitaplars.OrderByDescending(x => x.OlusumTarihi).Take(4).ToList();

            return PartialView(data);
        }


        public PartialViewResult begenilist()
        {
            ViewBag.IsLogin = this.IsLogin;
            var data = db.Begenis.Include("Kitaplar").OrderByDescending(x => x.OlusumTarihi).Take(4).ToList();

            return PartialView(data);
        }

    }
}







