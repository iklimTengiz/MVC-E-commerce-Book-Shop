using ModaKitap.Model.Core;
using ModaKitap.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModaKitap.Web.UI.Areas.Admin.Controllers
{
    public class YeniUrunController : FRControllerBase
    {
        ModaKitapDB db = new ModaKitapDB();
        // GET: YeniUrun
        [Route("~/yeniurun")]
        public ActionResult Index()
        {
            ViewBag.IsLogin = this.IsLogin;
            var data = db.Kitaplars.OrderByDescending(x => x.OlusumTarihi).Take(30).ToList();
            return View(data);
        }
    }
}