using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModaKitap.Model.Core;
using ModaKitap.Model.Core.Entity;

namespace ModaKitap.Web.UI.Areas.Admin.Controllers
{
    public class AdminKitaplarsController : AdminControllerBase
    {
        private ModaKitapDB db = new ModaKitapDB();

        // GET: Admin/AdminKitaplars
        public ActionResult Index()
        {
            ViewBag.IsLogin = this.IsLogin;
            var kitaplars = db.Kitaplars.Include(k => k.Kategori).Include(k => k.YayınEvi).Include(k => k.KargoKimin).Include(k => k.CiltDurumu).Include(k => k.Kondisyon);
            return View(kitaplars.ToList());
        }

        // GET: Admin/AdminKitaplars/Details/5
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

        // GET: Admin/AdminKitaplars/Create
        public ActionResult Create(HttpPostedFileBase imageq)
        {
            ViewBag.KategoriID = new SelectList(db.Kategoris, "ID", "Kategoriİsim");
            ViewBag.YayınEviID = new SelectList(db.YayınEvis, "ID", "YayınEviİsim");
            ViewBag.KargoKiminsID = new SelectList(db.KargoKimins, "ID", "KargoOdeme");
            ViewBag.CiltDurumusID = new SelectList(db.CiltDurumus, "ID", "CiltDurum");
            ViewBag.KondisyonsID = new SelectList(db.Kondisyons, "ID", "KondisyonDurum");
            return View();
        }

        // POST: Admin/AdminKitaplars/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,KitapAdı,KategoriID,YayınEviID,KargoKiminsID,KondisyonsID,CiltDurumusID,Yazar,Boyuten,Boyutboy,Aciklama,Ceviren,YayinYeri,YayinYili,ISBN,Hazirlayan,Dil,Dil2,SayfaSayisi,ResimURL,Fiyat,İndirim,Stok,OlusumTarihi,OlusturanKullanıcıID,GuncellemeTarih,GuncelleyennKullanıcıID")] Kitaplar kitaplar,HttpPostedFileBase imageq)
        {
            
            if (ModelState.IsValid)
            {
                if (imageq != null)
                {
                    if (Directory.Exists(Server.MapPath("/Admin/KitapResimAdmin")) == false)
                    {
                        Directory.CreateDirectory(Server.MapPath("/Admin/KitapResimAdmin"));
                    }
                    if ((imageq.FileName.Contains("jpg") || imageq.FileName.Contains("jpeg") || imageq.FileName.Contains("png")))
                    {
                        imageq.SaveAs(Path.Combine(Server.MapPath("~/Admin/KitapResimAdmin"), imageq.FileName));

                    }
                }
               
                kitaplar.OlusturanKullanıcıID = LoginUserID;
                kitaplar.OlusumTarihi = DateTime.Now;
                kitaplar.GuncellemeTarih = DateTime.Now;
                kitaplar.GuncelleyennKullanıcıID = LoginUserID;
                kitaplar.ResimURL = imageq.FileName;
                db.Kitaplars.Add(kitaplar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriID = new SelectList(db.Kategoris,"ID","Kategoriİsim", kitaplar.KategoriID);
            ViewBag.YayınEviID = new SelectList(db.YayınEvis,"ID","YayınEviİsim", kitaplar.YayınEviID);
            ViewBag.KargoKiminsID = new SelectList(db.KargoKimins,"ID","KargoOdeme", kitaplar.KargoKiminsID);
            ViewBag.KondisyonsID = new SelectList(db.Kondisyons,"ID", "KondisyonDurum", kitaplar.KondisyonsID);
            ViewBag.CiltDurumusID = new SelectList(db.CiltDurumus,"ID", "CiltDurum", kitaplar.CiltDurumusID);

            return View(kitaplar);
        }

        // GET: Admin/AdminKitaplars/Edit/5
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
            ViewBag.KargoKiminsID = new SelectList(db.KargoKimins, "ID", "KargoOdeme", kitaplar.KargoKiminsID);
            ViewBag.KondisyonsID = new SelectList(db.Kondisyons, "ID", "KondisyonDurum", kitaplar.KondisyonsID);
            ViewBag.CiltDurumusID = new SelectList(db.CiltDurumus, "ID", "CiltDurum", kitaplar.CiltDurumusID);
            return View(kitaplar);
        }

        // POST: Admin/AdminKitaplars/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,KitapAdı,KategoriID,YayınEviID,KargoKiminsID,KondisyonsID,CiltDurumusID,Yazar,Boyuten,Boyutboy,Aciklama,Ceviren,YayinYeri,YayinYili,ISBN,Hazirlayan,Dil,Dil2,SayfaSayisi,ResimURL,Fiyat,İndirim,Stok,OlusumTarihi,OlusturanKullanıcıID,GuncellemeTarih,GuncelleyennKullanıcıID")] Kitaplar kitaplar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kitaplar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            kitaplar.GuncelleyennKullanıcıID = LoginUserID;
            kitaplar.GuncellemeTarih = DateTime.Now;
            ViewBag.KategoriID = new SelectList(db.Kategoris, "ID", "Kategoriİsim", kitaplar.KategoriID);
            ViewBag.YayınEviID = new SelectList(db.YayınEvis, "ID", "YayınEviİsim", kitaplar.YayınEviID);
            ViewBag.KargoKiminsID = new SelectList(db.KargoKimins, "ID", "KargoOdeme", kitaplar.KargoKiminsID);
            ViewBag.KondisyonsID = new SelectList(db.Kondisyons, "ID", "KondisyonDurum", kitaplar.KondisyonsID);
            ViewBag.CiltDurumusID = new SelectList(db.CiltDurumus, "ID", "CiltDurum", kitaplar.CiltDurumusID);
            return View(kitaplar);
        }

        // GET: Admin/AdminKitaplars/Delete/5
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

        // POST: Admin/AdminKitaplars/Delete/5
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
