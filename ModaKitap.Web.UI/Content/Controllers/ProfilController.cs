using ModaKitap.Model.Core;
using ModaKitap.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModaKitap.Web.UI.Controllers
{
    public class ProfilController : FRControllerBase
    {
        ModaKitapDB db = new ModaKitapDB();
        // GET: Profil
        public ActionResult Index()
        {
            ViewBag.IsLogin = this.IsLogin;
            return View();
        }

        [Route("Adreslerim")]
        public ActionResult Adreslerim()
        {
            ViewBag.IsLogin = this.IsLogin;
            var data = db.UserAdress.Include("User").Where(x => x.UserID == LoginUserID).ToList();
            return View(data);
        }

    }
}