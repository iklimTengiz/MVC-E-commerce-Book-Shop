using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModaKitap.Model.Core;
using ModaKitap.Model.Core.Entity;

namespace ModaKitap.Web.UI.Areas.Admin.Controllers
{
    public class YayınEviController : AdminControllerBase
    {
        private ModaKitapDB db = new ModaKitapDB();

        // GET: Admin/YayınEvi
        public ActionResult Index()
        {
            return View(db.YayınEvis.ToList());
        }

        // GET: Admin/YayınEvi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YayınEvi yayınEvi = db.YayınEvis.Find(id);
            if (yayınEvi == null)
            {
                return HttpNotFound();
            }
            return View(yayınEvi);
        }

        // GET: Admin/YayınEvi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/YayınEvi/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UstID,YayınEviİsim,Aktif_Degil,OlusumTarihi,OlusturanKullanıcıID,GuncellemeTarih,GuncelleyennKullanıcıID")] YayınEvi yayınEvi)
        {
            if (ModelState.IsValid)
            {
                yayınEvi.OlusturanKullanıcıID = LoginUserID;
                yayınEvi.OlusumTarihi = DateTime.Now;
                yayınEvi.GuncellemeTarih = DateTime.Now;
                yayınEvi.GuncelleyennKullanıcıID = LoginUserID;
                db.YayınEvis.Add(yayınEvi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yayınEvi);
        }

        // GET: Admin/YayınEvi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YayınEvi yayınEvi = db.YayınEvis.Find(id);
            if (yayınEvi == null)
            {
                return HttpNotFound();
            }
            return View(yayınEvi);
        }

        // POST: Admin/YayınEvi/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UstID,YayınEviİsim,Aktif_Degil,OlusumTarihi,OlusturanKullanıcıID,GuncellemeTarih,GuncelleyennKullanıcıID")] YayınEvi yayınEvi)
        {
            if (ModelState.IsValid)
            {
   
                yayınEvi.GuncellemeTarih = DateTime.Now;
                yayınEvi.GuncelleyennKullanıcıID = LoginUserID;
                db.Entry(yayınEvi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yayınEvi);
        }

        // GET: Admin/YayınEvi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YayınEvi yayınEvi = db.YayınEvis.Find(id);
            if (yayınEvi == null)
            {
                return HttpNotFound();
            }
            return View(yayınEvi);
        }

        // POST: Admin/YayınEvi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YayınEvi yayınEvi = db.YayınEvis.Find(id);
            db.YayınEvis.Remove(yayınEvi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
