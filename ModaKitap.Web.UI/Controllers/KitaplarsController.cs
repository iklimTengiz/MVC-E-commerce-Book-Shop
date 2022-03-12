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
using ModaKitap.Web.UI.Controllers.Base;

namespace ModaKitap.Web.UI.Controllers
{
    public class KitaplarsController : FRControllerBase
    {
        private ModaKitapDB db = new ModaKitapDB();

        // GET: Kitaplars
        public ActionResult Index()
        {
            var kitaplars = db.Kitaplars.Include(k => k.Kategori).Include(k => k.YayınEvi);
            return View(kitaplars.ToList());
        }

        // GET: Kitaplars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitaplar kitaplar = db.Kitaplars.Find(id);
            if (kitaplar == null)
            {
                return HttpNotFound();
            }
            return View(kitaplar);
        }

        // GET: Kitaplars/Create
        public ActionResult Create()
        {
            ViewBag.KategoriID = new SelectList(db.Kategoris, "ID", "Kategoriİsim");
            ViewBag.YayınEviID = new SelectList(db.YayınEvis, "ID", "YayınEviİsim");
            return View();
        }

        // POST: Kitaplars/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,KitapAdı,KategoriID,YayınEviID,Boyut,Aciklama,ResimURL,Fiyat,Kdv,İndirim,Stok,OlusumTarihi,OlusturanKullanıcıID,GuncellemeTarih,GuncelleyennKullanıcıID")] Kitaplar kitaplar)
        {
            if (ModelState.IsValid)
            {
                db.Kitaplars.Add(kitaplar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriID = new SelectList(db.Kategoris, "ID", "Kategoriİsim", kitaplar.KategoriID);
            ViewBag.YayınEviID = new SelectList(db.YayınEvis, "ID", "YayınEviİsim", kitaplar.YayınEviID);

            return View(kitaplar);
        }

        // GET: Kitaplars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitaplar kitaplar = db.Kitaplars.Find(id);
            if (kitaplar == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriID = new SelectList(db.Kategoris, "ID", "Kategoriİsim", kitaplar.KategoriID);
            ViewBag.YayınEviID = new SelectList(db.YayınEvis, "ID", "YayınEviİsim", kitaplar.YayınEviID);
            return View(kitaplar);
        }

        // POST: Kitaplars/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,KitapAdı,KategoriID,YayınEviID,Boyut,Aciklama,ResimURL,Fiyat,Kdv,İndirim,Stok,OlusumTarihi,OlusturanKullanıcıID,GuncellemeTarih,GuncelleyennKullanıcıID")] Kitaplar kitaplar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kitaplar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriID = new SelectList(db.Kategoris, "ID", "Kategoriİsim", kitaplar.KategoriID);
            ViewBag.YayınEviID = new SelectList(db.YayınEvis, "ID", "YayınEviİsim", kitaplar.YayınEviID);
            return View(kitaplar);
        }

        // GET: Kitaplars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitaplar kitaplar = db.Kitaplars.Find(id);
            if (kitaplar == null)
            {
                return HttpNotFound();
            }
            return View(kitaplar);
        }

        // POST: Kitaplars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kitaplar kitaplar = db.Kitaplars.Find(id);
            db.Kitaplars.Remove(kitaplar);
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
