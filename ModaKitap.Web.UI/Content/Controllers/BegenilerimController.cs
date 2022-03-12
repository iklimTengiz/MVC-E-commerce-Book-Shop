using ModaKitap.Model.Core;
using ModaKitap.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModaKitap.Web.UI.Controllers
{
    public class BegenilerimController : FRControllerBase
    {
      
            ModaKitapDB db = new ModaKitapDB();

            // GET: Sepet
            [HttpPost]
            public JsonResult begeniEkle(int ktpid, int adet)
            {
                db.Begenis.Add(new Model.Core.Entity.Begeni
                {
                    OlusumTarihi = DateTime.Now,
                    OlusturanKullanıcıID = LoginUserID,

                    KitaplarID = ktpid,
                    UserID = LoginUserID
                });

                var rt = db.SaveChanges();

                return Json(rt, JsonRequestBehavior.AllowGet);
            }


            [Route("Begenilenler")]
            public ActionResult Index()
            {
                var data = db.Begenis.Include("Kitaplar").Where(x => x.UserID == LoginUserID).ToList();

                return View(data);

            }

            public ActionResult Sil(int id)
            {
                var begenisil = db.Begenis.Where(x => x.ID == id).FirstOrDefault();
                db.Begenis.Remove(begenisil);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

        
    }
}