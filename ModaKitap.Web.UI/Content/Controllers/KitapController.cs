using ModaKitap.Model.Core;
using ModaKitap.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ModaKitap.Web.UI.Controllers
{

    public class KitapController : FRControllerBase
    {

        // GET: Kitap

        [Route("Urun/{title}/{id}")]
        public ActionResult Detaylar(string title ,int id)
        {
            var db = new ModaKitapDB();
            ViewBag.IsLogin = this.IsLogin;
            var urun = db.Kitaplars.Include("Kategori").Include("YayınEvi").Where(x => x.ID == id).FirstOrDefault();
            return View(urun);
        }
    }
}

