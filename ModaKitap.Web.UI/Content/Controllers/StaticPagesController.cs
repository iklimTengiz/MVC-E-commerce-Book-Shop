using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModaKitap.Web.UI.Controllers
{
    public class StaticPagesController : Controller
    {
        // GET: StaticPages
        [Route("~/gizlilikSözlesmesi")]
        public ActionResult GizlilikSözlesme()
        {
            return View();
        }


        [Route("~/uyelikSozlesmesi")]
        public ActionResult Uyeliksözlesmesi()
        {
            return View();
        }

        [Route("~/mesafeliSatıssözlesmesi")]
        public ActionResult MesafeliSatısSozlesmesi()
        {
            return View();
        }

        [Route("~/kisiselveriaydınlatmametni")]
        public ActionResult kisiselveri()
        {
            return View();
        }

        [Route("~/kargoveteslimat")]
        public ActionResult KargoveTeslimat()
        {
            return View();
        }

        [Route("~/bilgitoplumuhizmetleri")]
        public ActionResult BilgiToplumuHizmetleri()
        {
            return View();
        }

        [Route("~/hakkımızda")]
        public ActionResult Hakkımızda()
        {
            return View();
        }
    }
}