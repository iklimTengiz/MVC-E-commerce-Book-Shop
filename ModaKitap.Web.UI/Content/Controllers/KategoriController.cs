using ModaKitap.Model.Core;
using ModaKitap.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModaKitap.Web.UI.Controllers
{
    public class KategoriController : FRControllerBase
    {
        ModaKitapDB db = new ModaKitapDB();

        // GET: Kategori
        [Route("Kategori/{isim}/{id}")]
        public ActionResult Index(string isim, int id)
        {
           var data= db.Kitaplars.Include("Kategori").Where(x => x.KategoriID == id).ToList();
            ViewBag.kategori = db.Kategoris.Where(x => x.ID == id).FirstOrDefault();
            ViewBag.IsLogin = this.IsLogin;
            return View(data);
        }
    }
}