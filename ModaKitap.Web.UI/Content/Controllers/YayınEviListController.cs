using ModaKitap.Model.Core;
using ModaKitap.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModaKitap.Web.UI.Controllers
{
    public class YayınEviListController : FRControllerBase
    {
        // GET: YayınEviList
        ModaKitapDB db = new ModaKitapDB();
        [Route("YayınEvi/{isim}/{id}")]
        public ActionResult Index(string isim, int id)
        {
            var data = db.Kitaplars.Where(x => x.YayınEviID == id).ToList();
            ViewBag.yayınevi = db.YayınEvis.Where(x => x.ID == id).FirstOrDefault();
            ViewBag.IsLogin = this.IsLogin;
            return View(data);
        }
    }
}