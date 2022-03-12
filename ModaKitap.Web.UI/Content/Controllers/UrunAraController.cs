using ModaKitap.Model.Core;
using ModaKitap.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModaKitap.Web.UI.Controllers
{
    public class UrunAraController : FRControllerBase
    {
        // GET: UrunAra
        ModaKitapDB db = new ModaKitapDB();
        // GET: Search
        public ActionResult Index(string searching)
        {
            ViewBag.IsLogin = this.IsLogin;
            var kitaplars = from k in db.Kitaplars
                            select k;
            if (!String.IsNullOrEmpty(searching))
            {
                kitaplars = kitaplars.Where(k => k.KitapAdı.Contains(searching));

            }
            return View(kitaplars.ToList());
        }
    }
}