using ModaKitap.Model.Core;
using ModaKitap.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModaKitap.Web.UI.Controllers
{
    public class SepetController :FRControllerBase
    {
        ModaKitapDB db = new ModaKitapDB();

        // GET: Sepet
        [HttpPost]

        
        public JsonResult UrunEkle(int ktpid ,int adet)
        {
            db.Sepets.Add(new Model.Core.Entity.Sepet
            {
                OlusumTarihi = DateTime.Now,
                OlusturanKullanıcıID =LoginUserID,
               
                KitaplarID= ktpid,
                Adet=adet,
                UserID=LoginUserID
            });
            
            var rt=db.SaveChanges();

            return Json(rt,JsonRequestBehavior.AllowGet);
        }
        [Route("Sepetim")]
        public ActionResult Index()
        {
            var data = db.Sepets.Include("Kitaplar").Where(x => x.UserID == LoginUserID).ToList();

            return View(data);

        }

        public ActionResult Sil(int id)
        {
            var sepetsil = db.Sepets.Where(x => x.ID == id).FirstOrDefault();
            db.Sepets.Remove(sepetsil);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}