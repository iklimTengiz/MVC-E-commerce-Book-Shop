using ModaKitap.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModaKitap.Web.UI.Areas.Admin.Controllers
{
    public class SiparisAraController : AdminControllerBase
    {
        ModaKitapDB db = new ModaKitapDB();
        // GET: Admin/SiparisAra
        public ActionResult Index(string searching)
        {
            ViewBag.IsLogin = this.IsLogin;
            var siparis = from k in db.Siparis
                            select k;
            if (!String.IsNullOrEmpty(searching))
            {
                siparis = siparis.Where(k => k.User.Ad.Contains(searching));

            }
            return View(siparis.ToList());
        }
    }
}