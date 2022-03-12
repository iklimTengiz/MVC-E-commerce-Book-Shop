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
    public class KategorisController : AdminControllerBase
    {
        private ModaKitapDB db = new ModaKitapDB();

        // GET: Admin/Kategoris
        public ActionResult Index()
        {
            return View(db.Kategoris.ToList());
        }

        // GET: Admin/Kategoris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = db.Kategoris.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        // GET: Admin/Kategoris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Kategoris/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UstID,Kategoriİsim,Aktif_Degil,OlusumTarihi,OlusturanKullanıcıID,GuncellemeTarih,GuncelleyennKullanıcıID")] Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                kategori.OlusturanKullanıcıID = LoginUserID;
                kategori.OlusumTarihi = DateTime.Now;
                kategori.GuncellemeTarih = DateTime.Now;
                kategori.GuncelleyennKullanıcıID = LoginUserID;
                db.Kategoris.Add(kategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategori);
        }

        // GET: Admin/Kategoris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = db.Kategoris.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        // POST: Admin/Kategoris/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UstID,Kategoriİsim,Aktif_Degil,OlusumTarihi,OlusturanKullanıcıID,GuncellemeTarih,GuncelleyennKullanıcıID")] Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                kategori.GuncellemeTarih = DateTime.Now;
                kategori.GuncelleyennKullanıcıID = LoginUserID;
                db.Entry(kategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategori);
        }

        // GET: Admin/Kategoris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = db.Kategoris.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        // POST: Admin/Kategoris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategori kategori = db.Kategoris.Find(id);
            db.Kategoris.Remove(kategori);
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
