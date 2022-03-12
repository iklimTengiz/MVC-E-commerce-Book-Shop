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
    public class AdminSiparisController : Controller
    {
        private ModaKitapDB db = new ModaKitapDB();

        // GET: Admin/AdminSiparisz
        public ActionResult Index()
        {
            var siparis = db.Siparis.Include(s => s.Durum).Include(s => s.User).Include(s => s.UserAdres);
            return View(siparis.ToList());
        }

        // GET: Admin/AdminSiparis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparis.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            return View(siparis);
        }

        // GET: Admin/AdminSiparis/Create
        public ActionResult Create()
        {
            ViewBag.DurumID = new SelectList(db.Durums, "ID", "Name");
            ViewBag.UserID = new SelectList(db.Users, "ID", "Ad");
            ViewBag.UserAdresID = new SelectList(db.UserAdress, "ID", "Title");
            return View();
        }

        // POST: Admin/AdminSiparis/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,UserAdresID,DurumID,ToplamTutar,ToplamKDV,İndirimToplamı,Toplam,OlusumTarihi,OlusturanKullanıcıID,GuncellemeTarih,GuncelleyennKullanıcıID")] Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                db.Siparis.Add(siparis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DurumID = new SelectList(db.Durums, "ID", "Name", siparis.DurumID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "Ad", siparis.UserID);
            ViewBag.UserAdresID = new SelectList(db.UserAdress, "ID", "Title", siparis.UserAdresID);
            return View(siparis);
        }

        // GET: Admin/AdminSiparis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparis.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            ViewBag.DurumID = new SelectList(db.Durums, "ID", "Name", siparis.DurumID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "Ad", siparis.UserID);
            ViewBag.UserAdresID = new SelectList(db.UserAdress, "ID", "Title", siparis.UserAdresID);
            return View(siparis);
        }

        // POST: Admin/AdminSiparis/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,UserAdresID,DurumID,ToplamTutar,ToplamKDV,İndirimToplamı,Toplam,OlusumTarihi,OlusturanKullanıcıID,GuncellemeTarih,GuncelleyennKullanıcıID")] Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siparis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DurumID = new SelectList(db.Durums, "ID", "Name", siparis.DurumID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "Ad", siparis.UserID);
            ViewBag.UserAdresID = new SelectList(db.UserAdress, "ID", "Title", siparis.UserAdresID);
            return View(siparis);
        }

        // GET: Admin/AdminSiparis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparis.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            return View(siparis);
        }

        // POST: Admin/AdminSiparis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Siparis siparis = db.Siparis.Find(id);
            db.Siparis.Remove(siparis);
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
